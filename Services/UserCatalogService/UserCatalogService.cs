using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.User;
using dms_api.Dtos.UserCatalog;
using dms_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace dms_api.Services.UserCatalogService
{
    public class UserCatalogService : IUserCatalogService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _accessor;
        private int UserId() => int.Parse(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private int UserRole() => int.Parse(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.Role));
        public UserCatalogService(DataContext context, IHttpContextAccessor accessor, IMapper mapper)
        {
            _accessor = accessor;
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetUserCatalogDto>>> AddUserCatalog(AddUserCatalogDto newUserCatalog)
        {
            ServiceResponse<List<GetUserCatalogDto>> serviceResponse = new ServiceResponse<List<GetUserCatalogDto>>();

            try
            {
                User user = await _context.Users
                    .Include(u => u.Department)
                    .Include(u => u.Location)
                    .Include(u => u.Section)
                    .Include(u => u.UserCatalogs).ThenInclude(uc => uc.Catalog)
                    .FirstOrDefaultAsync(u => u.Id == newUserCatalog.UserId);

                if (user == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "User not found";

                    return serviceResponse;
                }

                Catalog catalog = await _context.Catalogs
                    .FirstOrDefaultAsync(c => c.Id == newUserCatalog.CatalogId);

                if (catalog == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Catalog not found";

                    return serviceResponse;
                }

                UserCatalog userCatalog = new UserCatalog
                {
                    User = user,
                    Catalog = catalog
                };


                UserCatalog myUserCatalog = new UserCatalog
                {
                    UserId = newUserCatalog.UserId,
                    CatalogId = newUserCatalog.CatalogId
                };

                await _context.UserCatalogs.AddAsync(userCatalog);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.UserCatalogs
                    .Include(x => x.Catalog)
                    .Include(x => x.User)
                    .Include(x => x.User.Department)
                    .Include(x => x.User.Section)
                    .Select(s => _mapper.Map<GetUserCatalogDto>(s))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUserCatolog(DeleteUserCatalog deleteUserCatalog)
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();

            try
            {
                UserCatalog userCatalog = await _context.UserCatalogs.FirstOrDefaultAsync(uc => uc.UserId == deleteUserCatalog.UserId && uc.CatalogId == deleteUserCatalog.CatalogId);

                if (userCatalog == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "no record found";

                    return serviceResponse;
                }

                _context.Remove(userCatalog);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await (_context.Users.Select(u => _mapper.Map<GetUserDto>(u))).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetUsersInUserCatalog()
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            List<User> user = await _context.Users
                    .Include(u => u.Department)
                    .Include(u => u.Location)
                    .Include(u => u.Section)
                    .Include(u => u.UserCatalogs)
                    .ThenInclude(uc => uc.Catalog)
                    .ToListAsync();

            serviceResponse.Data = await (_context.Users.Select(u => _mapper.Map<GetUserDto>(u))).ToListAsync();
            serviceResponse.Message = _accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserCatalogById(int id)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();

            User user = await _context.Users
                    .Include(u => u.Department)
                    .Include(u => u.Location)
                    .Include(u => u.Section)
                    .Include(u => u.UserCatalogs).ThenInclude(uc => uc.Catalog)
                    .FirstOrDefaultAsync(u => u.Id == id && u.Id == UserId());

            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            serviceResponse.Message = "Success!";

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserCatalogDto>>> GetUserCatalogs()
        {
            ServiceResponse<List<GetUserCatalogDto>> response = new ServiceResponse<List<GetUserCatalogDto>>();


            List<UserCatalog> userCatalogs = UserRole().Equals(1) ?
                await _context.UserCatalogs
                .Include(x => x.Catalog)
                .Include(x => x.User)
                .Include(x => x.User.Department)
                .Include(x => x.User.Section)
                .ToListAsync()
            :
                await _context.UserCatalogs
                .Include(x => x.Catalog)
                .Include(x => x.User)
                .Include(x => x.User.Department)
                .Include(x => x.User.Section).Where(x => x.UserId == UserId())
                .ToListAsync();

            response.Data = userCatalogs.Select(x => _mapper.Map<GetUserCatalogDto>(x)).ToList();
            response.Message = "Success!";

            return response;
        }
    }
}