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
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRealEstateRepo userRepo;
        private readonly IMapper _mapper;

        public AccountController(IRealEstateRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this._mapper = mapper;
        }

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
