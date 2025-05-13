namespace backend.DTOs.CommentDTOs;

public record UpdateCommentDTO
{
    public required string Content { get; set; }
}