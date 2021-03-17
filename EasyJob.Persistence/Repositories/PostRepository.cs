using System.Collections.Generic;
using System.Threading.Tasks;
using EasyJob.Application.Contracts.Persistence;
using EasyJob.Application.Features.Posts.Queries.GetPosts;
using EasyJob.Domain.Entities;
using EasyJob.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyJob.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public async Task<List<PostsDto>> GetAllStuff()
        {
            var posts = await Context.Posts.ToListAsync();
            var mappedPosts = Mapper.Map<List<PostsDto>>(posts);
            return mappedPosts;
        }
    }
}