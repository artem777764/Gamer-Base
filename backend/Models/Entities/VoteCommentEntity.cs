namespace backend.Models.Entities;

public class VoteCommentEntity
{
    public required int UserId { get; set; }
    public required int CommentId { get; set; }
    public required int Vote { get; set; }

    public CommentEntity Comment { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
}