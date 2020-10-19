using Microsoft.AspNetCore.Mvc;
using dms_api.Services.DriveService;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriveController : ControllerBase
    {
        private readonly IDriveService _driveService;
        public DriveController(IDriveService driveService)
        {
            _driveService = driveService;

        }

        [HttpGet("api/drives")]
        public IActionResult Get()
        {
            return Ok(_driveService.GetLogicalDrive());
        }

    }
}