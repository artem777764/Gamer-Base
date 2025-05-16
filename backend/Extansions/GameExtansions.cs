using backend.DTOs.CommentDTOs;
using backend.DTOs.GameDTOs;
using backend.Models.Entities;
using MongoDB.Bson;

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

    public static GameEntity ToEntity(this CreateGameDTO dto, ObjectId? objectId)
    {
        return new()
        {
            Name = dto.Name,
            Description = dto.Description,
            DeveloperId = dto.DeveloperId,
            PublisherId = dto.PublisherId,
            ImageId = objectId?.ToString(),
            ReleaseDate = dto.ReleaseDate,
        };
    }

    public static List<GamePlatformsEntity> ToEntityPlatforms(this CreateGameDTO dto, int gameId)
    {
        return dto.GamePlatforms.Select(platformId => new GamePlatformsEntity
        {
            GameId = gameId,
            PlatformId = platformId,
        }).ToList();
    }

    public static List<GameGenresEntity> ToEntityGenres(this CreateGameDTO dto, int gameId)
    {
        return dto.GameGenres.Select(genreId => new GameGenresEntity
        {
            GameId = gameId,
            GenreId = genreId,
        }).ToList();
    }
}