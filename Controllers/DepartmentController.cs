using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Department;
using dms_api.Models;
using dms_api.Services.DepartmentService;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("api/post")]
        public async Task<IActionResult> Add(AddDepartmentDto newDepartment)
        {
            return Ok(await _departmentService.AddDepartment(newDepartment));
        }

        [HttpDelete("api/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetDepartmentDto>> response = await _departmentService.DeleteDepartment(id);

            return Ok(response);
        }

        [HttpGet("api/get/all")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _departmentService.GetAllDepartment());
        }

        [HttpGet("api/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _departmentService.GetDepartmentById(id));
        }

        [HttpPut("api/put")]
        public async Task<IActionResult> Update(UpdateDepartmentDto updatedDepartment)
        {
            ServiceResponse<GetDepartmentDto> response = await _departmentService.UpdateDepartment(updatedDepartment);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(await _departmentService.UpdateDepartment(updatedDepartment));
        }
    }
}