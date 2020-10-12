using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Location;
using dms_api.Models;
using dms_api.Services.LocationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;

        }

        [HttpPost("api/post")]
        public async Task<IActionResult> Add(AddLocationDto newLocation)
        {
            return Ok(await _locationService.AddLocation(newLocation));
        }

        [HttpDelete("api/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetLocationDto>> response = await _locationService.DeleteLocation(id);
            return Ok(response);
        }

        [HttpGet("api/get/all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _locationService.GetAllLocation());
        }

        [HttpGet("api/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _locationService.GetLocationById(id));
        }

        [HttpPut("api/put")]
        public async Task<IActionResult> Update(UpdateLocationDto updatedLocation)
        {
            ServiceResponse<GetLocationDto> response = await _locationService.UpdateLocation(updatedLocation);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(await _locationService.UpdateLocation(updatedLocation));
        }
    }
}