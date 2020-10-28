using System.Collections.Generic;

namespace dms_api.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? SectionId { get; set; }
        public Section Section { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<UserCatalog> UserCatalogs { get; set; }
    }
}