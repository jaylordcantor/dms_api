using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Data;
using dms_api.Models;
using dms_api.Services.DocumentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly DataContext _context;
        public DocumentController(IDocumentService documentService, DataContext context)
        {
            _context = context;
            _documentService = documentService;

        }

        [HttpPost("api/post")]
        public async Task<IActionResult> Upload([FromForm] int fileDirectoryId, List<IFormFile> files)
        {
            FileDirectory fileDirectory = await _context.FileDirectories.SingleAsync(f => f.Id == fileDirectoryId);

            return Ok(await _documentService.UploadDocument(fileDirectory, files));
        }

        [HttpGet("api/preview/get/{id}")]
        public async Task<IActionResult> Preview(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            return File(await _documentService.PreviewDocument(id), "application/pdf");
        }
    }
}