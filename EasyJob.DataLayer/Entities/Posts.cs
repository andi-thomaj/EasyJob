using System.Collections.Generic;

namespace EasyJob.DataLayer.Entities
{
    public class Posts
    {
        public int Id { get; set; }
        public string JobText { get; set; }
        public string PhotoPath { get; set; }
        public ApprovalStatuses ApprovalStatuses { get; set; }
        public int ApprovalStatusesId { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public ICollection<Keywords> Keywords { get; set; }
    }
}