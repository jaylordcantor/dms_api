using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dms_api.Models
{
    public class RootDirectory
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Drive { get; set; }
        [Column(TypeName = "text")]
        public string Path { get; set; }
    }
}