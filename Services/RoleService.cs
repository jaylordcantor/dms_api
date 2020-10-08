using AutoMapper;

namespace dms_api.Services
{
    public class RoleService
    {
        private readonly IMapper _mapper;

        public RoleService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}