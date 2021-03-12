using System.Collections.Generic;
using System.Threading.Tasks;
using EasyJob.Application.Features.Posts.Queries.GetPosts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyJob.API.Controllers
{
    public class PostsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPostsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PostsDto>>> GetPostsAsync()
        {
            var posts = await _mediator.Send(new GetPostsQuery());

            return Ok(posts);
        }
    }
}