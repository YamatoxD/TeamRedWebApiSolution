using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamRedProject.DbContexts;
using TeamRedProject.Enitites;
using TeamRedProject.Services;
using TeamRedWebApi.Models.UserModel;

namespace TeamRedWebApi.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRealEstateRepo userRepo;
        private readonly IMapper _mapper;

        public UsersController(IRealEstateRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this._mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<UserDto>> GetUser()
        {
            var userFromRepo = userRepo.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userFromRepo));
        }

        [HttpGet("{userName}", Name = "GetUser")]
        public IActionResult GetUser(string userName)
        {
            // example: localhost:5000/api/Users/test1
            var userFromRepo = userRepo.GetUser(userName);
            return Ok(_mapper.Map<UserDto>(userFromRepo));
        }

        [Authorize]
        [HttpPut("Rate")]
        public IActionResult Rate(UpdateUser user)
        {
            var userFromRepo = userRepo.GetUser(user.UserId);
            if (userFromRepo == null) return NotFound();

            bool isValid = userRepo.RateUser(User.Identity.Name, user.UserId, user.Value);
            if (!isValid) return BadRequest();
            userRepo.Save();
            return Ok();
        }
    }
}
