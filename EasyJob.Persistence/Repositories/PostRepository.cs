using EasyJob.Application.Contracts.Persistence;
using EasyJob.Domain.Entities;
using EasyJob.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyJob.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public void futjakot()
        {
            
        }
    }
}