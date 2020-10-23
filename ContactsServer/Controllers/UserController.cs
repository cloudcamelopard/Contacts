using System;
using System.Linq;
using ContactsServer.Data;
using ContactsServer.DTOs;
using ContactsServer.Models;
using ContactsServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ContactsServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IContactsServerContext _data;
        private readonly IAuthService _authService;

        public UserController(IContactsServerContext db, IAuthService authService)
        {
            _data = db;
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            IActionResult response = Unauthorized();
            try
            {
                if (login.UserName == null || login.Password == null) return response;
                User user = _data.Users.FirstOrDefault(u => u.UserName == login.UserName);
                if (user == null) return response;
                var ok = _authService.VerifyPassword(login.Password, user.Hash, user.Salt);
                if (!ok) return response;
                var jwtToken = _authService.GenerateJWTToken(user);
                response = Ok(new
                {
                    token = jwtToken,
                    userDetails = new UserDTO { FullName = user.FullName, UserName = user.UserName, UserRole = user.UseRole },
                });
            }
            catch(Exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }
            
            return response;
        }
    }
}
