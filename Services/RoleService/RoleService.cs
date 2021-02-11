using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dms_api.Dtos.GetRoleDto;
using dms_api.Models;

namespace dms_api.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;

        public RoleService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ServiceResponse<List<GetRoleDto>> GetRole()
        {
            ServiceResponse<List<GetRoleDto>> serviceResponse = new ServiceResponse<List<GetRoleDto>>();

            List<GetRoleDto> roles = new List<GetRoleDto>();
            foreach (Role role in Enum.GetValues(typeof(Role)))
            {
                roles.Add(new GetRoleDto { Id = (int)role, Name = ((Role)role).ToString() });
            }

            serviceResponse.Data = roles.Select(d => _mapper.Map<GetRoleDto>(d)).ToList();



            return serviceResponse;
        }
    }
}