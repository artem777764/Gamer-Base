namespace backend.DTOs.CommentDTOs;

public record GetCommentDTO
{
    public required int Id { get; set; }
    public required string UserName { get; set; }
    public required string Content { get; set; }
    public required DateTime Date { get; set; }
    public required int Rating { get; set; }
}