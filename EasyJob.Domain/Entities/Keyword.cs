using System.Collections.Generic;

namespace EasyJob.Domain.Entities
{
    public class Keyword
    {
        public int Id { get; set; }
        public string KeywordName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}