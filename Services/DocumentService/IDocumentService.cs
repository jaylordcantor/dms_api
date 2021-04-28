using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using dms_api.Dtos.Document;
using dms_api.Dtos.FileSystemObject;
using dms_api.Models;
using Microsoft.AspNetCore.Http;

namespace dms_api.Services.DocumentService
{
    public interface IDocumentService
    {
        Task<ServiceResponse<List<GetFileSystemObjectDto>>> UploadDocument(FileDirectory fileDirectory, List<IFormFile> files);
        Task<ServiceResponse<List<GetDocumentDto>>> GetAllDocument();
        Task<ServiceResponse<GetDocumentDto>> GetDocumentById(int id);
        Task<Stream> PreviewDocument(int? id);
    }
}