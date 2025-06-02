using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class DeveloperRepository : IDeveloperRepository
{
    private readonly PostgresDbContext _postgresDb;

    public DeveloperRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task<List<DeveloperEntity>> GetDevelopers()
    {
        return await _postgresDb.Developers.ToListAsync();
    }
}