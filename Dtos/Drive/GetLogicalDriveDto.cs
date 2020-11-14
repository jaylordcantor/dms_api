namespace dms_api.Dtos.Drive
{
    public class GetLogicalDriveDto
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