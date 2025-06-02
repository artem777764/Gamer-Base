using backend.DTOs.GenreDTOs;

namespace backend.Interfaces.IServices;

public interface IGenreService
{
    Task<List<GetGenreDTO>> GetGenres();
}
