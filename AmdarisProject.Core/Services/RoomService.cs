using AmdarisProject.Common.Dtos.Room;
using AmdarisProject.Common.Exeptions;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _repository;
        private readonly IMapper _mapper;

        public RoomService(IRepository<Room> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<RoomDto>> GetRoomsAsync()
        {
            var rooms = await _repository.GetAllAsync();

            return rooms.Select(room => _mapper.Map<Room, RoomDto>(room)).ToList();
        }

        public async Task<RoomDto> GetRoomByIdAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);

            if (room is null)
            {
                throw new NotFoundException("Room isn't exists.");
            }

            return _mapper.Map<Room, RoomDto>(room);
        }

        public async Task<RoomDto> CreateRoomAsync(RoomUpdateDto roomUpdateDto)
        {
            var room = _mapper.Map<Room>(roomUpdateDto);

            await _repository.CreateAsync(room);

            return _mapper.Map<Room, RoomDto>(room);
        }

        public async Task<RoomDto> UpdateRoomAsync(int id, RoomUpdateDto roomUpdateDto)
        {
            var room = await _repository.GetByIdAsync(id);

            if (room is null)
            {
                throw new NotFoundException("Room isn't exists.");
            }

            _mapper.Map(roomUpdateDto, room);
            await _repository.UpdateAsync(room);

            return _mapper.Map<Room, RoomDto>(room);
        }

        public async Task DeleteRoomAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);

            if (room is null) throw new NotFoundException("Room isn't exists.");

            await _repository.DeleteByIdAsync(id);
        }
    }
}
