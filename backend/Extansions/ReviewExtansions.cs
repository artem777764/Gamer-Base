using backend.DTOs.ReviewDTOs;
using backend.DTOs.UserDTOs;
using backend.Models.Entities;
using Npgsql.Replication;

namespace backend.Extansions;

public static class ReviewExtansions
{
    public static ReviewEntity ToEntity(this CreateReviewDTO reviewDTO, int userId)
    {
        return new()
        {
            GameId = reviewDTO.GameId,
            AuthorId = userId,
            Mark = reviewDTO.Mark,
            Title = reviewDTO.Title,
            Content = reviewDTO.Content,
            Date = DateTime.UtcNow,
            Rating = 0,
        };
    }

    public static ReviewEntity UpdateEntity(this ReviewEntity entity, UpdateReviewDTO reviewDTO)
    {
        entity.Mark = reviewDTO.Mark;
        entity.Title = reviewDTO.Title;
        entity.Content = reviewDTO.Content;

        return entity;
    }

    public static GetReviewDTO ToDTO(this ReviewEntity entity)
    {
        return new()
        {
            Id = entity.Id,
            UserId = entity.AuthorId,
            UserName = entity.User.UserData.Login,
            Mark = entity.Mark,
            Title = entity.Title,
            Content = entity.Content,
            Date = entity.Date,
            Rating = entity.Rating,
        };
    }
}