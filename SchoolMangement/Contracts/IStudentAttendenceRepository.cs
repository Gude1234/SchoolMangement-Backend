using SchoolMangement.Models;

namespace SchoolMangement.Contracts
{
    public interface IStudentAttendenceRepository: IGenericRepository<StudentAttendence>
    {
        Task<List<StudentAttendence>> GetAttendencebystaffAndDate(string date, int staffid);
        Task<List<StudentAttendence>> GetAttendencebystaff(int staffid);
        Task<List<StudentAttendence>> GetAttendecnebyStudentAndSubject(string studentName, string subjectName);
    }
}
