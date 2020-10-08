using System.Collections.Generic;
using dms_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectoryController : ControllerBase
    {
        private static List<Directory> directories = new List<Directory>();

        [Route("All")]
        public IActionResult Get()
        {
            return Ok(directories);
        }

        [HttpGet("{id}")]
        public IActionResult GetDirectoryById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(Directory newDirectory)
        {
            directories.Add(newDirectory);

            return Ok(directories);
        }

    }
}