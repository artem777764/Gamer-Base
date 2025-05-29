namespace backend.DTOs.GameDTOs;

public record GetCommentWithMarkDTO
{
    public required int Id { get; set; }
    public required int UserId { get; set; }
    public string? UserImageURL { get; set; }
    public required string UserName { get; set; }
    public required string Content { get; set; }
    public required DateTime Date { get; set; }
    public required int Rating { get; set; }
    public double? UserMark { get; set; }
}