using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.GetRoleDto;
using dms_api.Models;

namespace dms_api.Services.RoleService
{
    public interface IRoleService
    {
        ServiceResponse<List<GetRoleDto>> GetRole();
    }
}