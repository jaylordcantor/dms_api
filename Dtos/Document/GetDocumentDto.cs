namespace dms_api.Dtos.Document
{
    public class GetDocumentDto
    {
        public int Id { get; set; }
        public int FileDirectoryId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
    }
}