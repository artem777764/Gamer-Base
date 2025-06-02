using backend.Interfaces.IRepositories;
using backend.Extansions;
using backend.Interfaces.IServices;
using backend.DTOs.PlatformDTOs;

namespace backend.Services;

public class PlatformService : IPlatformService
{
    private readonly IPlatformRepository _platformRepository;

    public PlatformService(IPlatformRepository platformRepository)
    {
        _platformRepository = platformRepository;
    }

    public async Task<List<GetPlatformDTO>> GetPlatforms()
    {
        return (await _platformRepository.GetPlatforms()).Select(p => p.ToDTO()).ToList();
    }
}