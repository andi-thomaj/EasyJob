using System.Collections.Generic;
using System.Threading.Tasks;
using EasyJob.Domain.Entities;

namespace EasyJob.Application.Contracts.Persistence
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllStuff();
    }
}