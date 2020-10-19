using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.RootDirectory;
using dms_api.Models;

namespace dms_api.Services.RootDirectoryService
{
    public interface IRootDirectoryService
    {
        Task<ServiceResponse<List<GetRootDirectoryDto>>> AddRootDirectory(AddRootDirectoryDto newRootDirectory);
        Task<ServiceResponse<List<GetRootDirectoryDto>>> GetAllRootDirectory();
        Task<ServiceResponse<GetRootDirectoryDto>> GetRootDirectoryById(int id);
    }
}