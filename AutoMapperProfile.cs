using AutoMapper;
using dms_api.Dtos.Department;
using dms_api.Dtos.Division;
using dms_api.Models;

namespace dms_api
{
    public class AutoMapperProfile  : Profile
    {
        public AutoMapperProfile()
        {
            //Division
            CreateMap<Division, GetDivisionDto>();
            CreateMap<AddDivisionDto, Division>();

            //Department
            CreateMap<Department, GetDepartmentDto>();
            CreateMap<AddDepartmentDto, Department>();
        }
    }
}