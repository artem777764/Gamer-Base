using backend.DTOs.GenreDTOs;
using backend.Models.Entities;

namespace backend.Extansions;

public static class GenreExtansions
{
    public static GetGenreDTO ToDTO(this GenreEntity genre)
    {
        return new()
        {
            Id = genre.Id,
            Name = genre.Name,
        };
    }
}