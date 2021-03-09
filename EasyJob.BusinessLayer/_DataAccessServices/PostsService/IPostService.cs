using System.Collections.Generic;
using System.Threading.Tasks;
using EasyJob.DataLayer.DTOs.Response.PostsControllerResponses;

namespace EasyJob.BusinessLayer._DataAccessServices.PostsService
{
    public interface IPostService
    {
        Task<IEnumerable<PostResponseDto>> GetPostsAsync();
    }
}