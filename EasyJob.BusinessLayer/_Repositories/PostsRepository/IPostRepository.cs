using System.Collections.Generic;
using System.Threading.Tasks;
using EasyJob.DataLayer.DTOs.Response.PostsControllerResponses;

namespace EasyJob.BusinessLayer._Repositories.PostsRepository
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostResponseDto>> GetPostsAsync();
    }
}