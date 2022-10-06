using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TeacherPortal_FrontEnd.Models.Account;
using TeacherPortal_FrontEnd.Repositories.TeacherRepo;

namespace TeacherPortal_FrontEnd.Controllers
{
    public class TeacherController : Controller
    {
        #region Injection
        private readonly ITeacherRepository _teachers;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeacherController(ITeacherRepository teachers, UserManager<ApplicationUser> userManager)
        {
            _teachers = teachers;
            _userManager = userManager;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var grades = await _teachers.GetStudentsWithGrades(user.SubjectName);
            return View(grades);
        }
    }
}
