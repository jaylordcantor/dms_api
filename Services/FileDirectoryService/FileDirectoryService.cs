using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.Document;
using dms_api.Dtos.FileDirectory;
using dms_api.Dtos.FileSystemObject;
using dms_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Services.FileDirectoryService
{
    public class FileDirectoryService : IFileDirectoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private int UserId() => int.Parse(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private int UserRole() => int.Parse(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.Role));
        public FileDirectoryService(IMapper mapper, DataContext context, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _mapper = mapper;
            _context = context;

        }
        public async Task<ServiceResponse<List<GetFileDirectoryDto>>> AddFileDirectory(AddFileDirectoryDto newFileDirectory)
        {
            ServiceResponse<List<GetFileDirectoryDto>> serviceResponse = new ServiceResponse<List<GetFileDirectoryDto>>();
            FileDirectory fileDirectory = _mapper.Map<FileDirectory>(newFileDirectory);

            string path = "";
            string catalogFolder = Guid.NewGuid().ToString();

            if (fileDirectory.RootDirectoryId != null && fileDirectory.CatalogId != null)
            {
                //create directory from the directory of root path.
                path = SelectedRootDirectory(fileDirectory.RootDirectoryId) + @"\" + catalogFolder + @"\" + fileDirectory.Name;

            }
            else
            {
                path = SelectedFileDirectory(fileDirectory.ParentId) + @"\" + fileDirectory.Name;
            }

            //check if directory is already exists.
            if (Directory.Exists(path))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Directory is already exists." + path;

                return serviceResponse;
            }

            //create directory if not exists
            Directory.CreateDirectory(path);

            //save path to DB.
            fileDirectory.Path = path;

            await _context.FileDirectories.AddAsync(fileDirectory);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await (
                _context.FileDirectories
                .Include(x => x.RootDirectory)
                .Include(x => x.Catalog)
                .Where(x => x.CatalogId == fileDirectory.CatalogId)
                .Select(f => _mapper.Map<GetFileDirectoryDto>(f))
            ).ToListAsync();
            serviceResponse.Message = catalogFolder;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetFileDirectoryDto>>> GetAllFileDirectory()
        {
            ServiceResponse<List<GetFileDirectoryDto>> serviceResponse = new ServiceResponse<List<GetFileDirectoryDto>>();
            List<FileDirectory> fileDirectory = await _context.FileDirectories.ToListAsync();

            serviceResponse.Data = fileDirectory.Select(f => _mapper.Map<GetFileDirectoryDto>(f)).ToList();

            return serviceResponse;
        }

        //return list of files by catalog id
        public async Task<ServiceResponse<List<GetFileDirectoryDto>>> GetFileDirectoryByCatalog(int id)
        {
            ServiceResponse<List<GetFileDirectoryDto>> serviceResponse = new ServiceResponse<List<GetFileDirectoryDto>>();

            List<FileDirectory> fileDirectories = await _context.FileDirectories
                .Include(x => x.RootDirectory)
                .Include(x => x.Catalog)
                .Where(x => x.CatalogId == id).ToListAsync();

            serviceResponse.Data = fileDirectories
                .Select(x => _mapper.Map<GetFileDirectoryDto>(x)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetFileDirectoryDto>> GetFileDirectoryById(int id)
        {
            ServiceResponse<GetFileDirectoryDto> serviceResponse = new ServiceResponse<GetFileDirectoryDto>();
            FileDirectory fileDirectory = await _context.FileDirectories.SingleAsync(f => f.Id == id);

            serviceResponse.Data = _mapper.Map<GetFileDirectoryDto>(fileDirectory);

            return serviceResponse;
        }
        //return subfolders
        public ServiceResponse<List<GetFileDirectoryDto>> GetFileDirectoryByParentId(int? id)
        {
            ServiceResponse<List<GetFileDirectoryDto>> serviceResponse = new ServiceResponse<List<GetFileDirectoryDto>>();

            List<FileDirectory> fileDirectory = _context.FileDirectories
                .Include(s => s.Parent)
                .Where(s => s.ParentId == id)
                .ToList();

            serviceResponse.Data = fileDirectory.Select(x => _mapper.Map<GetFileDirectoryDto>(x)).ToList();

            return serviceResponse;
        }
        //return root folders
        public async Task<ServiceResponse<List<GetFileDirectoryDto>>> GetFileDirectoryByRootDirectoryId(int id)
        {
            ServiceResponse<List<GetFileDirectoryDto>> serviceResponse = new ServiceResponse<List<GetFileDirectoryDto>>();
            List<FileDirectory> fileDirectory = await _context.FileDirectories.Where(f => f.RootDirectoryId == id).ToListAsync();

            serviceResponse.Data = fileDirectory.Select(f => _mapper.Map<GetFileDirectoryDto>(f)).ToList();

            return serviceResponse;
        }

        private string SelectedFileDirectory(int? id)
        {
            FileDirectory fileDirectory = _context.FileDirectories.Single(f => f.Id == id);

            return fileDirectory.Path;
        }

        private async Task<string> SelectedRootDirectory(int? id)
        {
            RootDirectory rootDirectory = await _context.RootDirectories.SingleAsync(r => r.Id == id);

            return rootDirectory.Path;
        }

        private async Task<Catalog> GetOneCatalog(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var catalog = await _context.Catalogs
                .Include(c => c.Department)
                .SingleAsync();

            return catalog;
        }

        private async Task<List<Document>> GetDocuments(int id)
        {
            List<Document> documents = await _context.Documents.Where(d => d.FileDirectoryId == id).ToListAsync();

            return documents;

        }

        private async Task<List<FileDirectory>> GetFileDirectories(int id)
        {
            List<FileDirectory> fileDirectories = await _context.FileDirectories.Where(f => f.ParentId == id).ToListAsync();

            return fileDirectories;
        }

        private GetFileSystemObjectDto GetOneDocument(Document document)
        {

            if (document == null)
            {
                return null;
            }
            var pdfDocument = new GetFileSystemObjectDto();
            pdfDocument.IsFile = true;
            pdfDocument.Name = document.Name;
            pdfDocument.FileId = document.Id;
            pdfDocument.Path = document.FileDirectory.Path;
            return pdfDocument;
        }

        private GetFileSystemObjectDto GetOneFileDirectory(FileDirectory fileDirectory)
        {

            if (fileDirectory == null)
            {
                return null;
            }
            var directory = new GetFileSystemObjectDto();
            directory.IsFile = false;
            directory.ParentId = fileDirectory.ParentId;
            directory.FileId = fileDirectory.Id;
            directory.Name = fileDirectory.Name;
            directory.Path = fileDirectory.Path;
            return directory;
        }


        public async Task<ServiceResponse<List<GetFileSystemObjectDto>>> GetFileSystemObject(int id)
        {
            ServiceResponse<List<GetFileSystemObjectDto>> response = new ServiceResponse<List<GetFileSystemObjectDto>>();

            FileDirectory fileDirectory = await _context.FileDirectories
                .Include(c => c.Catalog)
                .Include(c => c.Parent)
                .Include(c => c.RootDirectory)

                .SingleOrDefaultAsync(f => f.Id == id);
            var objId = 0;
            var objs = new List<GetFileSystemObjectDto>();

            foreach (FileDirectory directory in await GetFileDirectories(id))
            {
                objId += 1;
                var obj = GetOneFileDirectory(directory);
                obj.Id = objId;
                objs.Add(obj);

            }

            foreach (Document document in await GetDocuments(id))
            {
                objId += 1;
                var obj = GetOneDocument(document);
                obj.Id = objId;
                objs.Add(obj);

            }
            response.Data = objs;

            return response;
        }
    }
}