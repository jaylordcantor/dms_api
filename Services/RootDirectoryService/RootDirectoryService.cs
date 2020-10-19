using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.RootDirectory;
using dms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Services.RootDirectoryService
{
    public class RootDirectoryService : IRootDirectoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public RootDirectoryService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<ServiceResponse<List<GetRootDirectoryDto>>> AddRootDirectory(AddRootDirectoryDto newRootDirectory)
        {
            ServiceResponse<List<GetRootDirectoryDto>> serviceResponse = new ServiceResponse<List<GetRootDirectoryDto>>();
            RootDirectory rootDirectory =_mapper.Map<RootDirectory>(newRootDirectory);

            string path = rootDirectory.Drive + rootDirectory.Name;

            if(Directory.Exists(path))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "The directory is already exists.";

                return serviceResponse;
            }

            Directory.CreateDirectory(path);
            rootDirectory.Path = path;

            await _context.RootDirectories.AddAsync(rootDirectory);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await(_context.RootDirectories.Select(r => _mapper.Map<GetRootDirectoryDto>(r))).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRootDirectoryDto>>> GetAllRootDirectory()
        {
            ServiceResponse<List<GetRootDirectoryDto>> serviceResponse = new ServiceResponse<List<GetRootDirectoryDto>>();
            List<RootDirectory> rootDirectories = await _context.RootDirectories.ToListAsync();

            serviceResponse.Data = await _context.RootDirectories.Include(r => r.Department).Select(r => _mapper.Map<GetRootDirectoryDto>(r)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRootDirectoryDto>> GetRootDirectoryById(int id)
        {
            ServiceResponse<GetRootDirectoryDto> serviceResponse = new ServiceResponse<GetRootDirectoryDto>();
            RootDirectory rootDirectory = await _context.RootDirectories.Include(r => r.Department).FirstOrDefaultAsync(r => r.Id == id);

            serviceResponse.Data = _mapper.Map<GetRootDirectoryDto>(rootDirectory);

            return serviceResponse;
        }
    }
}