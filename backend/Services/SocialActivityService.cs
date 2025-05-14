using backend.DTOs.CommentDTOs;
using backend.DTOs.ReviewDTOs;
using backend.DTOs.SocialActivityDTOs;
using backend.Extansions;
using backend.Interfaces.IServices;

namespace backend.Services;

public class SocialActivityService : ISocialActivityService
{
    private readonly IReviewService _reviewService;
    private readonly ICommentService _commentService;
    public SocialActivityService(IReviewService reviewService, ICommentService commentService)
    {
        _reviewService = reviewService;
        _commentService = commentService;
    }

    public async Task<List<GetReviewWithComments>?> GetActivityByGameAsync(int gameId)
    {
        List<GetReviewWithComments> reviewWithCommentsDTOs = new List<GetReviewWithComments>();
        List<GetReviewDTO> reviewDTOs = await _reviewService.GetByGameAsync(gameId);
        
        foreach(GetReviewDTO reviewDTO in reviewDTOs)
        {
            List<GetCommentDTO> commentDTOs = await _commentService.GetByReviewAsync(reviewDTO.Id);
            reviewWithCommentsDTOs.Add(reviewDTO.AddComments(commentDTOs));
        }

        return reviewWithCommentsDTOs;
    }
}