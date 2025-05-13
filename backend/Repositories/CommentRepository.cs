using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly PostgresDbContext _postgresDb;
    public CommentRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task<CommentEntity?> GetByIdAsync(int commentId)
    {
        return await _postgresDb.Comments.Include(c => c.User)
                                        .ThenInclude(u => u.UserData)
                                        .FirstOrDefaultAsync(c => c.Id == commentId);
    }

    public async Task<List<CommentEntity>> GetByReviewAsync(int reviewId)
    {
        return await _postgresDb.Comments.Include(c => c.Review)
                                         .Include(c => c.User)
                                         .ThenInclude(u => u.UserData)
                                         .Where(c => c.Review.Id == reviewId)
                                         .ToListAsync();
    }

    public async Task<int> CreateAsync(CommentEntity entity)
    {
        await _postgresDb.Comments.AddAsync(entity);
        await _postgresDb.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(CommentEntity entity)
    {
        CommentEntity? comment = await _postgresDb.Comments.FindAsync(entity.Id);
        if (comment == null) return false;

        _postgresDb.Entry(comment).CurrentValues.SetValues(entity);
        await _postgresDb.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int commentId)
    {
        CommentEntity? comment = await _postgresDb.Comments.FindAsync(commentId);
        if (comment == null) return false;

        _postgresDb.Comments.Remove(comment);
        await _postgresDb.SaveChangesAsync();
        return true;
    }
}