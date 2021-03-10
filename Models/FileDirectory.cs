using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dms_api.Models
{
    public class FileDirectory
    {
        public int Id { get; set; }
        public int? RootDirectoryId { get; set; }
        public RootDirectory RootDirectory { get; set; }
        public int? CatalogId { get; set; }
        public Catalog Catalog { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        [Required]
        public string Path { get; set; }
        public int? ParentId { get; set; }
        public FileDirectory Parent { get; set; }
    }
}