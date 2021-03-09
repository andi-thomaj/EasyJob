using AutoMapper;
using EasyJob.DataLayer.DTOs.Response.PostsControllerResponses;
using EasyJob.DataLayer.Entities;

namespace EasyJob.BusinessLayer.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostEntity, PostResponseDto>()
                .ReverseMap();
        }
    }
}