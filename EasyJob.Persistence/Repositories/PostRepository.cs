using EasyJob.Domain.Entities;
using EasyJob.Persistence.Context;

namespace EasyJob.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository(EasyJobIdentityContext context) 
            : base(context)
        {
        }
    }
}