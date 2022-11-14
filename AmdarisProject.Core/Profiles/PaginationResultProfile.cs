using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Common.Models;
using AmdarisProject.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AmdarisProject.Core.Profiles
{
    public class PaginationResultProfile : Profile
    {
        public PaginationResultProfile()
        {
            CreateMap<PaginationResult<Hostel>, PaginationResult<HostelDto>>();
        }
    }
}
