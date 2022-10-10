using TeacherPortal_FrontEnd.Models.GradesModels;
using TeacherPortal_FrontEnd.Models.Teacher;

namespace TeacherPortal_FrontEnd.Repositories.TeacherRepo
{
    public interface ITeacherRepository
    {
        public Task<Teacher> GetByEmail(string email);
        public Task<List<Grades>> GetStudentsWithGrades(string subjectName);
        public Task<Grades> GetOneStudentGrades(int gradeId);
        public Task<bool> UpdateGrade(Grades updatedGrade);
    }
}
