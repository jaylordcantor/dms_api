using System.Threading.Tasks;
using dms_api.Dtos.FileDirectory;
using dms_api.Services.FileDirectoryService;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileDirectoryController : ControllerBase
    {
        private readonly IFileDirectoryService _fileDirectoryService;
        public FileDirectoryController(IFileDirectoryService fileDirectoryService)
        {
            _fileDirectoryService = fileDirectoryService;

        }

        [HttpPost("api/post")]
        public async Task<IActionResult> Add(AddFileDirectoryDto newFileDirectory)
        {
            return Ok(await _fileDirectoryService.AddFileDirectory(newFileDirectory));
        }

        [HttpGet("api/get/all")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _fileDirectoryService.GetAllFileDirectory());
        }

        [HttpGet("api/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _fileDirectoryService.GetFileDirectoryById(id));
        }

        [HttpGet("api/get/catalog/{id}")]
        public async Task<IActionResult> GetByCatalog(int id)
        {
            return Ok(await _fileDirectoryService.GetFileDirectoryByCatalog(id));
        }

        [HttpGet("api/parent/get/{id}")]
        public IActionResult GetByParentDirectory(int? id)
        {
            return Ok(_fileDirectoryService.GetFileDirectoryByParentId(id));
        }

        [HttpGet("api/root/get/{id}")]
        public async Task<IActionResult> GetByRootDirectory(int id)
        {
            return Ok(await _fileDirectoryService.GetFileDirectoryByRootDirectoryId(id));
        }

        [HttpGet("api/fileObject/get/{id}")]
        public async Task<IActionResult> GetFileObject(int id)
        {
            return Ok(await _fileDirectoryService.GetFileSystemObject(id));
        }
    }
}