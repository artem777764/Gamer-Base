using backend.DTOs.VoteDTOs;

namespace backend.Interfaces.IServices;

public interface IVoteService
{
    Task AddVotes(int userId, List<VoteDTO> voteDTOs);
}
