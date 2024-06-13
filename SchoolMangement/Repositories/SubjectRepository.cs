using Microsoft.EntityFrameworkCore;
using SchoolMangement.Contracts;
using SchoolMangement.Data;
using SchoolMangement.Models;

namespace SchoolMangement.Repositories
{
    public class SubjectRepository:GenericRepository<Subjects>,ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<List<Subjects>> GetSubjectsByCourse(int id)
        {
            return await _context.Set<Subjects>().Where(x => x.Course_Id == id).ToListAsync();
        }

        public async Task<List<Subjects>> GetSubjectsByStaff(int id)
        {
            return await _context.Subjects.Where(x => x.Staff_Id == id).ToListAsync();
        }
    }
}
