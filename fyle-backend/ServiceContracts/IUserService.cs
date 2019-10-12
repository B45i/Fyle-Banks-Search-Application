using fyle_backend.Models;
using System.Threading.Tasks;

namespace fyle_backend.ServiceContracts
{
    public interface IUserService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
