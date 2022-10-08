using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Profiles
{
    public class HostelProfile : Profile
    {
        public HostelProfile()
        {
            CreateMap<Hostel, HostelDto>();
            CreateMap<Hostel, HostelUpdateDto>();
            CreateMap<HostelUpdateDto, Hostel>();
        }
    }
}
