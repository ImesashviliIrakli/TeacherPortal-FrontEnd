using TeacherPortal_FrontEnd.Models.Teacher;

namespace TeacherPortal_FrontEnd.Repositories.TeacherRepo
{
    public interface ITeacherRepository
    {
        public Task<Teacher> GetByEmail(string email);
    }
}
