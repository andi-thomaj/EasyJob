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
        /*public PostRepository()
        {
            var str = Connection.ConnectionString;
        }*/

        public async Task<List<Post>> GetAllStuff()
        {
            var p = await Context.Posts.ToListAsync();
            return p;
        }
    }
}