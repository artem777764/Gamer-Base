namespace backend.DTOs.GameDTOs;

public record GetReviewWithComments
{
    public required int ReviewId { get; set; }
    public required int UserId { get; set; }
    public required string UserName { get; set; }
    public required double Mark { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required DateTime Date { get; set; }
    public required int Rating { get; set; }
    public List<GetCommentWithMarkDTO> Comments { get; set; } = new List<GetCommentWithMarkDTO>();
}