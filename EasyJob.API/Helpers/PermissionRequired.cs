using System;
using System.Threading.Tasks;
using EasyJob.DataLayer.Entities;
using EasyJob.DataLayer.Entities.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace EasyJob.API.Helpers
{
    public class PermissionRequiredAttribute : TypeFilterAttribute
    {
        public PermissionRequiredAttribute(string permission) 
            : base(typeof(PermissionRequiredFilter))
        {
            Arguments = new object[] { permission };
        }
        private class PermissionRequiredFilter : IAsyncAuthorizationFilter
        {
            private readonly string _permissionClaimValue;
            private readonly UserManager<UserEntity> _userManager;
            private readonly EasyJobIdentityContext _context;
            
            public PermissionRequiredFilter(string permissionClaimValue)
            {
                _permissionClaimValue = permissionClaimValue;
            }
            public Task OnAuthorizationAsync(AuthorizationFilterContext context)
            {
                bool allow = false;
                var info2 = context.HttpContext.User.Claims;
                foreach (var claim in info2)
                {
                    if (claim.Value == _permissionClaimValue && claim.Type == "Permission")
                    {
                        allow = true;
                    }
                }

                if (!allow)
                {
                    context.Result = new ObjectResult(new
                    {
                        Message = $"[{_permissionClaimValue}] Permission is required to proceed"
                    })
                    {
                        StatusCode = StatusCodes.Status403Forbidden
                    };
                }
                
                return Task.CompletedTask;
            }
        }
    }
}