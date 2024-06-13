using SchoolMangement.Contracts;
using SchoolMangement.Data;
using SchoolMangement.Models;

namespace SchoolMangement.Repositories
{
    public class StudentRepository:GenericRepository<Student>,IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
