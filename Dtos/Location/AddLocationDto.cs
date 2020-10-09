using System.ComponentModel.DataAnnotations.Schema;

namespace dms_api.Dtos.Location
{
    public class AddLocationDto
    {
        public string Name { get; set; }

        [Column(TypeName = "Text")]
        public string Address { get; set; }
    }
}