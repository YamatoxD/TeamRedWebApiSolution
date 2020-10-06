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
#pragma warning disable CS1591
    [Route("api/Users")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UsersController : ControllerBase
    {
        private readonly IRealEstateRepo userRepo;
        private readonly IMapper _mapper;

        public UsersController(IRealEstateRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>Get all users with id, username, AverageRating, RealEstates and comments</returns>
        /// <response code="200">Returns all the the users</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet()]
        public ActionResult<IEnumerable<UserDto>> GetUser()
        {
            var userFromRepo = userRepo.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userFromRepo));
        }

        /// <summary>
        /// Get a user by his/her username
        /// </summary>
        /// <param name="userName">The username of the user you want to get</param>
        /// <returns>A user with username, Username, AverageRating, RealEstates and Comments</returns>
        /// <response code="200">Returns the specified user from username</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet("{userName}", Name = "GetUser")]
        public IActionResult GetUser(string userName)
        {
            // example: localhost:5000/api/Users/test1
            var userFromRepo = userRepo.GetUser(userName);
            return Ok(_mapper.Map<UserDto>(userFromRepo));
        }

        /// <summary>
        /// Update the rating of a user
        /// </summary>
        /// <param name="user">The User you want to rate</param>
        /// <returns>Returns the rating and the user rated</returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
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
