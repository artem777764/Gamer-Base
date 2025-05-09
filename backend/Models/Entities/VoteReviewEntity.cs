using Microsoft.Extensions.Configuration.UserSecrets;

namespace backend.Models.Entities;

public class VoteReviewEntity
{
    public required int UserId { get; set; }
    public required int ReviewId { get; set; }
    public required int Vote { get; set; }

    public ReviewEntity Review { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
}