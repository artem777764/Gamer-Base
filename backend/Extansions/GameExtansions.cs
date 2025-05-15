using backend.DTOs.CommentDTOs;
using backend.DTOs.GameDTOs;
using backend.Models.Entities;

namespace backend.Extansions;

public static class GameExtansions
{
    public static GetGameDTO ToDTO(this GameEntity entity)
    {
        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Genres = entity.GameGenres.Select(gg => gg.Genre.Name).ToList(),
            Developer = entity.Developer.Name,
            Publisher = entity.Publisher.Name,
            ReleaseDate = entity.ReleaseDate,
        };
    }
}