using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
  public class AuthController : Controller
  {
    private readonly IAuthRepository _repo;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    /// <summary>
    /// injecting the Authrepository repository context that interfaces with the entity framework.
    /// </summary>
    /// <returns></returns>
    public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
    {
      _repo = repo;
      _config = config;
      _mapper = mapper;
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

      var userToCreate = _mapper.Map<User>(userForRegisterDto);

      var createUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

      var userToReturn = _mapper.Map<UserForDetailedDtos>(createUser);

      return CreatedAtRoute("GetUser", new { controller = "Users", id = createUser.Id }, userToReturn);
    }

    /// <summary>
    /// an async API method for logging in users 
    /// </summary>
    /// <returns></returns>
    //POST: api/Auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
    {  
      //throw new Exception( "computer says no");
      var userFromRepo = await _repo.Login(userForLoginDto.Email.ToLower());
      if (userFromRepo == null)
      {
        return Unauthorized();
      }
      else if (!await _repo.VerifyPasswordHash(userForLoginDto.Password, userFromRepo.PasswordHash,userFromRepo.PasswordSalt))
      {
        return Unauthorized();
      }
      else
      {
        var claims = new[]
            {
                  new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                  new Claim(ClaimTypes.Name, userFromRepo.Firstname)
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

        return Ok(new { token = tokenHandler.WriteToken(token) });
        
        //using responseModel for returning error.. i stopped using it
        //return Json(new ResponseModel()
        //{
        //  state = RequestState.success,
        //  msg = "",
        //  data = tokenHandler.WriteToken(token)
        //});

        //if (userFromRepo == null)
        //  return Json(new ResponseModel()
        //  {
        //    state = RequestState.failed,
        //    msg = "Email and Password combination doesn't exist"
        //  });
        //else if (!await _repo.VerifyPasswordHash(userForLoginDto.Password, userFromRepo.PasswordHash, 
        //        userFromRepo.PasswordSalt))
        //{
        //  return Json(new ResponseModel()
        //  {
        //    state = RequestState.failed,
        //    msg = "Email and Password combination does not exist"
        //  });
        //}
        //else
        //{
        //  var claims = new[]
        //      {
        //          new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
        //          new Claim(ClaimTypes.Name, userFromRepo.Email.ToString())
        //      };
        //  var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

        //  var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //  var tokenDescriptor = new SecurityTokenDescriptor
        //  {
        //    Subject = new ClaimsIdentity(claims),
        //    Expires = DateTime.Now.AddDays(1),
        //    SigningCredentials = creds
        //  };
        //  var tokenHandler = new JwtSecurityTokenHandler();
        //  var token = tokenHandler.CreateToken(tokenDescriptor);

        //  //return Ok(new { token = tokenHandler.WriteToken(token) });
        //  return Json(new ResponseModel()
        //  {
        //    state = RequestState.success,
        //    msg = "",
        //    data = tokenHandler.WriteToken(token)
        //  });

      }
    //generate token

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