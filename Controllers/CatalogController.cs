using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Catalog;
using dms_api.Models;
using dms_api.Services.CatalogService;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;

        }

        [HttpPost("api/post")]
        public async Task<IActionResult> Add(AddCatalogDto newCatalog)
        {
            return Ok(await _catalogService.AddCatalog(newCatalog));
        }

        [HttpDelete("api/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetCatalogDto>> response = await _catalogService.DeleteCatalog(id);

            return Ok(response);
        }

        [HttpGet("api/get/all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _catalogService.GetAllCatalog());
        }

        [HttpGet("api/get/department/{id}")]
        public async Task<IActionResult> GetByDepartmentId(int id)
        {
            return Ok(await _catalogService.GetCatalogByDepartment(id));
        }

        [HttpGet("api/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _catalogService.GetCatalogById(id));
        }

        [HttpGet("api/get/section/{id}")]
        public async Task<IActionResult> GetBySectionId(int id)
        {
            return Ok(await _catalogService.GetCatalogBySection(id));
        }

        [HttpPut("api/put")]
        public async Task<IActionResult> Update(UpdateCatalogDto updatedCatalogDto)
        {
            ServiceResponse<GetCatalogDto> response = await _catalogService.UpdateCatalog(updatedCatalogDto);

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(await _catalogService.UpdateCatalog(updatedCatalogDto));
        }
    }
}