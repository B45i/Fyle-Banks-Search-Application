using fyle_backend.Models;
using fyle_backend.ServiceContracts;
using fyle_backend.ServiceContracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace fyle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly string _jwtSecret;

        public AuthController(IUserService userService)
        {
            _userService = userService;
            _jwtSecret = Environment.GetEnvironmentVariable(Constants.JWT_SECRET);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegister)
        {
            userRegister.Username = userRegister.Username.ToLower();
            if (await _userService.UserExist(userRegister.Username))
            {
                return BadRequest("Username already exist");
            }

            var userToCreate = new User
            {
                Username = userRegister.Username
            };

            var createdUser = await _userService.Register(userToCreate, userRegister.Password);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserRegisterDto userLogin)
        {
            var userFromDb = await _userService.Login(userLogin.Username.ToLower(), userLogin.Password);
            if (userFromDb == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromDb.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromDb.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(5),
                SigningCredentials = creds,

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });

        }
    }
}