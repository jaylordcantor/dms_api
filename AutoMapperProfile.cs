using AutoMapper;
using dms_api.Dtos.Catalog;
using dms_api.Dtos.Department;
using dms_api.Dtos.Division;
using dms_api.Dtos.Location;
using dms_api.Dtos.RootDirectory;
using dms_api.Dtos.Section;
using dms_api.Models;

namespace dms_api
{
    public class AutoMapperProfile  : Profile
    {
        public AutoMapperProfile()
        {
            //Catalog
            CreateMap<Catalog, GetCatalogDto>();
            CreateMap<AddCatalogDto, Catalog>();

            //Division
            CreateMap<Division, GetDivisionDto>();
            CreateMap<AddDivisionDto, Division>();

            //Department
            CreateMap<Department, GetDepartmentDto>();
            CreateMap<AddDepartmentDto, Department>();

            //Location
            CreateMap<Location, GetLocationDto>();
            CreateMap<AddLocationDto, Location>();

            //Root Directory
            CreateMap<RootDirectory, GetRootDirectoryDto>();
            CreateMap<AddRootDirectoryDto, RootDirectory>();

            //Section
            CreateMap<Section, GetSectionDto>();
            CreateMap<AddSectionDto, Section>();
        }
    }
}