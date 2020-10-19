using System.Collections.Generic;
using System.IO;
using dms_api.Dtos.Drive;
using dms_api.Models;

namespace dms_api.Services.DriveService
{
    public class DriveService : IDriveService
    {
        private DriveInfo[] driveList = DriveInfo.GetDrives();

        private static List<GetLogicalDriveDto> drives = new List<GetLogicalDriveDto>();
        public ServiceResponse<List<GetLogicalDriveDto>> GetLogicalDrive()
        {
            ServiceResponse<List<GetLogicalDriveDto>> serviceResponse = new ServiceResponse<List<GetLogicalDriveDto>>();
            
            foreach (DriveInfo d in driveList)
            {
                if(d.IsReady)
                {
                    drives.Add(new GetLogicalDriveDto{
                        Name = d.Name,
                        DriveFormat = d.DriveFormat,
                        VolumeLabel = d.VolumeLabel,
                        TotalSize = d.TotalSize,
                        FreeSpace =d.AvailableFreeSpace
                    });
                }
            }
            serviceResponse.Data = drives;

            return serviceResponse;
        }
    }
}