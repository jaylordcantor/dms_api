using System.Threading.Tasks;
using dms_api.Dtos.RootDirectory;
using dms_api.Services.RootDirectoryService;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RootDirectoryController : ControllerBase
    {
        private readonly IRootDirectoryService _rootDirectoryService;
        public RootDirectoryController(IRootDirectoryService rootDirectoryService)
        {
            _rootDirectoryService = rootDirectoryService;

        }

        [HttpPost("api/post")]
        public async Task<IActionResult> Add(AddRootDirectoryDto newRootDirectory)
        {
            return Ok(await _rootDirectoryService.AddRootDirectory(newRootDirectory));
        }

        [HttpGet("api/get/all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rootDirectoryService.GetAllRootDirectory());
        }

        [HttpGet("api/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _rootDirectoryService.GetRootDirectoryById(id));
        }
    }
}