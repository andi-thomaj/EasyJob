using EasyJob.DataLayer.Entities;
using EasyJob.DataLayer.Entities.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyJob.API.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(UserManager<UserEntity> userManager,
            SignInManager<UserEntity> signInManager,
            RoleManager<IdentityRole> roleManager,
            EasyJobIdentityContext context)
        {
            
        }
    }
}