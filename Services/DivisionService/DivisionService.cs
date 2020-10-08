using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Models;
using dms_api.Dtos.Division;
using System;
using dms_api.Data;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Services.DivisionService
{
    public class DivisionService : IDivisionService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public DivisionService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<List<GetDivisionDto>>> AddDivision(AddDivisionDto newDivision)
        {
            ServiceResponse<List<GetDivisionDto>> serviceResponse = new ServiceResponse<List<GetDivisionDto>>();

            Division division = _mapper.Map<Division>(newDivision);

            await _context.Divisions.AddAsync(division);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (_context.Divisions.Select(x => _mapper.Map<GetDivisionDto>(x))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDivisionDto>>> DeleteDivision(int id)
        {
            ServiceResponse<List<GetDivisionDto>> serviceResponse = new ServiceResponse<List<GetDivisionDto>>();
            try
            {
                Division division = await _context.Divisions.FirstAsync(d => d.Id == id);
                _context.Divisions.Remove(division);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.Divisions.Select(d => _mapper.Map<GetDivisionDto>(d))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDivisionDto>>> GetAllDivision()
        {
            ServiceResponse<List<GetDivisionDto>> serviceResponse = new ServiceResponse<List<GetDivisionDto>>();

            List<Division> dbDivisions = await _context.Divisions.ToListAsync();

            serviceResponse.Data = dbDivisions.Select(d => _mapper.Map<GetDivisionDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDivisionDto>> GetDivisionById(int id)
        {
            ServiceResponse<GetDivisionDto> serviceResponse = new ServiceResponse<GetDivisionDto>();
            Division dbDivision = await _context.Divisions.FirstOrDefaultAsync(x => x.Id == id);
            serviceResponse.Data = _mapper.Map<GetDivisionDto>(dbDivision);
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetDivisionDto>> UpdateDivision(UpdateDivisionDto updatedDivision)
        {
            ServiceResponse<GetDivisionDto> serviceResponse = new ServiceResponse<GetDivisionDto>();
            try
            {
                Division division = await _context.Divisions.FirstOrDefaultAsync(x => x.Id == updatedDivision.Id);
                _context.Divisions.Update(division);

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetDivisionDto>(division);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}