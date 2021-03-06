﻿using System.Threading.Tasks;
using EasyJob.Application.Contracts.Identity;
using EasyJob.Application.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace EasyJob.API.Controllers
{
    public class AccountsController : BaseApiController
    {
        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest request)
        {
            return Ok(await AuthenticationService.AuthenticateAsync(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationRespone>> Register(RegistrationRequest request)
        {
            return Ok(await AuthenticationService.RegisterAsync(request));
        }

        /*[HttpGet("GetSuccess")]
        [PermissionRequired("Permissions.Posts.Create")]
        public async Task<string> Success()
        {
            return "Success";
        }*/
    }
}