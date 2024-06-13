using Microsoft.EntityFrameworkCore;
using SchoolMangement.Contracts;
using SchoolMangement.Data;
using SchoolMangement.Models;

namespace SchoolMangement.Repositories
{
    public class RegisteredSubjectsRepository:GenericRepository<RegisteredSubjects>, IRegisteredSubjectsRepository
    {
        private readonly ApplicationDbContext _context;

        public RegisteredSubjectsRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<List<RegisteredSubjects>> GetByStaff(int stafftId)
        {
            return await _context.RegisteredSubjects.Where(x => x.Staff_Id == stafftId).ToListAsync();
        }

        public async Task<List<RegisteredSubjects>> GetByStudent(string name)
        {
            return await _context.RegisteredSubjects.Where(x => x.StudentName == name).ToListAsync();
        }
    }
}
