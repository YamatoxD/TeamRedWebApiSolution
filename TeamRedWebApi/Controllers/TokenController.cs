﻿using System;
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
#pragma warning disable CS1591
    [Route("token")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class TokenController : ControllerBase
    {
        private readonly IRealEstateRepo _realEstateRepo;

        public TokenController(IRealEstateRepo realEstateRepo)
        {
            this._realEstateRepo = realEstateRepo;
        }
        /// <summary>
        /// Authentication with username and password. (Login)
        /// </summary>
        /// <param name="username">The username of the user that wants to login</param>
        /// <param name="password">The password of the user that wants to login</param>
        /// <returns>returns a token for the user</returns>
        /// <response code="200">Returns the Token of the Authorized User</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {
            var token = _realEstateRepo.AuthenticateUser(username, password);           
            if (token == null) return Unauthorized();

            return Ok(new
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                token_type = token.Header.Typ,
                userName = username,
                expiration = token.ValidTo,
                issued = token.ValidFrom
            });
        }
    }
}
