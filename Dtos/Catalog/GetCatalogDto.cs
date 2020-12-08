using System.Collections.Generic;
using dms_api.Dtos.Department;
using dms_api.Dtos.Section;
using dms_api.Dtos.User;

namespace dms_api.Dtos.Catalog
{
    public class GetCatalogDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public GetDepartmentDto Department{ get; set; }
        public int? SectionId { get; set; }
        public GetSectionDto Section { get; set; }
        public List<GetUserDto> Users { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}