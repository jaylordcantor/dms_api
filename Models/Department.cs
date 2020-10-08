namespace dms_api.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int? DivisionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Division Division { get; set; }
    }
}