using EasyJob.Application.Contracts.Persistence;
using EasyJob.Domain.Entities;
using EasyJob.Persistence.Context;

namespace EasyJob.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(EasyJobIdentityContext context) 
            : base(context)
        {
        }
    }
}