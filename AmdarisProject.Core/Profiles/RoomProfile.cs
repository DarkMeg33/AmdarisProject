using AmdarisProject.Common.Dtos.Room;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>();
            CreateMap<RoomUpdateDto, Room>();
        }
    }
}
