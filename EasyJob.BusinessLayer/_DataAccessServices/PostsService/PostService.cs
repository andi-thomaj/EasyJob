using System.Collections.Generic;
using System.Threading.Tasks;
using EasyJob.BusinessLayer._Repositories.PostsRepository;
using EasyJob.DataLayer.DTOs.Response.PostsControllerResponses;

namespace EasyJob.BusinessLayer._DataAccessServices.PostsService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<PostResponseDto>> GetPostsAsync()
        {
            var posts = await _repository.GetPostsAsync();

            return posts;
        }
    }
}