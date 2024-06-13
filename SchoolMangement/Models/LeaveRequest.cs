namespace SchoolMangement.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set;}
        public int Days { get; set; }
        public string status { get; set; }
    }
}
