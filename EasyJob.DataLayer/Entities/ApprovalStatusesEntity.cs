namespace EasyJob.DataLayer.Entities
{
    public class ApprovalStatusesEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public PostEntity Post { get; set; }
    }
}