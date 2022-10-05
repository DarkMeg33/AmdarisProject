using AmdarisProject.Common.Dtos;
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
            throw new NotImplementedException();
        }

        public async Task CreateHostelAsync(HostelDto hostel)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateHostelAsync(HostelDto hostel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteHostelAsync(HostelDto hostel)
        {
            throw new NotImplementedException();
        }
    }
}
