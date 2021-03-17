using System.Collections.Generic;
using System.Threading.Tasks;
using EasyJob.Application.Features.Posts.Queries.GetPosts;
using EasyJob.Domain.Entities;

namespace EasyJob.Application.Contracts.Persistence
{
    public interface IPostRepository
    {
        Task<List<PostsDto>> GetAllStuff();
    }
}