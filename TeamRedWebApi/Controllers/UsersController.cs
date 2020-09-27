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
        private readonly RealEstateContext _context;

        public UsersController(IRealEstateRepo userRepo, IMapper mapper, 
            RealEstateContext context)
        {
            this.userRepo = userRepo;
            this._mapper = mapper;
            this._context = context;
        }

        [HttpGet()]
        public IActionResult GetUser()
        {
            var userFromRepo = userRepo.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userFromRepo));
        }
        //[HttpGet("{realEstateId}", Name = "GetRealEstate")]
        [HttpGet("{userName}")]

        public IActionResult GetUser(string userName)
        {
            var userFromRepo = userRepo.GetUser(userName);
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userFromRepo));
        }
        
        //Get api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> OnGet()
        {
            var userItem = userRepo.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userItem));
        }

        //[HttpPut("{id}")]
        //[Route("api/Users/Rate")]
        //public IActionResult Rate(int id, [FromBody] UpdateUser user)
        //{
        //    // map model to entity and set id
        //    var updateUser = _mapper.Map<User>(user);
        //    updateUser.Id = id;
        //
        //    //try
        //    //{
        //    //    // update user 
        //    //    userRepo.Update(user, user.);
        //    //    return Ok();
        //    //}
        //    //catch (AppException ex)
        //    //{
        //    //    // return error message if there was an exception
        //    //    return BadRequest(new { message = ex.Message });
        //    //}
        ////    return NoContent();
        //}
    }
}
