using dms_api.Dtos.Catalog;
using dms_api.Dtos.FileDirectory;
using dms_api.Dtos.RootDirectory;

namespace dms_api.Dtos.FileSystemObject
{
    public class GetFileSystemObjectDto
    {
        public int Id { get; set; }
        public int FileId { get; set; } // folder / pdf primary id
        public int? ParentId { get; set; }
        public int? RootDirectoryId { get; set; }
        public int CatalogId { get; set; }
        public bool? IsFile { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}