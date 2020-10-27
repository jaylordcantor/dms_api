using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dms_api.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Required]
        public int FileDirectoryId { get; set; }
        public FileDirectory FileDirectory { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string FileName { get; set; }
    }
}