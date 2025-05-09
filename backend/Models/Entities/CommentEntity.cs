namespace backend.Models.Entities;

public class CommentEntity
{
    public required int Id { get; set; }
    public required int UserId { get; set; }
    public required int ReviewId { get; set; }
    public required string Content { get; set; }
    public required DateTime Date { get; set; }
    public int Rating { get; set; }

    public ReviewEntity Review { get; set; } = null!;
    public List<VoteCommentEntity> VotesComment { get; set; } = new List<VoteCommentEntity>();
    public UserEntity User { get; set; } = null!;
}