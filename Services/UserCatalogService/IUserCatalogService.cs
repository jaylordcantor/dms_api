using System.Threading.Tasks;
using dms_api.Dtos.User;
using dms_api.Dtos.UserCatalog;
using dms_api.Models;

namespace dms_api.Services.UserCatalogService
{
    public interface IUserCatalogService
    {
        Task<ServiceResponse<GetUserDto>> AddUserCatalog(AddUserCatalogDto newUserCatalog);
    }
}