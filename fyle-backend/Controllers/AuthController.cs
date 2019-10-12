using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fyle_backend.Models;
using fyle_backend.ServiceContracts;
using fyle_backend.ServiceContracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fyle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
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

            var createdUser = _userService.Register(userToCreate, userRegister.Password);
            return StatusCode(201);
        }
    }
}