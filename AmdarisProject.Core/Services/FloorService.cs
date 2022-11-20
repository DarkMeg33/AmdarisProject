using AmdarisProject.Common.Dtos.Floor;
using AmdarisProject.Common.Exeptions;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Services
{
    public class FloorService : IFloorService
    {
        private readonly IRepository<Floor> _repository;
        private readonly IMapper _mapper;

        public FloorService(IRepository<Floor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<FloorDto>> GetFloorsAsync()
        {
            var floors = await _repository.GetAllAsync();

            return _mapper.Map<IList<Floor>, IList<FloorDto>>(floors);
        }

        public async Task<FloorDto> GetFloorByIdAsync(int id)
        {
            var floor = await _repository.GetByIdAsync(id);

            if (floor is null)
            {
                throw new NotFoundException("Floor isn't exists.");
            }

            return _mapper.Map<Floor, FloorDto>(floor);
        }

        public async Task<FloorDto> CreateFloorAsync(FloorUpdateDto floorUpdateDto)
        {
            var floor = _mapper.Map<Floor>(floorUpdateDto);

            await _repository.CreateAsync(floor);
            await _repository.SaveChangesAsync();

            return _mapper.Map<Floor, FloorDto>(floor);
        }

        public async Task<FloorDto> UpdateFloorAsync(int id, FloorUpdateDto floorUpdateDto)
        {
            var floor = await _repository.GetByIdAsync(id);

            if (floor is null)
            {
                throw new NotFoundException("Floor isn't exists.");
            }

            _mapper.Map(floorUpdateDto, floor);
            await _repository.SaveChangesAsync();

            return _mapper.Map<Floor, FloorDto>(floor);
        }

        public async Task DeleteFloorAsync(int id)
        {
            var floor = await _repository.GetByIdAsync(id);

            if (floor is null) throw new NotFoundException("Floor isn't exists.");

            await _repository.DeleteByIdAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
