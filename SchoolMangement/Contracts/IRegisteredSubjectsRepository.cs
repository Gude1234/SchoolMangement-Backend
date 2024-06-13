using SchoolMangement.Models;

namespace SchoolMangement.Contracts
{
    public interface IRegisteredSubjectsRepository: IGenericRepository<RegisteredSubjects>
    {
        Task<List<RegisteredSubjects>> GetByStaff(int studentId);
        Task<List<RegisteredSubjects>> GetByStudent(string name);
    }
}
