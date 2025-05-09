namespace backend.Models.Entities;

public class ReviewEntity
{
    public required int Id { get; set; }
    public required int GameId { get; set; }
    public required int AuthorId { get; set; }
    public required double Mark { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required DateTime Date { get; set; }
    public int Rating { get; set; }

    public GameEntity Game { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public List<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    public List<VoteReviewEntity> VotesReview { get; set; } = new List<VoteReviewEntity>();
    public List<NotificationEntity> Notifications { get; set; } = new List<NotificationEntity>();
}