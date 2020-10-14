using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Catalog;
using dms_api.Models;

namespace dms_api.Services.CatalogService
{
    public interface ICatalogService
    {
        Task<ServiceResponse<List<GetCatalogDto>>> AddCatalog(AddCatalogDto newCatalog);
        Task<ServiceResponse<List<GetCatalogDto>>> DeleteCatalog(int id);
        Task<ServiceResponse<List<GetCatalogDto>>> GetAllCatalog();
        Task<ServiceResponse<List<GetCatalogDto>>> GetCatalogByDepartment(int id);
        Task<ServiceResponse<GetCatalogDto>> GetCatalogById(int id);
        Task<ServiceResponse<List<GetCatalogDto>>> GetCatalogBySection(int id);
        Task<ServiceResponse<GetCatalogDto>> UpdateCatalog(UpdateCatalogDto updatedCatalog);
    }
}