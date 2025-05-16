using MongoDB.Bson;

namespace backend.Interfaces.IRepositories;

public interface IImageRepository
{
    Task<ObjectId> UploadAsync(Stream fileStream, string fileName, string? contentType = null);
    Task<FileDownloadResult?> DownloadAsync(string fileId);
}