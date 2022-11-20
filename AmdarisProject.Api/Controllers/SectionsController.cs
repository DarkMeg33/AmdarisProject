using AmdarisProject.Common.Dtos.Section;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmdarisProject.Api.Controllers
{
    [Route("api/sections")]
    public class SectionsController : AppControllerBase
    {
        //TODO Handle all ways, add new api exceptions
        private readonly ISectionService _sectionService;

        public SectionsController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSections()
        {
            var sections = await _sectionService.GetSectionsAsync();

            return Ok(sections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSection(int id)
        {
            var section = await _sectionService.GetSectionByIdAsync(id);

            return Ok(section);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateSection([FromBody] SectionUpdateDto sectionUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var section = await _sectionService.CreateSectionAsync(sectionUpdateDto);

            return CreatedAtAction(nameof(GetSection), new { id = section.Id }, section);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateSection(int id, [FromBody] SectionUpdateDto sectionUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sectionService.UpdateSectionAsync(id, sectionUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            await _sectionService.DeleteSectionAsync(id);
            return NoContent();
        }
    }
}
