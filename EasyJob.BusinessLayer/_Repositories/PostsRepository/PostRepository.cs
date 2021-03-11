using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using EasyJob.DataLayer.DTOs.Response.PostsControllerResponses;
using EasyJob.DataLayer.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EasyJob.BusinessLayer._Repositories.PostsRepository
{
    public class PostRepository : IPostRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PostRepository(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<IEnumerable<PostResponseDto>> GetPostsAsync()
        {
            IEnumerable<Posts> listOfPosts = null;
            await using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var getPostsQuery = $"select * from Posts";
                listOfPosts = await connection.QueryAsync<Posts>(getPostsQuery);
            }

            var posts = _mapper.Map<IEnumerable<PostResponseDto>>(listOfPosts);

            return posts;
        }
    }
}