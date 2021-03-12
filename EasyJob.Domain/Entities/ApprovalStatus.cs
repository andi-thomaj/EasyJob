namespace EasyJob.Domain.Entities
{
    public class ApprovalStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public Post Post { get; set; }
    }
}