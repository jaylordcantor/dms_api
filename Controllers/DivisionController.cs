using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dms_api.Dtos.Division;
using dms_api.Models;
using dms_api.Services.DivisionService;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionService _divisionService;
        public DivisionController(IDivisionService divisionService)
        {
            _divisionService = divisionService;

        }

        [HttpPost("api/post")]
        public async Task<IActionResult> Add(AddDivisionDto newDivision)
        {
            return Ok(await _divisionService.AddDivision(newDivision));
        }

        [HttpDelete("api/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetDivisionDto>> response = await _divisionService.DeleteDivision(id);

            return Ok();
        }

        [HttpGet("api/get/All")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _divisionService.GetAllDivision());
        }

        [HttpGet("api/get/{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _divisionService.GetDivisionById(id));
        }

        [HttpPut("api/put")]
        public async Task<IActionResult> Update(UpdateDivisionDto updatedDivision)
        {
            ServiceResponse<GetDivisionDto> response = await _divisionService.UpdateDivision(updatedDivision);

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(await _divisionService.UpdateDivision(updatedDivision));
        }
    }
}