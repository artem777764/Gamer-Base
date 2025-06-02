using backend.Interfaces.IRepositories;
using backend.Models;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly PostgresDbContext _postgresDb;

    public PublisherRepository(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
    }

    public async Task<List<PublisherEntity>> GetPublishers()
    {
        return await _postgresDb.Publishers.ToListAsync();
    }
}