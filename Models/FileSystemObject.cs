namespace dms_api.Models
{
    public class FileSystemObject
    {
        public int? ParentId { get; set; }
        public int? RootId { get; set; }
        public bool? HasChilds { get; set; }
        public bool? IsFile { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}