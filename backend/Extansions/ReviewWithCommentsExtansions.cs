using backend.DTOs.CommentDTOs;
using backend.DTOs.ReviewDTOs;
using backend.DTOs.SocialActivityDTOs;

namespace backend.Extansions;

public static class ReviewWithCommentsExtansions
{
    public static GetReviewWithComments AddComments(this GetReviewDTO reviewDTO, List<GetCommentDTO> commentDTOs)
    {
        return new()
        {
            ReviewId = reviewDTO.Id,
            UserName = reviewDTO.UserName,
            Mark = reviewDTO.Mark,
            Title = reviewDTO.Title,
            Content = reviewDTO.Content,
            Date = reviewDTO.Date,
            Rating = reviewDTO.Rating,
            Comments = commentDTOs,
        };
    }
}