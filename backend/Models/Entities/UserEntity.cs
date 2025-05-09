namespace backend.Models.Entities;

public class UserEntity
{
    public required int Id { get; set; }
    public required string Email { get; set; }
    public required string HashPassword { get; set; }

    public UserDataEntity UserData { get; set; } = null!;
    public List<FavouriteGames> FavouriteGames { get; set; } = new List<FavouriteGames>();
    public List<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
    public List<VoteReviewEntity> VotesReview { get; set; } = new List<VoteReviewEntity>();
    public List<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    public List<VoteCommentEntity> VoteComments { get; set; } = new List<VoteCommentEntity>();
    public List<NotificationEntity> NotificationsUser { get; set; } = new List<NotificationEntity>();
    public List<NotificationEntity> NotificationsInitiatorUser { get; set; } = new List<NotificationEntity>();
}