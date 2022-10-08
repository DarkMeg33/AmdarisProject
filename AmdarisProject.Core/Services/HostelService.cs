using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Common.Exeptions;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Services
{
    public class HostelService : IHostelService
    {
        private readonly IRepository<Hostel> _repository;
        private readonly IMapper _mapper;

        public HostelService(IRepository<Hostel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<HostelDto>> GetHostelsAsync()
        {
            var hostels = await _repository.GetAllAsync();

            return hostels.Select(hostel => _mapper.Map<Hostel, HostelDto>(hostel)).ToList();
        }

        public async Task<HostelDto> GetHostelByIdAsync(int id)
        {
            var hostel = await _repository.GetByIdAsync(id);

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

            return _mapper.Map<Hostel, HostelDto>(hostel);
        }

        public async Task<HostelDto> UpdateHostelAsync(int id, HostelUpdateDto hostelUpdateDto)
        {
            var hostel = await _repository.GetByIdAsync(id);

            if (hostel is null)
            {
                throw new ArgumentException(); //TODO Change
            }

            _mapper.Map(hostelUpdateDto, hostel);
            await _repository.UpdateAsync(hostel);

            return _mapper.Map<Hostel, HostelDto>(hostel);
        }

        public async Task DeleteHostelAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}
