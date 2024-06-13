using Microsoft.EntityFrameworkCore;
using SchoolMangement.Models;

namespace SchoolMangement.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Staff> Staffs { get; set;}
        public DbSet<Student> Students { get; set; }
        public DbSet<RegisteredSubjects> RegisteredSubjects { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<StudentAttendence> StudentAttendences { get; set; }
    }
}
