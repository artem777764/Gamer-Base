using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface ICommentRepository
{
    Task<CommentEntity?> GetByIdAsync(int commentId);
    Task<List<CommentEntity>> GetByReviewAsync(int reviewId);
    Task<int> CreateAsync(CommentEntity entity);
    Task<bool> UpdateAsync(CommentEntity entity);
    Task<bool> DeleteAsync(int commentId);
}