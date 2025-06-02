using backend.Interfaces.IRepositories;
using backend.Extansions;
using backend.Interfaces.IServices;
using backend.DTOs.DeveloperDTOs;

namespace backend.Services;

public class DeveloperService : IDeveloperService
{
    private readonly IDeveloperRepository _developerRepository;

    public DeveloperService(IDeveloperRepository developerRepository)
    {
        _developerRepository = developerRepository;
    }

    public async Task<List<GetDeveloperDTO>> GetDevelopers()
    {
        return (await _developerRepository.GetDevelopers()).Select(d => d.ToDTO()).ToList();
    }
}