namespace dms_api.Models
{
    public class Directory
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}