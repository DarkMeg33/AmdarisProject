using Microsoft.AspNetCore.Http;

namespace AmdarisProject.Core.Interfaces
{
    public interface IImageService
    {
        Task CreateImageAsync(IFormFile file, int roomId, string uploadPath);

        Task UpdateImageAsync(IFormFile file, int roomId, string uploadPath);

        Task DeleteImageAsync(int roomId, string uploadPath);
    }
}
