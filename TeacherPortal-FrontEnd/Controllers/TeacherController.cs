using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TeacherPortal_FrontEnd.Models.Account;
using TeacherPortal_FrontEnd.Models.GradesModels;
using TeacherPortal_FrontEnd.Repositories.TeacherRepo;

namespace TeacherPortal_FrontEnd.Controllers
{
    [Authorize]
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

        #region Details page 
        public async Task<IActionResult> Details(int id)
        {
            var grade = await _teachers.GetOneStudentGrades(id);
            return View(grade);
        }
        #endregion

        #region Update Grade
        [HttpPut]
        public async Task<IActionResult> UpdateGrade(Grades updatedGrades)
        {
            var user = await _userManager.GetUserAsync(User);

            updatedGrades.TeacherUser = user.Email;

            var updateGrade = await _teachers.UpdateGrade(updatedGrades);

            if (!updateGrade)
            {
                return Json(new { success = false });

            }
            return Json(new { success = true });
        }
        #endregion
    }
}
