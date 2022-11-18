using AmdarisProject.Common.Exeptions;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmdarisProject.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> _repository;

        public ImageService(IRepository<Image> repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task CreateImageAsync(IFormFile file, int roomId, string uploadPath)
        {
            var uniqueFileName = GetUniqueFileName(file.FileName);

            var relativePath = Path.Combine("rooms", roomId.ToString());

            var filePath = Path.Combine(relativePath, uniqueFileName);

            var fullPath = Path.Combine(uploadPath, filePath);

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            await _repository.CreateAsync(new Image()
            {
                Id = roomId,
                Path = filePath
            });
        }

        public async Task UpdateImageAsync(IFormFile file, int roomId, string uploadPath)
        {
            var existingImage = await _repository.GetByIdAsync(roomId);

            if (existingImage is null) throw new NotFoundException("Image isn't exists.");

            File.Delete(Path.Combine(uploadPath, existingImage.Path));

            await _repository.DeleteByIdAsync(roomId);

            await CreateImageAsync(file, roomId, uploadPath);
        }

        public async Task DeleteImageAsync(int roomId, string uploadPath)
        {
            var image = await _repository.GetByIdAsync(roomId);

            if (image is null) throw new NotFoundException("Image isn't exists.");

            File.Delete(Path.Combine(uploadPath, image.Path));
        }

        public string GetUniqueFileName(string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                "_",
                Guid.NewGuid().ToString().AsSpan(0, 4),
                Path.GetExtension(fileName));
        }
    }
}
