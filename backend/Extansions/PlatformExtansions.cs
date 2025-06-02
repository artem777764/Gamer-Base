using backend.DTOs.PlatformDTOs;
using backend.Models.Entities;

namespace backend.Extansions;

public static class PlatformExtansions
{
    public static GetPlatformDTO ToDTO(this PlatformEntity platform)
    {
        return new()
        {
            Id = platform.Id,
            Name = platform.Name,
        };
    }
}