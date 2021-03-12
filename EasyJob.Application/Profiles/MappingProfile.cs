using AutoMapper;
using EasyJob.Application.Features.Posts.Queries.GetPosts;
using EasyJob.Domain.Entities;

namespace EasyJob.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostsDto>().ReverseMap();
        }
    }
}