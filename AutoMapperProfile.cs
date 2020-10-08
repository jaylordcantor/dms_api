using AutoMapper;
using dms_api.Dtos.Division;
using dms_api.Models;

namespace dms_api
{
    public class AutoMapperProfile  : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Division, GetDivisionDto>();
            CreateMap<AddDivisionDto, Division>();
        }
    }
}