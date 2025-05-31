using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IVoteRepository
{
    Task AddVotesCommentsAsync(int userId, List<VoteCommentEntity> voteComments);
    Task AddVotesReviewsAsync(int userId, List<VoteReviewEntity> voteReviews);
}
