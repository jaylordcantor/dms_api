
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace dms_api.Dtos.Document
{
    public class AddDocumentDto
    {
        public int FileDirectoryId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
    }
}