using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IPlatformRepository
{
    Task<List<PlatformEntity>> GetPlatforms();
}
