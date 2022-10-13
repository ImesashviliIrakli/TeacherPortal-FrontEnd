using TeacherPortal_FrontEnd.Models.GradesModels;
using TeacherPortal_FrontEnd.Models.TeacherModels;

namespace TeacherPortal_FrontEnd.Repositories.TeacherRepo
{
    public interface ITeacherRepository
    {
        public Teacher GetByEmail(string email);
        public Task<bool> Add(Teacher body);
    }
}
