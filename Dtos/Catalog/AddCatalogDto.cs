
namespace dms_api.Dtos.Catalog
{
    public class AddCatalogDto
    {
        public int DepartmentId { get; set; }
        public int? SectionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}