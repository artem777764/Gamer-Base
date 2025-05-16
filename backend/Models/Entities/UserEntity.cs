namespace backend.Models.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string HashPassword { get; set; }
    public required int RoleId { get; set; }

    public UserDataEntity UserData { get; set; } = null!;
    public RoleEntity Role { get; set; } = null!;
    public List<FavouriteGamesEntity> FavouriteGames { get; set; } = new List<FavouriteGamesEntity>();
    public List<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
    public List<VoteReviewEntity> VotesReview { get; set; } = new List<VoteReviewEntity>();
    public List<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    public List<VoteCommentEntity> VoteComments { get; set; } = new List<VoteCommentEntity>();
    public List<NotificationEntity> NotificationsUser { get; set; } = new List<NotificationEntity>();
    public List<NotificationEntity> NotificationsInitiatorUser { get; set; } = new List<NotificationEntity>();
}