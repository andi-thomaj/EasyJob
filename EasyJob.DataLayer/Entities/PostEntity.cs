using System.Collections.Generic;

namespace EasyJob.DataLayer.Entities
{
    public class PostEntity
    {
        public int Id { get; set; }
        public string JobText { get; set; }
        public string Photo { get; set; }
        public bool Promoted { get; set; }
        public string Keywords { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}