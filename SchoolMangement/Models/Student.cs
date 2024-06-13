using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMangement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set;}
        public string Email { get; set; }
        public string password { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("Course")]
        public int Course_Id { get; set; }
   }
}
