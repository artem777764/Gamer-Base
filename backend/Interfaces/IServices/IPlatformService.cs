using backend.DTOs.PlatformDTOs;

namespace backend.Interfaces.IServices;

public interface IPlatformService
{
    Task<List<GetPlatformDTO>>GetPlatforms();
}
