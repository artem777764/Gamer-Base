using backend.DTOs.GameDTOs;
using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class GameRepository : IGameRepository
{
    private readonly PostgresDbContext _postgresDb;
    public GameRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task<List<GetReviewWithComments>?> GetByGameAsync(int gameId, int? userId = null)
    {
        bool gameExists = await _postgresDb.Games.AnyAsync(g => g.Id == gameId);
        if (!gameExists) return null;

        List<ReviewEntity> reviews = await _postgresDb.Reviews.Include(r => r.User)
                                                              .ThenInclude(u => u.UserData)
                                                              .Include(r => r.VotesReview)
                                                              .Where(r => r.GameId == gameId)
                                                              .ToListAsync();

        List<int> reviewIds = reviews.Select(r => r.Id)
                                     .ToList();

        List<int> userIds = reviews.Select(r => r.AuthorId)
                                   .Distinct()
                                   .ToList();

        List<CommentEntity> comments = await _postgresDb.Comments.Where(c => reviewIds.Contains(c.ReviewId))
                                                                 .Include(c => c.User)
                                                                 .ThenInclude(u => u.UserData)
                                                                 .Include(c => c.VotesComment)
                                                                 .ToListAsync();

        List<ReviewEntity> userMarks = await _postgresDb.Reviews.Where(r => r.GameId == gameId && userIds.Contains(r.AuthorId))
                                                                .ToListAsync();

        List<GetReviewWithComments> result = reviews.Select(r => new GetReviewWithComments
        {
            ReviewId = r.Id,
            UserId = r.AuthorId,
            UserImageURL = $"http://localhost:5007/Image/Download/{r.User.UserData.ProfileImageId}",
            UserName = r.User.UserData.Login,
            Mark = r.Mark,
            Title = r.Title,
            Content = r.Content,
            Date = r.Date,
            Rating = r.VotesReview.Sum(v => v.Vote),
            UserRatingMark = userId == null 
                ? 0
                : r.VotesReview.FirstOrDefault(v => v.UserId == userId)?.Vote ?? 0,
            Comments = comments.Where(c => c.ReviewId == r.Id)
                               .Select(c =>
                               {
                                   var userMark = userMarks.FirstOrDefault(m => m.AuthorId == c.UserId);
                                   return new GetCommentWithMarkDTO
                                   {
                                       Id = c.Id,
                                       UserId = c.UserId,
                                       UserImageURL = $"http://localhost:5007/Image/Download/{c.User.UserData.ProfileImageId}",
                                       UserName = c.User.UserData.Login,
                                       Content = c.Content,
                                       Date = c.Date,
                                       Rating = c.VotesComment.Sum(v => v.Vote),
                                       UserMark = userMark?.Mark,
                                       UserRatingMark = userId == null 
                                            ? 0 
                                            : c.VotesComment.FirstOrDefault(v => v.UserId == userId)?.Vote ?? 0,
                                   };
                               }).OrderByDescending(c => c.Date)
                                 .ToList()
        }).OrderByDescending(r => r.Date)
          .ToList();

        return result;
    }

    public async Task<GameEntity?> GetByIdAsync(int gameId)
    {
        return await _postgresDb.Games.Include(g => g.GameGenres)
                                .ThenInclude(gg => gg.Genre)
                                .Include(g => g.Developer)
                                .Include(g => g.Publisher)
                                .Include(g => g.GamePlatforms)
                                .ThenInclude(gp => gp.Platform)
                                .Include(g => g.Reviews)
                                .Where(g => g.Id == gameId)
                                .FirstOrDefaultAsync();
    }

    public async Task<List<GameEntity>> GetGamesByFilterAsync(int page, int size, GetGamesByFilter filter)
    {
        var query = _postgresDb.Games.Include(g => g.GameGenres)
                                     .ThenInclude(gg => gg.Genre)
                                     .Include(g => g.GamePlatforms)
                                     .ThenInclude(gp => gp.Platform)
                                     .Include(g => g.Developer)
                                     .Include(g => g.Publisher)
                                     .Include(g => g.Reviews)
                                     .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            query = query.Where(g => g.Name.ToLower().Contains(filter.Name.ToLower()));
        }

        if (filter.PlatformId.HasValue)
        {
            query = query.Where(g => g.GamePlatforms.Any(gp => gp.PlatformId == filter.PlatformId.Value));
        }

        if (filter.GenreId.HasValue)
        {
            query = query.Where(g => g.GameGenres.Any(gg => gg.GenreId == filter.GenreId.Value));
        }

        if (filter.DeveloperId.HasValue)
        {
            query = query.Where(g => g.DeveloperId == filter.DeveloperId.Value);
        }

        if (filter.PublisherId.HasValue)
        {
            query = query.Where(g => g.PublisherId == filter.PublisherId.Value);
        }

        query = query.Skip((page - 1) * size).Take(size);
        return await query.ToListAsync();
    }

    public async Task<int> CreateAsync(GameEntity game)
    {
        await _postgresDb.Games.AddAsync(game);
        await _postgresDb.SaveChangesAsync();
        return game.Id;
    }

    public async Task AddPlatforms(List<GamePlatformsEntity> entities)
    {
        await _postgresDb.GamePlatforms.AddRangeAsync(entities);
        await _postgresDb.SaveChangesAsync();
    }

    public async Task AddGenres(List<GameGenresEntity> genres)
    {
        await _postgresDb.GameGenres.AddRangeAsync(genres);
        await _postgresDb.SaveChangesAsync();
    }
}