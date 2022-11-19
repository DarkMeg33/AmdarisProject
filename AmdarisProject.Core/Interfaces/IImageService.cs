using AmdarisProject.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmdarisProject.Core.Interfaces
{
    public interface IImageService
    {
        Task<ImageToReturn> GetImageAsync(int roomId, string uploadPath);
        Task CreateImageAsync(IFormFile file, int roomId, string uploadPath);
        Task UpdateImageAsync(IFormFile file, int roomId, string uploadPath);
        Task DeleteImageAsync(int roomId, string uploadPath);
    }
}
