using System.Threading.Tasks;
using EasyJob.BusinessLayer.AuthenticationServices.JwtTokenService;
using EasyJob.DataLayer.DTOs.Request.AccountsControllerRequests;
using EasyJob.DataLayer.DTOs.Response.AccountsControllerResponses;
using EasyJob.DataLayer.Entities;
using EasyJob.DataLayer.Entities.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyJob.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EasyJobIdentityContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<UserEntity> userManager,
            SignInManager<UserEntity> signInManager,
            RoleManager<IdentityRole> roleManager,
            EasyJobIdentityContext context,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserResponseDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Ooops wrong password.");
            }
            
            return Ok(new UserResponseDto
            {
                Token = await _tokenService.CreateToken(user)
            });
        }

        [Authorize(Policy = PolicyTypes.Users.Manage)]
        public async Task<string> Success()
        {
            return "Success";
        }
    }
}