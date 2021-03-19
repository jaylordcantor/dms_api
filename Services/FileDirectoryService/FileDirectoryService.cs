using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.FileDirectory;
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

            if (fileDirectory.RootDirectoryId != null)
            {
                //create directory from the directory of root path.
                path = SelectedRootDirectory(fileDirectory.RootDirectoryId) + @"\" + fileDirectory.Name;

            }
            else
            {
                path = SelectedFileDirectory(fileDirectory.ParentId) + fileDirectory.Name;
            }

            //check if directory is already exists.
            if (Directory.Exists(path))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Directory is already exists.";

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

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetFileDirectoryDto>>> GetAllFileDirectory()
        {
            ServiceResponse<List<GetFileDirectoryDto>> serviceResponse = new ServiceResponse<List<GetFileDirectoryDto>>();
            List<FileDirectory> fileDirectory = await _context.FileDirectories.ToListAsync();

            serviceResponse.Data = fileDirectory.Select(f => _mapper.Map<GetFileDirectoryDto>(f)).ToList();

            return serviceResponse;
        }

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

        public async Task<ServiceResponse<List<GetFileDirectoryDto>>> GetFileDirectoryByRootDirectoryId(int id)
        {
            ServiceResponse<List<GetFileDirectoryDto>> serviceResponse = new ServiceResponse<List<GetFileDirectoryDto>>();
            List<FileDirectory> fileDirectory = await _context.FileDirectories.Where(f => f.RootDirectoryId == id).ToListAsync();

            serviceResponse.Data = fileDirectory.Select(f => _mapper.Map<GetFileDirectoryDto>(f)).ToList();

            return serviceResponse;
        }

        private string SelectedFileDirectory(int? id)
        {
            FileDirectory fileDirectory = _context.FileDirectories.Include(f => f.Parent).First(f => f.Parent.ParentId == id);

            return fileDirectory.Parent.Path;
        }

        private string SelectedRootDirectory(int? id)
        {
            RootDirectory rootDirectory = _context.RootDirectories.Single(r => r.Id == id);

            return rootDirectory.Path;
        }
    }
}