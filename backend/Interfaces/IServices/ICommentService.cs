using backend.DTOs.CommentDTOs;

namespace backend.Interfaces.IServices;

public interface ICommentService
{
    Task<GetCommentDTO?> GetByIdAsync(int commentId);
    Task<List<GetCommentDTO>> GetByReviewAsync(int reviewId);
    Task<int> CreateAsync(CreateCommentDTO commentDTO);
    Task<bool> UpdateAsync(int commentId, UpdateCommentDTO commentDTO);
    Task<bool> DeleteAsync(int commentId);
}