using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.Location;
using dms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public LocationService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetLocationDto>>> AddLocation(AddLocationDto newLocation)
        {
            ServiceResponse<List<GetLocationDto>> serviceResponse = new ServiceResponse<List<GetLocationDto>>();

            Location location = _mapper.Map<Location>(newLocation);
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await (_context.Locations.Select(l => _mapper.Map<GetLocationDto>(l))).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLocationDto>>> DeleteLocation(int id)
        {
            ServiceResponse<List<GetLocationDto>> serviceResponse = new ServiceResponse<List<GetLocationDto>>();
            try
            {
                Location location = await _context.Locations.FirstAsync(l => l.Id == id);
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await(_context.Locations.Select(l => _mapper.Map<GetLocationDto>(l))).ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLocationDto>>> GetAllLocation()
        {
            ServiceResponse<List<GetLocationDto>> serviceResponse = new ServiceResponse<List<GetLocationDto>>();

            List<Location> location = await _context.Locations.ToListAsync();

            serviceResponse.Data = location.Select(l => _mapper.Map<GetLocationDto>(l)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLocationDto>> GetLocationById(int id)
        {
            ServiceResponse<GetLocationDto> serviceResponse = new ServiceResponse<GetLocationDto>();

            Location location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);
            serviceResponse.Data = _mapper.Map<GetLocationDto>(location);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLocationDto>> UpdateLocation(UpdateLocationDto updatedLocation)
        {
            ServiceResponse<GetLocationDto> serviceResponse = new ServiceResponse<GetLocationDto>();
            try
            {
                Location location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == updatedLocation.Id);
                location.Id = updatedLocation.Id;
                location.Name = updatedLocation.Name;
                location.Address = updatedLocation.Address;

                _context.Locations.Update(location);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetLocationDto>(location);
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