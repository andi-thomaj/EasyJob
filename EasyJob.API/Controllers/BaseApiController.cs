using EasyJob.Application.Contracts.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyJob.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        public IMediator Mediator { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
    }
}