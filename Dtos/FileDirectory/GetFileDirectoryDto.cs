using dms_api.Dtos.Catalog;
using dms_api.Dtos.RootDirectory;

namespace dms_api.Dtos.FileDirectory
{
    public class GetFileDirectoryDto
    {
        public int Id { get; set; }
        public int? RootDirectoryId { get; set; }
        public GetRootDirectoryDto RootDirectory { get; set; }
        public int CatalogId { get; set; }
        public GetCatalogDto Catalog { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int? ParentId { get; set; }
        public GetFileDirectoryDto Parent { get; set; }
    }
}