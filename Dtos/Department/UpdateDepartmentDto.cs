namespace dms_api.Dtos.Department
{
    public class UpdateDepartmentDto
    {
        public int Id { get; set; }
        public int? DivisionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}