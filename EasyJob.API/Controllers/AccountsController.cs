using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyJob.API.Helpers;
using EasyJob.BusinessLayer.AuthenticationServices;
using EasyJob.BusinessLayer.AuthenticationServices.JwtTokenService;
using EasyJob.DataLayer.DTOs.Request.AccountsControllerRequests;
using EasyJob.DataLayer.DTOs.Response.AccountsControllerResponses;
using EasyJob.DataLayer.Entities;
using EasyJob.DataLayer.Entities.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace EasyJob.API.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly EasyJobIdentityContext _context;
        private readonly ITokenService _tokenService;

        public AccountsController(UserManager<UserEntity> userManager,
            SignInManager<UserEntity> signInManager,
            RoleManager<IdentityRole<int>> roleManager,
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

        [HttpPost("Register")]
        public async Task<ActionResult<UserResponseDto>> Register(RegisterDto registerDto)
        {
            bool userExist = await _context.Users.AnyAsync(u => u.Email == registerDto.Email);
            if (userExist)
                return Ok(new ApiResponse {Succeeded = false, Message = "Failed."});
     
            var userCreationResult = await _userManager.CreateAsync(new UserEntity
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                CompanyName = registerDto.CompanyName
            }, registerDto.Password);

            if (!userCreationResult.Succeeded)
                return Ok(new ApiResponse {Succeeded = false, Message = "Failed."});

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);
            var roleAssigningResult = await _userManager.AddToRoleAsync(user, "Basic");
            if (!roleAssigningResult.Succeeded)
                return Ok(new ApiResponse {Succeeded = false, Message = "Failed."});

            var permissionsList = Permissions.GeneratePermissionsForModule(ControllerName.Posts);
            var claims = permissionsList.Select(permission => new Claim("Permission", permission));
            var claimsAssigningResult = await _userManager.AddClaimsAsync(user, claims);
            if (!claimsAssigningResult.Succeeded)
                return Ok(new ApiResponse {Succeeded = false, Message = "Failed."});
            
            return Ok(new UserResponseDto
            {
                Token = await _tokenService.CreateToken(user)
            });
        }

        [HttpGet("GetSuccess")]
        [PermissionRequired("Permissions.Posts.Create")]
        public async Task<string> Success()
        {
            return "Success";
        }
    }
}