namespace backend.DTOs.PublisherDTOs;

public record GetPublsiherDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}