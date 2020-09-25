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
    [Route("api/account/register")]
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

        [HttpPost()]
        public IActionResult Regisetr(CreateUserDto createUser)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (createUser.Password != createUser.ConfirmPassword) return BadRequest();

            var userEntity = _mapper.Map<User>(createUser);
            userRepo.AddUser(userEntity);
            userRepo.Save();

            return Ok();
        }
    }
}
