using System.Collections.Generic;
using MediatR;

namespace EasyJob.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<List<PostsDto>>
    {
        
    }
}