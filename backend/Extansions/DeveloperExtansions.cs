using backend.DTOs.DeveloperDTOs;
using backend.Models.Entities;

namespace backend.Extansions;

public static class DeveloperExtansions
{
    public static GetDeveloperDTO ToDTO(this DeveloperEntity developer)
    {
        return new()
        {
            Id = developer.Id,
            Name = developer.Name,
        };
    }
}