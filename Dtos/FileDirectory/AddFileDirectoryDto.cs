namespace dms_api.Dtos.FileDirectory
{
    public class AddFileDirectoryDto
    {
        public int? RootDirectoryId { get; set; }
        public int CatalogId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}