﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthenticationAPIService.Interfaces;
using AuthenticationService.Data;
using AuthenticationService.Helpers;
using AuthenticationService.Models;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin, IT Security")]
        [HttpPost("Register")]
        public IActionResult Register([FromBody]RegisterModel register)
        {
            try
            {
                service.Register(register);
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Register failure" });
            }
            return Created("Register", new { Message = "Register completed" });
        }

        [AllowAnonymous]
        [HttpPost("Authen")]
        public IActionResult Authen([FromBody]AuthenticateModel authen)
        {
            var user = service.Authenticate(authen);
            if (user == null)
                return BadRequest(new { Message = "Username or Password is incorrect" });
            return Ok(user);
        }

        [HttpGet("GetUser")]
        public IEnumerable<UserProfile> GetUser()
        {
            var user = service.GetUser();
            return user;
        }
    }
}
