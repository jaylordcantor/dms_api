
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.Section;
using dms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Services.SectionService
{
    public class SectionService : ISectionService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public SectionService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetSectionDto>>> AddSection(AddSectionDto newSection)
        {
            ServiceResponse<List<GetSectionDto>> serviceResponse = new ServiceResponse<List<GetSectionDto>>();

            Section section = _mapper.Map<Section>(newSection);

            await _context.Sections.AddAsync(section);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await (_context.Sections.Select(x => _mapper.Map<GetSectionDto>(x))).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSectionDto>>> DeleteSection(int id)
        {
            ServiceResponse<List<GetSectionDto>> serviceResponse = new ServiceResponse<List<GetSectionDto>>();

            try
            {
                Section section = await _context.Sections.FirstAsync(x => x.Id == id);
                _context.Sections.Remove(section);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await (_context.Sections.Select(x => _mapper.Map<GetSectionDto>(x))).ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSectionDto>>> GetAllSection()
        {
            ServiceResponse<List<GetSectionDto>> serviceResponse = new ServiceResponse<List<GetSectionDto>>();
            List<Section> section = await _context.Sections.ToListAsync();

            serviceResponse.Data = section.Select(x => _mapper.Map<GetSectionDto>(x)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSectionDto>> GetSectionById(int id)
        {
            ServiceResponse<GetSectionDto> serviceResponse = new ServiceResponse<GetSectionDto>();
            Section section = await _context.Sections.FirstOrDefaultAsync(x => x.Id == id);

            serviceResponse.Data = _mapper.Map<GetSectionDto>(section);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSectionDto>> UpdateSection(UpdateSectionDto updatedSection)
        {
            ServiceResponse<GetSectionDto> serviceResponse = new ServiceResponse<GetSectionDto>();

            try
            {
                Section section = await _context.Sections.FirstOrDefaultAsync(x => x.Id == updatedSection.Id);


                section.Id = updatedSection.Id;
                section.DepartmentId = updatedSection.DepartmentId;
                section.Code = updatedSection.Code;
                section.Name = updatedSection.Name;

                _context.Sections.Update(section);

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetSectionDto>(section);
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