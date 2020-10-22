using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ContactsServer.Data;
using ContactsServer.DTOs;
using ContactsServer.Models;
using ContactsServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ContactsServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ContactsServerContext _data;
        private readonly IAuthService _authService;

        public UserController(ContactsServerContext db, IConfiguration config, IAuthService authService)
        {
            _data = db;
            _config = config;
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
            catch(Exception e)
            {

            }
            
            return response;
        }

        //string GenerateJWTToken(User userInfo)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
        //        new Claim("fullName", userInfo.FullName.ToString()),
        //        new Claim("role", userInfo.UseRole),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    };
        //    var token = new JwtSecurityToken(
        //    issuer: _config["Jwt:Issuer"],
        //    audience: _config["Jwt:Audience"],
        //    claims: claims,
        //    expires: DateTime.Now.AddMinutes(30),
        //    signingCredentials: credentials
        //    );
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
