using backend.DTOs.ReviewDTOs;
using backend.Models.Entities;
using Npgsql.Replication;

namespace backend.Extansions;

public static class ReviewExtansions
{
    public static ReviewEntity ToEntity(this CreateReviewDTO reviewDTO)
    {
        return new()
        {
            GameId = reviewDTO.GameId,
            AuthorId = reviewDTO.AuthorId,
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
            UserName = entity.User.UserData.Login,
            Mark = entity.Mark,
            Title = entity.Title,
            Content = entity.Content,
            Date = entity.Date,
            Rating = entity.Rating,
        };
    }
}