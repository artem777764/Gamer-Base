using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IGenreRepository
{
    Task<List<GenreEntity>> GetGenres();
}
