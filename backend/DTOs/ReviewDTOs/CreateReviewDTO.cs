namespace backend.DTOs.ReviewDTOs;

public record CreateReviewDTO
{
    public required int GameId { get; set; }
    public required int AuthorId { get; set; }
    public required double Mark { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
}