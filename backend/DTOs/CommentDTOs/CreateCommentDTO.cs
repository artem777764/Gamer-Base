namespace backend.DTOs.CommentDTOs;

public record CreateCommentDTO
{
    public required int AuthorId { get; set; }
    public required int ReviewId { get; set; }
    public required string Content { get; set; }
}