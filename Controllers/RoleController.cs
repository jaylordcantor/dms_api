using System.Threading.Tasks;
using dms_api.Services.RoleService;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("api/get/all")]
        public IActionResult GetAll()
        {
            return Ok(_roleService.GetRole());
        }
    }
}