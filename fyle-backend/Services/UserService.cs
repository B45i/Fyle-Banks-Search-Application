using fyle_backend.Models;
using fyle_backend.ServiceContracts;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace fyle_backend.Services
{
    public class UserService : IUserService
    {
        private postgresContext _dbContext;

        public UserService(postgresContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }
            return VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) ? user : null;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExist(string username)
        {
            return await _dbContext.Users.AnyAsync(x => x.Username == username);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //Todo replace with SequenceEqual
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
