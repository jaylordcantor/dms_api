using System;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Data;
using dms_api.Dtos.User;
using dms_api.Dtos.UserCatalog;
using dms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Services.UserCatalogService
{
    public class UserCatalogService : IUserCatalogService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserCatalogService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<GetUserDto>> AddUserCatalog(AddUserCatalogDto newUserCatalog)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                User user = await _context.Users
                    .Include(u => u.Department)
                    .Include(u => u.Division)
                    .Include(u => u.Location)
                    .Include(u => u.Section)
                    .Include(u => u.UserCatalogs).ThenInclude(uc => uc.Catalog)
                    .FirstOrDefaultAsync(u => u.Id == newUserCatalog.UserId);

                if(user == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "User not found";

                    return serviceResponse;
                }

                Catalog catalog =await _context.Catalogs
                    .FirstOrDefaultAsync(c => c.Id == newUserCatalog.CatalogId);

                if(catalog == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Catalog not found";

                    return serviceResponse;
                }

                UserCatalog userCatalog = new UserCatalog
                {
                    Catalog = catalog,
                    User = user
                };

                await _context.UserCatalogs.AddAsync(userCatalog);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
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