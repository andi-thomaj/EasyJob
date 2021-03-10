using System.Collections.Generic;
using System.Threading.Tasks;
using EasyJob.BusinessLayer._DataAccessServices.PostsService;
using EasyJob.BusinessLayer._Repositories.PostsRepository;
using EasyJob.DataLayer.DTOs.Response.PostsControllerResponses;
using Microsoft.AspNetCore.Mvc;

namespace EasyJob.API.Controllers
{
    public class PostsController : BaseApiController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        /*[HttpGet("GetPostsAsync")]*/
        /*public async Task<IEnumerable<PostResponseDto>> GetPostsAsync()
        {
            var posts = await _postService.GetPostsAsync();

            return posts;
        }*/
    }
}