using backend.Interfaces.IRepositories;
using backend.Extansions;
using backend.DTOs.GenreDTOs;
using backend.Interfaces.IServices;

namespace backend.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<List<GetGenreDTO>> GetGenres()
    {
        return (await _genreRepository.GetGenres()).Select(g => g.ToDTO()).ToList();
    }
}