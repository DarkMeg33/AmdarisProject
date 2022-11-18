using AmdarisProject.Api.Infrastructure.Configurations;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AmdarisProject.Api.Controllers
{
    [Route("api/images")]
    public class ImageController : AppControllerBase
    {
        private readonly IImageService _imageService;
        private readonly FileManagerOptions _fileManagerOptions;

        public ImageController(IOptions<FileManagerOptions> fileManagerOptions, IImageService imageService)
        {
            _imageService = imageService;
            _fileManagerOptions = fileManagerOptions.Value;
        }
        
        [HttpPost("{roomId}")]
        public async Task CreateImage([FromForm] IFormFile file, [FromRoute] int roomId)
        {
            await _imageService.CreateImageAsync(file, roomId, _fileManagerOptions.Path);
        }

        [HttpPut("{roomId}")]
        public async Task UpdateImage([FromForm] IFormFile file, [FromRoute] int roomId)
        {
            await _imageService.UpdateImageAsync(file, roomId, _fileManagerOptions.Path);
        }

        //[HttpDelete("{roomId}")]
        //public async Task DeleteImage([FromRoute] int roomId)
        //{
        //    await _imageService.DeleteImageAsync(roomId, _fileManagerOptions.Path);
        //}
    }
}
