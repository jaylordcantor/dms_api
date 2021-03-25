using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.FileDirectory;
using dms_api.Dtos.FileSystemObject;
using dms_api.Models;

namespace dms_api.Services.FileDirectoryService
{
    public interface IFileDirectoryService
    {
        Task<ServiceResponse<List<GetFileSystemObjectDto>>> AddFileDirectory(AddFileDirectoryDto newFileDirectory);
        Task<ServiceResponse<List<GetFileDirectoryDto>>> GetAllFileDirectory();
        Task<ServiceResponse<GetFileDirectoryDto>> GetFileDirectoryById(int id);
        ServiceResponse<List<GetFileDirectoryDto>> GetFileDirectoryByParentId(int? id);
        Task<ServiceResponse<List<GetFileDirectoryDto>>> GetFileDirectoryByRootDirectoryId(int id);
        Task<ServiceResponse<List<GetFileDirectoryDto>>> GetFileDirectoryByCatalog(int id);
        Task<ServiceResponse<List<GetFileSystemObjectDto>>> GetFileSystemObject(int id);
    }
}