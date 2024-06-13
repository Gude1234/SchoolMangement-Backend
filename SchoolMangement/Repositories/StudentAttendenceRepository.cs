using Microsoft.EntityFrameworkCore;
using SchoolMangement.Contracts;
using SchoolMangement.Data;
using SchoolMangement.Models;

namespace SchoolMangement.Repositories
{
    public class StudentAttendenceRepository: GenericRepository<StudentAttendence>, IStudentAttendenceRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentAttendenceRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<List<StudentAttendence>> GetAttendecnebyStudentAndSubject(string studentName, string subjectName)
        {
            return await _context.StudentAttendences.Where(x => x.SubjectName == subjectName & x.StudentName == studentName).ToListAsync();
        }

        public async Task<List<StudentAttendence>> GetAttendencebystaff(int staffid)
        {
            return await _context.StudentAttendences.Where(x => x.StaffId == staffid).ToListAsync();
        }

        public async Task<List<StudentAttendence>> GetAttendencebystaffAndDate(string date, int staffid)
        {
            return await _context.StudentAttendences.Where(x => x.StaffId == staffid & x.Date == date).ToListAsync();
        }
    }
}
