using SchoolMangement.Models;

namespace SchoolMangement.Contracts
{
    public interface ISubjectRepository: IGenericRepository<Subjects>
    {
        Task<List<Subjects>> GetSubjectsByCourse(int id);
        Task<List<Subjects>> GetSubjectsByStaff(int id);
    }
}
