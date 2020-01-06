using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HosteliteAPI.Data;
using HosteliteAPI.Dtos;
using HosteliteAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HosteliteAPI.Controllers
{
    /// <summary>
    /// the Auth controller responsible for controlling our auth APIs
    /// </summary>
    /// <returns></returns>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        /// <summary>
        /// injecting the Authrepository repository context that interfaces with the entity framework.
        /// </summary>
        /// <returns></returns>
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        /// <summary>
        /// an async API method for registring users 
        /// </summary>
        /// <returns></returns>
        // POST: api/Auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            if (!string.IsNullOrEmpty(userForRegisterDto.Email))
                userForRegisterDto.Email = userForRegisterDto.Email.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Email))
                ModelState.AddModelError("Email", "Email address already exist");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userToCreate = new User
            {
                Email = userForRegisterDto.Email
            };

            var createUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        /// <summary>
        /// an async API method for logging in users 
        /// </summary>
        /// <returns></returns>
        //POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Email.ToLower(), userForLoginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();
            //generate token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Email.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return Ok(new { token = tokenHandler.WriteToken(token)});

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //  Subject = new ClaimsIdentity(new Claim[]
            //{
            //new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
            //new Claim(ClaimTypes.Name, userFromRepo.Email.ToString())
            //}),

            //Expires = DateTime.Now.AddDays(1),
            //SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var tokenString = tokenHandler.WriteToken(token);

            //return Ok(new { tokenString });
        }
    }
}