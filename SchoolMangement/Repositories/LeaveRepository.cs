using Microsoft.EntityFrameworkCore;
using SchoolMangement.Contracts;
using SchoolMangement.Data;
using SchoolMangement.Models;

namespace SchoolMangement.Repositories
{
    public class LeaveRepository: GenericRepository<LeaveRequest>, ILeaveRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<List<LeaveRequest>> GetByName(string name)
        {
            return await _context.LeaveRequests.Where(x => x.Name == name).ToListAsync();
        }
    }
}
