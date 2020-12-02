using dms_api.Dtos.Division;

namespace dms_api.Dtos.Department
{
    public class GetDepartmentDto
    {
        public int Id { get; set; }
        public int? DivisionId { get; set; }
        public GetDivisionDto Division { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}