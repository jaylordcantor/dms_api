using System.Collections.Generic;
using dms_api.Dtos.Catalog;
using dms_api.Dtos.Department;
using dms_api.Dtos.Division;
using dms_api.Dtos.Location;
using dms_api.Dtos.Section;

namespace dms_api.Dtos.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public GetDepartmentDto Department { get; set; }
        public GetSectionDto Section { get; set; }
        public GetLocationDto Location { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MI { get; set; }
        public string EmployeeNo { get; set; }
        public bool IsActive { get; set; }
        public List<GetCatalogDto> Catalogs { get; set; }
    }
}