using System.Threading.Tasks;
using dms_api.Data;
using dms_api.Dtos.User;
using dms_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dms_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("api/login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRepository.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("api/register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {

            ServiceResponse<int> response = await _authRepository.Register(
                new User
                {
                    DepartmentId = request.DepartmentId,
                    SectionId = request.SectionId,
                    LocationId = request.LocationId,
                    Role = request.Role,
                    Username = request.Username,
                    LastName = request.LastName,
                    FirstName = request.FirstName,
                    MI = request.MI,
                    EmployeeNo = request.EmployeeNo,
                    IsActive = request.IsActive
                }, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("api/get/all")]
        public async Task<IActionResult> List()
        {
            return Ok(await _authRepository.GetAllUsers());
        }
    }
}