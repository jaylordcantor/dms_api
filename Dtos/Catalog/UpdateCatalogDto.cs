namespace dms_api.Dtos.Catalog
{
    public class UpdateCatalogDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int? SectionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}