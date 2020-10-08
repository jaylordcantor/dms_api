using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Division;
using dms_api.Models;

namespace dms_api.Services.DivisionService
{
    public interface IDivisionService
    {
        Task<ServiceResponse<List<GetDivisionDto>>> GetAllDivision();
        Task<ServiceResponse<GetDivisionDto>> GetDivisionById(int id);
        Task<ServiceResponse<List<GetDivisionDto>>> AddDivision(AddDivisionDto newDivision);
        Task<ServiceResponse<GetDivisionDto>> UpdateDivision(UpdateDivisionDto updatedDivision);
        Task<ServiceResponse<List<GetDivisionDto>>> DeleteDivision(int id);
    }
}