using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Common.Exeptions;
using AmdarisProject.Common.Models;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Services
{
    public class HostelService : IHostelService
    {
        private readonly IHostelRepository _repository;
        private readonly IMapper _mapper;

        public HostelService(IHostelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<HostelDto>> GetHostelsAsync()
        {
            var hostels = await _repository.GetAllHostelsWithIncludeAsync();

            return _mapper.Map<IList<Hostel>, IList<HostelDto>>(hostels);
        }

        public async Task<PaginationResult<HostelDto>> GetPaginatedHostelsAsync(PaginationRequest paginationRequest)
        {
            var hostelsPaginationResult = await _repository.GetAllHostelsWithPaginate(paginationRequest);
            return _mapper.Map<PaginationResult<Hostel>, PaginationResult<HostelDto>>(hostelsPaginationResult);
        }

        public async Task<HostelDto> GetHostelByIdAsync(int id)
        {
            var hostel = await _repository.GetHostelByIdWithIncludeAsync(id);

            if (hostel is null)
            {
                throw new NotFoundException("Hostel isn't exists.");
            }

            return _mapper.Map<Hostel, HostelDto>(hostel);
        }

        public async Task<HostelDto> CreateHostelAsync(HostelUpdateDto hostelUpdateDto)
        {
            var hostel = _mapper.Map<Hostel>(hostelUpdateDto);

            await _repository.CreateAsync(hostel);
            await _repository.SaveChangesAsync();

            return _mapper.Map<Hostel, HostelDto>(hostel);
        }

        public async Task<HostelDto> UpdateHostelAsync(int id, HostelUpdateDto hostelUpdateDto)
        {
            var hostel = await _repository.GetByIdAsync(id);

            if (hostel is null)
            {
                throw new NotFoundException("Hostel isn't exists.");
            }

            _mapper.Map(hostelUpdateDto, hostel);
            await _repository.UpdateAsync(hostel);
            await _repository.SaveChangesAsync();

            return _mapper.Map<Hostel, HostelDto>(hostel);
        }

        public async Task DeleteHostelAsync(int id)
        {
            var hostel = await _repository.GetByIdAsync(id);

            if (hostel is null) throw new NotFoundException("Hostel isn't exists.");

            await _repository.DeleteByIdAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
