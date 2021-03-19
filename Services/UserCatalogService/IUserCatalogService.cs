using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.User;
using dms_api.Dtos.UserCatalog;
using dms_api.Models;

namespace dms_api.Services.UserCatalogService
{
    public interface IUserCatalogService
    {
        Task<ServiceResponse<List<GetUserCatalogDto>>> GetUserCatalogs();
        Task<ServiceResponse<List<GetUserCatalogDto>>> AddUserCatalog(AddUserCatalogDto newUserCatalog);
        Task<ServiceResponse<List<GetUserDto>>> GetUsersInUserCatalog();
        Task<ServiceResponse<GetUserDto>> GetUserCatalogById(int id);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUserCatolog(DeleteUserCatalog deleteUserCatalog);
    }
}