using System.Collections.Generic;

namespace EasyJob.DataLayer.Entities
{
    public class Keywords
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}