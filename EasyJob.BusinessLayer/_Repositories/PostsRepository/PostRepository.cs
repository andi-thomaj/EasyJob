using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using EasyJob.DataLayer.DTOs.Response.PostsControllerResponses;
using EasyJob.DataLayer.Entities;
using EasyJob.DataLayer.Entities.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EasyJob.BusinessLayer._Repositories.PostsRepository
{
    public class PostRepository : IPostRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly EasyJobIdentityContext _context;

        public PostRepository(IMapper mapper, IConfiguration configuration, EasyJobIdentityContext context)
        {
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
        }
        public async Task<IEnumerable<PostResponseDto>> GetPostsAsync()
        {
            IEnumerable<Posts> listOfPosts = null;
            await using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var getPostsQuery = $"select * from Posts";
                listOfPosts = await connection.QueryAsync<Posts>(getPostsQuery);
            }

            var p = _context.Posts.ToList();
            var posts = _mapper.Map<IEnumerable<PostResponseDto>>(listOfPosts);

            return posts;
        }
    }
}