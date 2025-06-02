using backend.DTOs.PublisherDTOs;

namespace backend.Interfaces.IServices;

public interface IPublisherService
{
    Task<List<GetPublsiherDTO>> GetPublishers();
}
