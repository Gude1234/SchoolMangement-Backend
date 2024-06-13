using SchoolMangement.Models;

namespace SchoolMangement.Contracts
{
    public interface ILeaveRepository: IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetByName(string name);
    }
}
