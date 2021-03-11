namespace EasyJob.DataLayer.DTOs.Response.PostsControllerResponses
{
    public class PostResponseDto
    {
        public int Id { get; set; }
        public string JobText { get; set; }
        public int Username { get; set; }
        public string PhotoPath { get; set; }
    }
}