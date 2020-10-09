using dms_api.Dtos.Department;

namespace dms_api.Dtos.Section
{
    public class GetSectionDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public GetDepartmentDto Department { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}