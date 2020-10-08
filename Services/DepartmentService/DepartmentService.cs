using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Department;
using dms_api.Models;

namespace dms_api.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        public async Task<ServiceResponse<List<AddDepartmentDto>>> AddDepartment(AddDepartmentDto newDepartment)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetDepartmentDto>>> DeleteDepartment(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetDepartmentDto>>> GetAllDepartment()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<GetDepartmentDto>> GetDepartmentById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<UpdateDepartmentDto>> UpdateDepartment(UpdateDepartmentDto updatedDepartment)
        {
            throw new System.NotImplementedException();
        }
    }
}