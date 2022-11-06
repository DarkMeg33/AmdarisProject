using AmdarisProject.Common.Dtos.Floor;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Profiles
{
    public class FloorProfile : Profile
    {
        public FloorProfile()
        {
            CreateMap<Floor, FloorDto>();
            CreateMap<FloorUpdateDto, Floor>();
        }
    }
}
