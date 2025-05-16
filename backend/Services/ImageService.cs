using backend.Interfaces.IRepositories;
using backend.Interfaces.IServices;
using MongoDB.Bson;

namespace backend.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<ObjectId?> Upload(string path)
    {
        if (!System.IO.File.Exists(path)) return null;

        using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            return await _imageRepository.UploadAsync(stream, Path.GetFileName(path));
        }
    }

    public async Task<FileDownloadResult?> Download(string fileId)
    {
        return await _imageRepository.DownloadAsync(fileId);
    }
}