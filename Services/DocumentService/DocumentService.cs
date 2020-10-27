using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.Document;
using dms_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Services.DocumentService
{
    public class DocumentService : IDocumentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DocumentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;

        }

        public Task<ServiceResponse<List<GetDocumentDto>>> GetAllDocument()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<GetDocumentDto>> GetDocumentById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Stream> PreviewDocument(int id)
        {
            Document document = await _context.Documents.Include(f => f.FileDirectory).FirstOrDefaultAsync(d => d.Id == id);
            var file = Path.Combine(document.FileDirectory.Path, document.FileName);

            Stream stream = new FileStream(file, FileMode.Open);

            return stream;
        }

        private async Task<Document> SaveDocument(List<Document> documents)
        {
            Document document = new Document();

            foreach (var d in documents)
            {
                document = _mapper.Map<Document>(d);

                await _context.Documents.AddAsync(document);
                await _context.SaveChangesAsync();
            }

            return document;
        }

        private async Task<string> SaveToDirectory(IFormFile file, string path)
        {
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var newPath = Path.Combine(path, newFileName);

            using(Stream stream = new FileStream(newPath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return newFileName;

        }

        public async Task<ServiceResponse<List<GetDocumentDto>>> UploadDocument(FileDirectory fileDirectory, List<IFormFile> files)
        {
            ServiceResponse<List<GetDocumentDto>> serviceResponse = new ServiceResponse<List<GetDocumentDto>>();
            List<Document> document = new List<Document>();

            foreach (var file in files)
            {
                document.Add(new Document{
                    FileDirectoryId = fileDirectory.Id,
                    Name = Path.GetFileNameWithoutExtension(file.FileName), // get original filename
                    FileName = await SaveToDirectory(file,fileDirectory.Path) //rename and save file to directory.
                });
            }
            await SaveDocument(document); // save to db.

            serviceResponse.Message = "Upload Finished";
            serviceResponse.Data = await (_context.Documents.Select(d => _mapper.Map<GetDocumentDto>(d)).ToListAsync());
            return serviceResponse;
        }
    }
}