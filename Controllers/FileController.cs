using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace dms_api.Controllers
{
    public class FileController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<FileController> _logger;
        public FileController(IConfiguration config, ILogger<FileController> logger)
        {
            _logger = logger;
            _config = config;

        }

        [HttpGet("api/files/pdf")]
        public IActionResult GetPdf(string filename = "ot.pdf",string directory="")
        {
            using (var provider = new PhysicalFileProvider(Path.Combine(_config["BasePath"],directory)))
            {
                var stream = provider.GetFileInfo(filename).CreateReadStream();
                return File(stream,"application/pdf");
            }
        }
    }
}