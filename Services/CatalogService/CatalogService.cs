using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.Catalog;
using dms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Services.CatalogService
{
    public class CatalogService : ICatalogService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CatalogService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetCatalogDto>>> AddCatalog(AddCatalogDto newCatalog)
        {
            ServiceResponse<List<GetCatalogDto>> serviceResponse = new ServiceResponse<List<GetCatalogDto>>();
            Catalog catalog = _mapper.Map<Catalog>(newCatalog);

            await _context.Catalogs.AddAsync(catalog);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await (
                _context.Catalogs
                .Select(c => _mapper.Map<GetCatalogDto>(c))
            ).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCatalogDto>>> DeleteCatalog(int id)
        {
            ServiceResponse<List<GetCatalogDto>> serviceResponse = new ServiceResponse<List<GetCatalogDto>>();
            try
            {
                Catalog catalog = await _context.Catalogs.FirstAsync(c => c.Id == id);
                _context.Catalogs.Remove(catalog);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await (
                    _context.Catalogs
                    .Select(c => _mapper.Map<GetCatalogDto>(c))
                ).ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCatalogDto>>> GetAllCatalog()
        {
            ServiceResponse<List<GetCatalogDto>> serviceResponse = new ServiceResponse<List<GetCatalogDto>>();
            List<Catalog> catalogs = await _context.Catalogs
                .Include(s => s.Section)
                .Include(s => s.Department)
                .Include(s => s.Department.Division)
                .ToListAsync();

            serviceResponse.Data = catalogs
                .Select(c => _mapper.Map<GetCatalogDto>(c))
                .ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCatalogDto>>> GetCatalogByDepartment(int id)
        {
            ServiceResponse<List<GetCatalogDto>> serviceResponse = new ServiceResponse<List<GetCatalogDto>>();
            List<Catalog> catalogs = await _context.Catalogs
                .Include(s => s.Section)
                .Include(s => s.Department)
                .Include(s => s.Department.Division)
                .Where(c => c.DepartmentId == id)
                .ToListAsync();

            serviceResponse.Data =catalogs
                .Select(c => _mapper.Map<GetCatalogDto>(c))
                .ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCatalogDto>> GetCatalogById(int id)
        {
            ServiceResponse<GetCatalogDto> serviceResponse = new ServiceResponse<GetCatalogDto>();
            Catalog catalog = await _context.Catalogs
                .Include(s => s.Section)
                .Include(s => s.Department)
                .Include(s => s.Department.Division)
                .FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetCatalogDto>(catalog);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCatalogDto>>> GetCatalogBySection(int id)
        {
            ServiceResponse<List<GetCatalogDto>> serviceResponse = new ServiceResponse<List<GetCatalogDto>>();
            List<Catalog> catalogs = await _context.Catalogs
                .Where(c => c.SectionId == id)
                .Include(s => s.Section)
                .Include(s => s.Department)
                .Include(s => s.Department.Division)
                .ToListAsync();

            serviceResponse.Data = catalogs
                .Select(c => _mapper.Map<GetCatalogDto>(c))
                .ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCatalogDto>> UpdateCatalog(UpdateCatalogDto updatedCatalog)
        {
            ServiceResponse<GetCatalogDto> serviceResponse = new ServiceResponse<GetCatalogDto>();

            try
            {
                Catalog catalog = await _context.Catalogs
                    .Include(s => s.Section)
                    .Include(s => s.Department)
                    .Include(s => s.Department.Division)
                    .FirstOrDefaultAsync(c => c.Id == updatedCatalog.Id);

                catalog.Id = updatedCatalog.Id;
                catalog.DepartmentId = updatedCatalog.DepartmentId;
                catalog.SectionId = updatedCatalog.SectionId;
                catalog.Name = updatedCatalog.Name;
                catalog.Code = updatedCatalog.Code;

                _context.Catalogs.Update(catalog);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCatalogDto>(catalog);

            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }
    }
}