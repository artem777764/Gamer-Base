using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class PlatformRepository : IPlatformRepository
{
    private readonly PostgresDbContext _postgresDb;

    public PlatformRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task<List<PlatformEntity>> GetPlatforms()
    {
        return await _postgresDb.Platforms.ToListAsync();
    }
}