namespace backend.DTOs.ReviewDTOs;

public record UpdateReviewDTO
{
    public required double Mark { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
}