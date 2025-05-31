using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class VoteRepository : IVoteRepository
{
    private readonly PostgresDbContext _postgresDb;

    public VoteRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task AddVotesCommentsAsync(int userId, List<VoteCommentEntity> voteComments)
    {
        List<int> commentIds = voteComments.Select(v => v.CommentId)
                                           .ToList();
        List<VoteCommentEntity> existingVotes = await _postgresDb.VotesComment.Where(v => v.UserId == userId && commentIds.Contains(v.CommentId))
                                                          .ToListAsync();

        _postgresDb.VotesComment.RemoveRange(existingVotes);
        await _postgresDb.VotesComment.AddRangeAsync(voteComments);
        await _postgresDb.SaveChangesAsync();
    }

    public async Task AddVotesReviewsAsync(int userId, List<VoteReviewEntity> voteReviews)
    {
        List<int> reviewIds = voteReviews.Select(r => r.ReviewId)
                                         .ToList();
        List<VoteReviewEntity> existingVotes = await _postgresDb.VotesReview.Where(r => r.UserId == userId && reviewIds.Contains(r.ReviewId))
                                                                            .ToListAsync();

        _postgresDb.VotesReview.RemoveRange(existingVotes);
        await _postgresDb.VotesReview.AddRangeAsync(voteReviews);
        await _postgresDb.SaveChangesAsync();
    }
}