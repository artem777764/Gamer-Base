using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IDeveloperRepository
{
    Task<List<DeveloperEntity>> GetDevelopers();
}
