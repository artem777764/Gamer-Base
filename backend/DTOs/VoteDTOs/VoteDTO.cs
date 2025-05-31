namespace backend.DTOs.VoteDTOs;

public record VoteDTO
{
    public required int EntityId { get; set; }
    public required string Type { get; set; }
    public required int Mark { get; set; }
}