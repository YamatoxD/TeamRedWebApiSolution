using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using TeamRedProject.DbContexts;
using TeamRedProject.Models;
using TeamRedProject.Enitites;
using TeamRedProject.Services;
using TeamRedWebApi.Models.UserModel;

namespace TeamRedWebApi.Controllers
{
#pragma warning disable CS1591
    [Route("api/account")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AccountController : ControllerBase
    {
        private readonly IRealEstateRepo userRepo;
        private readonly IMapper _mapper;

        public AccountController(IRealEstateRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this._mapper = mapper;
        }

        /// <summary>
        /// Register a new user (Create new user)
        /// </summary>
        /// <param name="createUser">The user that should be registered (created)</param>
        /// <returns>Returns the username of the added user</returns>
        /// <response code="200">Creates a new User</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("register")]
        [HttpPost()]
        public IActionResult Register(CreateUserDto createUser)
        {
            if(createUser != null)
            {
                if (!ModelState.IsValid) return BadRequest($"{createUser.UserName} could not be added");
                
                var userEntity = _mapper.Map<User>(createUser);
                userRepo.AddUser(userEntity);
                userRepo.Save();

                return Ok($"{createUser.UserName} has been added");
            }

            return BadRequest("CreateUser Error");
        }


        /// <summary>
        /// Post a request for login.
        /// </summary>
        /// <param name="user">The User that should be logged in</param>
        /// <returns>Returns the token for the logged in user, when the token expires and the info. </returns>
        /// /// <response code="200">Logs the user in</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginUserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var token = userRepo.AuthenticateUser(user.UserName, user.Password);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = token.ValidTo,
                info = "login only used for auth just for now, will be changed later."
            });
        }
    }
}
