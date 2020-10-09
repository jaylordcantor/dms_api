using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Location;
using dms_api.Models;

namespace dms_api.Services.LocationService
{
    public interface ILocationService
    {
        Task<ServiceResponse<List<GetLocationDto>>> GetAllLocation();
        Task<ServiceResponse<GetLocationDto>> GetLocationById(int id);
        Task<ServiceResponse<List<GetLocationDto>>> AddLocation(AddLocationDto newLocation);
        Task<ServiceResponse<List<GetLocationDto>>> DeleteLocation(int id);
        Task<ServiceResponse<GetLocationDto>> UpdateLocation(UpdateLocationDto updatedLocation);
    }
}
