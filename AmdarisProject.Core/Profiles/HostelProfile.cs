using AmdarisProject.Common.Dtos;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Profiles
{
    public class HostelProfile : Profile
    {
        public HostelProfile()
        {
            CreateMap<Hostel, HostelDto>();
        }
    }
}
