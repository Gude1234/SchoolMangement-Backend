using SchoolMangement.Contracts;
using SchoolMangement.Data;
using SchoolMangement.Models;

namespace SchoolMangement.Repositories
{
    public class CourseRepository: GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
