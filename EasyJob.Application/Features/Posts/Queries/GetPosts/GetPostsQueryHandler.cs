using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyJob.Application.Contracts.Persistence;
using EasyJob.Domain.Entities;
using MediatR;

namespace EasyJob.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Post> _repository;

        public GetPostsQueryHandler(IMapper mapper,
            IAsyncRepository<Post> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<PostsDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var postsFromDb = await _repository.ListAllAsync();
            var postsMapped = _mapper.Map<List<PostsDto>>(postsFromDb);
            
            return postsMapped;
        }
    }
}