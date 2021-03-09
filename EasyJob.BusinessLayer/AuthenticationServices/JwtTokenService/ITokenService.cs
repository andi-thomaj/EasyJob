using System.Threading.Tasks;
using EasyJob.DataLayer.Entities;

namespace EasyJob.BusinessLayer.AuthenticationServices.JwtTokenService
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserEntity user);
    }
}