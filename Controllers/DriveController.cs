using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using dms_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriveController:ControllerBase
    {
        private DriveInfo[] driveList = DriveInfo.GetDrives();

        private List<Drive> drives = new List<Drive>();

        [Route("GetAll")]
        public IActionResult Get()
        {
            foreach (DriveInfo d in driveList)
            {
                if(d.IsReady)
                {
                    drives.Add(new Drive{
                        Name = d.Name,
                        DriveFormat = d.DriveFormat,
                        VolumeLabel = d.VolumeLabel
                    });
                }
            }

            return Ok(drives);
        }
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok();
        }

    }
}