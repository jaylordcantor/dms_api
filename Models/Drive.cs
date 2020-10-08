namespace dms_api.Models
{
    public class Drive
    {
        public int Id { get; set; }
        public string VolumeLabel { get; set; }
        public string DriveFormat { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal TotalSize { get; set; }
        public decimal FreeSpace { get; set; }
    }
}