using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using HosteliteAPI.Controllers_Repository;
using HosteliteAPI.Dtos;
using HosteliteAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HosteliteAPI.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class UsersPhotosController : ControllerBase
    {

      private readonly IUserRepository _repo;
      private readonly IMapper _mapper;
      private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
      private Cloudinary _cloudinary;

      public UsersPhotosController(IUserRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
      {
        _repo = repo;
        _mapper = mapper;
        _cloudinaryConfig = cloudinaryConfig;

        Account acc = new Account
        (
          _cloudinaryConfig.Value.CloudName,
          _cloudinaryConfig.Value.ApiKey,
          _cloudinaryConfig.Value.ApiSecret
        );

        _cloudinary = new Cloudinary(acc);
      }
      
      //[HttpPost]
      //public async Task<IActionResult> AddPhotoForUser(int id, UserPhotoForCreationDto photoForCreationDto)
      //{

      //}
    }
}