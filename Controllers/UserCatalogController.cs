using System.Threading.Tasks;
using dms_api.Dtos.UserCatalog;
using dms_api.Services.UserCatalogService;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCatalogController : ControllerBase
    {
        private readonly IUserCatalogService _userCatalogService;
        public UserCatalogController(IUserCatalogService userCatalogService)
        {
            _userCatalogService = userCatalogService;

        }

        [HttpPost("api/post")]
        public async Task<IActionResult> Add(AddUserCatalogDto newUserCatalog)
        {
            return Ok(await _userCatalogService.AddUserCatalog(newUserCatalog));
        }
    }
}