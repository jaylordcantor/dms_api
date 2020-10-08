using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.Department;
using dms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public DepartmentService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<AddDepartmentDto>>> AddDepartment(AddDepartmentDto newDepartment)
        {
            ServiceResponse<List<AddDepartmentDto>> serviceResponse = new ServiceResponse<List<AddDepartmentDto>>();

            Department department = _mapper.Map<Department>(newDepartment);

            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (_context.Departments.Select(x => _mapper.Map<AddDepartmentDto>(x))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDepartmentDto>>> DeleteDepartment(int id)
        {
            ServiceResponse<List<GetDepartmentDto>> serviceResponse = new ServiceResponse<List<GetDepartmentDto>>();

            try
            {
                Department department = await _context.Departments.FirstAsync(x => x.Id == id);
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Departments.Select(x => _mapper.Map<GetDepartmentDto>(x))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDepartmentDto>>> GetAllDepartment()
        {
            ServiceResponse<List<GetDepartmentDto>> serviceResponse = new ServiceResponse<List<GetDepartmentDto>>();
            List<Department> departments = await _context.Departments.ToListAsync();
            serviceResponse.Data = _context.Departments.Select(x => _mapper.Map<GetDepartmentDto>(x)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDepartmentDto>> GetDepartmentById(int id)
        {
            ServiceResponse<GetDepartmentDto> serviceResponse = new ServiceResponse<GetDepartmentDto>();

            Department department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            serviceResponse.Data = _mapper.Map<GetDepartmentDto>(department);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDepartmentDto>> UpdateDepartment(UpdateDepartmentDto updatedDepartment)
        {
            ServiceResponse<GetDepartmentDto> serviceResponse = new ServiceResponse<GetDepartmentDto>();
            try
            {
                Department department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == updatedDepartment.Id);
                serviceResponse.Data = _mapper.Map<GetDepartmentDto>(department);
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