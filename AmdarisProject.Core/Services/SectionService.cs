using AmdarisProject.Common.Dtos.Section;
using AmdarisProject.Common.Exeptions;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Services
{
    public class SectionService : ISectionService
    {
        private readonly IRepository<Section> _repository;
        private readonly IMapper _mapper;

        public SectionService(IRepository<Section> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<SectionDto>> GetSectionsAsync()
        {
            var sections = await _repository.GetAllAsync();

            return _mapper.Map<IList<Section>, IList<SectionDto>>(sections);
        }

        public async Task<SectionDto> GetSectionByIdAsync(int id)
        {
            var section = await _repository.GetByIdAsync(id);

            if (section is null)
            {
                throw new NotFoundException("Section isn't exists.");
            }

            return _mapper.Map<Section, SectionDto>(section);
        }

        public async Task<SectionDto> CreateSectionAsync(SectionUpdateDto sectionUpdateDto)
        {
            var section = _mapper.Map<Section>(sectionUpdateDto);

            await _repository.CreateAsync(section);
            await _repository.SaveChangesAsync();

            return _mapper.Map<Section, SectionDto>(section);
        }

        public async Task<SectionDto> UpdateSectionAsync(int id, SectionUpdateDto sectionUpdateDto)
        {
            var section = await _repository.GetByIdAsync(id);

            if (section is null)
            {
                throw new NotFoundException("Section isn't exists.");
            }

            _mapper.Map(sectionUpdateDto, section);
            await _repository.SaveChangesAsync();

            return _mapper.Map<Section, SectionDto>(section);
        }

        public async Task DeleteSectionAsync(int id)
        {
            var section = await _repository.GetByIdAsync(id);

            if (section is null) throw new NotFoundException("Section isn't exists.");

            await _repository.DeleteByIdAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
