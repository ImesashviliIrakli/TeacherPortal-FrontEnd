using TeacherPortal_FrontEnd.Models.GradesModels;

namespace TeacherPortal_FrontEnd.Repositories.GradesRepo
{
    public interface IGradesRepository
    {
        public Task<List<Grades>> GetStudentsWithGrades(string subjectName);
        public Task<Grades> GetOneStudentGrade(int gradeId);
        public Task<bool> UpdateGrade(Grades updatedGrade);
    }
}
