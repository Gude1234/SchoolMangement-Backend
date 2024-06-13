using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMangement.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Semester {  get; set; }

        [ForeignKey("Course")]
        public int Course_Id { get; set; }

        [ForeignKey("Staff")]
        public int Staff_Id { get; set; }
    }
}
