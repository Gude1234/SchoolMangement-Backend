using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMangement.Models
{
    public class RegisteredSubjects
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string RollNumber { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public int Semester { get; set; }
        public string Course { get; set; }

        [ForeignKey("Staff")]
        public int Staff_Id { get; set; }
    }
}
