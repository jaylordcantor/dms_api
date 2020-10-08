using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.Section;
using dms_api.Models;

namespace dms_api.Services.SectionService
{
    public interface ISectionService
    {
        Task<ServiceResponse<List<GetSectionDto>>> GetAllSection();
        Task<ServiceResponse<GetSectionDto>> GetSectionById(int id);
        Task<ServiceResponse<List<GetSectionDto>>> AddSection(AddSectionDto newSection);
        Task<ServiceResponse<GetSectionDto>> UpdateSection(UpdateSectionDto updatedSection);
        Task<ServiceResponse<List<GetSectionDto>>> DeleteSection(int id);
    }
}