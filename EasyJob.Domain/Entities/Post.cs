using System.Collections.Generic;

namespace EasyJob.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string JobText { get; set; }
        public string PhotoPath { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public int ApprovalStatusId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Keyword> Keywords { get; set; }
    }
}