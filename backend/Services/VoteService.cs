using backend.DTOs.VoteDTOs;
using backend.Interfaces.IRepositories;
using backend.Models.Entities;
using backend.Extansions;
using backend.Interfaces.IServices;

namespace backend.Services;

public class VoteService : IVoteService
{
    private readonly IVoteRepository _voteRepository;

    public VoteService(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }

    public async Task AddVotes(int userId, List<VoteDTO> voteDTOs)
    {
        List<VoteCommentEntity> voteComments = voteDTOs.Where(v => v.Type.Equals("comment", StringComparison.OrdinalIgnoreCase))
                                                       .Select(v => v.ToCommentEntity(userId))
                                                       .ToList();
        await _voteRepository.AddVotesCommentsAsync(userId, voteComments);

        List<VoteReviewEntity> voteReviews = voteDTOs.Where(v => v.Type.Equals("review", StringComparison.OrdinalIgnoreCase))
                                                     .Select(v => v.ToReviewEntity(userId))
                                                     .ToList();
        await _voteRepository.AddVotesReviewsAsync(userId, voteReviews);
    }
}