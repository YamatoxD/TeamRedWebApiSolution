using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            _mapper = mapper;
        }


        [HttpGet()]
        public IActionResult GetUser()
        {
            var userFromRepo = userRepo.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userFromRepo));
        }
        [HttpGet("{userName}")]
        public IActionResult GetUser(string userName)
        {
            var userFromRepo = userRepo.GetUser(userName);
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userFromRepo));
        }

        //[HttpPut("{id}")]
        //[Route("api/Users/Rate")]
        //public IActionResult Rate(int id, [FromBody] UpdateUser user)
        //{
        //    // map model to entity and set id
        //    var updateUser = _mapper.Map<User>(user);
        //    updateUser.Id = id;

        //    return NoContent();
        //}
    }
}
