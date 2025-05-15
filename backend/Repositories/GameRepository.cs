using backend.DTOs.GameDTOs;
using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class GameRepository : IGameRepository
{
    private readonly PostgresDbContext _postgresDb;
    public GameRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task<List<GetReviewWithComments>?> GetByGameAsync(int gameId)
    {
        bool gameExists = await _postgresDb.Games.AnyAsync(g => g.Id == gameId);
        if(!gameExists) return null;
        
        List<ReviewEntity> reviews = await _postgresDb.Reviews.Include(r => r.User)
                                                              .ThenInclude(u => u.UserData)
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
                                                                 .ToListAsync();
        
        List<ReviewEntity> userMarks = await _postgresDb.Reviews.Where(r => r.GameId == gameId && userIds.Contains(r.AuthorId))
                                                                .ToListAsync();

        List<GetReviewWithComments> result = reviews.Select(r => new GetReviewWithComments
        {
            ReviewId = r.Id,
            UserId = r.AuthorId,
            UserName = r.User.UserData.Login,
            Mark = r.Mark,
            Title = r.Title,
            Content = r.Content,
            Date = r.Date,
            Rating = r.Rating,
            Comments = comments.Where(c => c.ReviewId == r.Id)
                               .Select(c =>
                               {
                                    var userMark = userMarks.FirstOrDefault(m => m.AuthorId == c.UserId);
                                    return new GetCommentWithMarkDTO
                                    {
                                        Id = c.Id,
                                        UserId = c.UserId,
                                        UserName = c.User.UserData.Login,
                                        Content = c.Content,
                                        Date = c.Date,
                                        Rating = c.Rating,
                                        UserMark = userMark?.Mark
                                    };
                               }).ToList()
        }).ToList();

        return result;
    }
}