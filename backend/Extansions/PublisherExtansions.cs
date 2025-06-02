using backend.DTOs.PublisherDTOs;
using backend.Models.Entities;

namespace backend.Extansions;

public static class PublisherExtansions
{
    public static GetPublsiherDTO ToDTO(this PublisherEntity publisher)
    {
        return new()
        {
            Id = publisher.Id,
            Name = publisher.Name,
        };
    }
}