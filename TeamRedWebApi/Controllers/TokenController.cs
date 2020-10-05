using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TeamRedProject.Models;
using TeamRedProject.Services;

namespace TeamRedWebApi.Controllers
{
    [Route("token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IRealEstateRepo _realEstateRepo;

        public TokenController(IRealEstateRepo realEstateRepo)
        {
            this._realEstateRepo = realEstateRepo;
        }

        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {
            var token = _realEstateRepo.AuthenticateUser(username, password);           
            if (token == null) return Unauthorized();

            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;

            return Ok(new
            {
                access_token = token,
                token_type = tokenS.Header.Typ,
                userName = username,
                expiration = tokenS.ValidTo,
                issued = tokenS.ValidFrom
            });
        }
    }
}
