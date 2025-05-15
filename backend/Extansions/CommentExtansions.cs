using backend.DTOs.CommentDTOs;
using backend.Models.Entities;

namespace backend.Extansions;

public static class CommentExtansions
{
    public static GetCommentDTO ToDTO(this CommentEntity entity)
    {
        return new()
        {
            Id = entity.Id,
            UserId = entity.UserId,
            UserName = entity.User.UserData.Login,
            Content = entity.Content,
            Date = entity.Date,
            Rating = entity.Rating,
        };
    }

    public static CommentEntity ToEntity(this CreateCommentDTO dto)
    {
        return new()
        {
            UserId = dto.AuthorId,
            ReviewId = dto.ReviewId,
            Content = dto.Content,
            Date = DateTime.UtcNow,
            Rating = 0,
        };
    }

    public static CommentEntity UpdateEntity(this CommentEntity entity, UpdateCommentDTO commentDTO)
    {
        entity.Content = commentDTO.Content;

        return entity;
    }
}