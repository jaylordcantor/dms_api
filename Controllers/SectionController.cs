using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Section;
using dms_api.Models;
using dms_api.Services.SectionService;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;
        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;

        }

        [HttpPost("api/post")]
        public async Task<IActionResult> Add(AddSectionDto newSection)
        {
            return Ok(await _sectionService.AddSection(newSection));
        }

        [HttpDelete("api/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetSectionDto>> response = await _sectionService.DeleteSection(id);

            return Ok(response);
        }

        [HttpGet("api/get/all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sectionService.GetAllSection());
        }

        [HttpGet("api/get/department/{id}")]
        public async Task<IActionResult> GetByDepartmentId(int id)
        {
            return Ok(await _sectionService.GetSectionByDepartmentId(id));
        }

        [HttpGet("api/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _sectionService.GetSectionById(id));
        }

        [HttpPut("api/put")]
        public async Task<IActionResult> Update(UpdateSectionDto updatedSection)
        {

            ServiceResponse<GetSectionDto> response = await _sectionService.UpdateSection(updatedSection);

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(await _sectionService.UpdateSection(updatedSection));
        }
    }
}