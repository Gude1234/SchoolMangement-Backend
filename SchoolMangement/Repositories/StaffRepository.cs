using SchoolMangement.Contracts;
using SchoolMangement.Data;
using SchoolMangement.Models;

namespace SchoolMangement.Repositories
{
    public class StaffRepository: GenericRepository<Staff>,IStaffRepository
    {
        public StaffRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
