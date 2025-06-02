using backend.Interfaces.IRepositories;
using backend.Extansions;
using backend.Interfaces.IServices;
using backend.DTOs.PublisherDTOs;

namespace backend.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<List<GetPublsiherDTO>> GetPublishers()
    {
        return (await _publisherRepository.GetPublishers()).Select(p => p.ToDTO()).ToList();
    }
}