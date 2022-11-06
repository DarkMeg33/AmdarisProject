using AmdarisProject.Common.Dtos.Section;

namespace AmdarisProject.Core.Interfaces
{
    public interface ISectionService
    {
        Task<IList<SectionDto>> GetSectionsAsync();
        Task<SectionDto> GetSectionByIdAsync(int id);
        Task<SectionDto> CreateSectionAsync(SectionUpdateDto sectionUpdateDto);
        Task<SectionDto> UpdateSectionAsync(int id, SectionUpdateDto sectionUpdateDto);
        Task DeleteSectionAsync(int id);
    }
}
