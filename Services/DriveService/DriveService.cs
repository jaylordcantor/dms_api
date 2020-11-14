using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Dtos.Drive;
using dms_api.Models;

namespace dms_api.Services.DriveService
{
    public class DriveService : IDriveService
    {
        private readonly IMapper _mapper;
        public DriveService(IMapper mapper)
        {
            _mapper = mapper;

        }
        private DriveInfo[] driveList = DriveInfo.GetDrives();
        public ServiceResponse<List<GetLogicalDriveDto>> GetLogicalDrive()
        {
            ServiceResponse<List<GetLogicalDriveDto>> serviceResponse = new ServiceResponse<List<GetLogicalDriveDto>>();
            List<GetLogicalDriveDto> drives = new List<GetLogicalDriveDto>();
            int i = 0;
            foreach (DriveInfo d in driveList)
            {
                i = i + 1;

                if(d.IsReady)
                {
                   drives.Add(new GetLogicalDriveDto
                    {
                        Id = i,
                        Name = d.Name
                    });
                }
            }
            serviceResponse.Data = drives;

            return serviceResponse;
        }
    }
}