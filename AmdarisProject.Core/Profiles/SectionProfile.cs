using AmdarisProject.Common.Dtos.Section;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Profiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionDto>();
            CreateMap<SectionUpdateDto, Section>();
        }
    }
}
