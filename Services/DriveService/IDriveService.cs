using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using dms_api.Dtos.Drive;
using dms_api.Models;

namespace dms_api.Services.DriveService
{
    public interface IDriveService
    {
        ServiceResponse<List<GetLogicalDriveDto>> GetLogicalDrive();
    }
}