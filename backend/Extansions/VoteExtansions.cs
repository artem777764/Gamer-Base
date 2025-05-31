using backend.DTOs.VoteDTOs;
using backend.Models.Entities;

namespace backend.Extansions;

public static class VoteExtansions
{
    public static VoteCommentEntity ToCommentEntity(this VoteDTO dto, int userId)
    {
        return new()
        {
            UserId = userId,
            CommentId = dto.EntityId,
            Vote = dto.Mark,
        };
    }

    public static VoteReviewEntity ToReviewEntity(this VoteDTO dto, int userId)
    {
        return new()
        {
            UserId = userId,
            ReviewId = dto.EntityId,
            Vote = dto.Mark,
        };
    }
}