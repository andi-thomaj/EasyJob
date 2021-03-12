using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyJob.Application.Contracts.Identity;
using EasyJob.Application.Models.Authentication;
using EasyJob.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EasyJob.Infrastructure.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly SymmetricSecurityKey _key;

        public AuthenticationService(IConfiguration configuration, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]))
        }
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AuthenticationResponse> RegisterAsync(RegistrationRequest request)
        {
            bool userExist = await _context.Users.AnyAsync(u => u.Email == request.Email);
            if (userExist)
                return Ok(new ApiResponse {Succeeded = false, Message = "Failed."});
     
            var userCreationResult = await _userManager.CreateAsync(new Users
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                CompanyName = request.CompanyName
            }, request.Password);

            if (!userCreationResult.Succeeded)
                return Ok(new ApiResponse {Succeeded = false, Message = "Failed."});

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
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

        private async Task<string> CreateToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("companyName", user.CompanyName),
                new Claim("username", user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
           
            claims.AddRange(userClaims);

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,
                Issuer = _configuration["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}