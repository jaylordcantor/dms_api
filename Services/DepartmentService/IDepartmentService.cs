using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Department;
using dms_api.Models;

namespace dms_api.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<ServiceResponse<List<GetDepartmentDto>>> GetAllDepartment();
        Task<ServiceResponse<GetDepartmentDto>> GetDepartmentById(int id);
        Task<ServiceResponse<List<GetDepartmentDto>>> AddDepartment(AddDepartmentDto newDepartment);
        Task<ServiceResponse<GetDepartmentDto>> UpdateDepartment(UpdateDepartmentDto updatedDepartment);
        Task<ServiceResponse<List<GetDepartmentDto>>> DeleteDepartment(int id);
    }
}