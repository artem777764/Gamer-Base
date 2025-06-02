using backend.Models.Entities;

namespace backend.Interfaces.IRepositories;

public interface IPublisherRepository
{
    Task<List<PublisherEntity>> GetPublishers();
}
