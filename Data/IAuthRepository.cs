using System.Collections.Generic;
using System.Threading.Tasks;
using dms_api.Dtos.User;
using dms_api.Models;

namespace dms_api.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<List<User>>> GetAllUsers();
        Task<bool> UserExists(string username);
    }
}