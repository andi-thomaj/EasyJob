using System.Threading.Tasks;
using EasyJob.Application.Models.Authentication;

namespace EasyJob.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<AuthenticationResponse> RegisterAsync(RegistrationRequest request);
    }
}