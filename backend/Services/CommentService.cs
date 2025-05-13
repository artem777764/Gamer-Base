using backend.DTOs.CommentDTOs;
using backend.Extansions;
using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;
using backend.Models.Entities;

namespace backend.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<GetCommentDTO?> GetByIdAsync(int commentId)
    {
        CommentEntity? comment = await _commentRepository.GetByIdAsync(commentId);
        if (comment == null) return null;

        return comment.ToDTO();
    }

    public async Task<List<GetCommentDTO>> GetByReviewAsync(int reviewId)
    {
        List<CommentEntity> comments = await _commentRepository.GetByReviewAsync(reviewId);
        return comments.Select(c => c.ToDTO()).ToList();
    }

    public async Task<int> CreateAsync(CreateCommentDTO commentDTO)
    {
        return await _commentRepository.CreateAsync(commentDTO.ToEntity());
    }

    public async Task<bool> UpdateAsync(int commentId, UpdateCommentDTO commentDTO)
    {
        CommentEntity? comment = await _commentRepository.GetByIdAsync(commentId);
        if (comment == null) return false;

        comment.UpdateEntity(commentDTO);
        await _commentRepository.UpdateAsync(comment);
        return true;
    }

    public async Task<bool> DeleteAsync(int commentId)
    {
        return await _commentRepository.DeleteAsync(commentId);
    }
}