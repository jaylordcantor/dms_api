namespace dms_api.Models
{
    public class Section
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}