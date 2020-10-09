using System.ComponentModel.DataAnnotations.Schema;

namespace dms_api.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "Text")]
        public string Address { get; set; }
    }
}