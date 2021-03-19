using System.Threading.Tasks;
using dms_api.Dtos.UserCatalog;
using dms_api.Models;
using dms_api.Services.UserCatalogService;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("api/delete")]
        public async Task<IActionResult> Delete(DeleteUserCatalog deleteUserCatalog)
        {
            return Ok(await _userCatalogService.DeleteUserCatolog(deleteUserCatalog));
        }

        [HttpGet("api/get")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userCatalogService.GetUserCatalogs());
        }

        [HttpGet("api/get/{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            return Ok(await _userCatalogService.GetUserCatalogById(id));
        }
    }
}