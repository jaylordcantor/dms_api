namespace dms_api.Dtos.Section
{
    public class GetSectionDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}