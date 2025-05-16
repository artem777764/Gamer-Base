using MongoDB.Bson;

namespace backend.Interfaces.IServices;

public interface IImageService
{
    Task<ObjectId?> Upload(string path);
    Task<FileDownloadResult?> Download(string fileId);
}