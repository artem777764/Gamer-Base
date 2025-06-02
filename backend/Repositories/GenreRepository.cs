using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly PostgresDbContext _postgresDb;

    public GenreRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task<List<GenreEntity>> GetGenres()
    {
        return await _postgresDb.Genres.ToListAsync();
    }
}