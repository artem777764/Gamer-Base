using backend.DTOs.DeveloperDTOs;

namespace backend.Interfaces.IServices;

public interface IDeveloperService
{
    Task<List<GetDeveloperDTO>> GetDevelopers();
}
