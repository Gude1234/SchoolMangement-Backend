namespace SchoolMangement.Models
{
    public class StudentAttendence
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set;}
        public string Course { get; set; }
        public string Date {  get; set;}
        public string Status { get; set;}
        public int StaffId { get; set;}
    }
}
