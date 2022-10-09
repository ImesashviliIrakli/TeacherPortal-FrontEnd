using Newtonsoft.Json;
using TeacherPortal_FrontEnd.Models;
using TeacherPortal_FrontEnd.Models.GradesModels;
using TeacherPortal_FrontEnd.Models.Teacher;

namespace TeacherPortal_FrontEnd.Repositories.TeacherRepo
{
    public class TeacherRepository : ITeacherRepository
    {
        #region Injection
        private readonly HttpClient _httpClient;
        public TeacherRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion

        #region Get
        public async Task<Teacher> GetByEmail(string email)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44310/api/Teacher/get-by-email/{email}");
            var studentJson = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<Teacher>(studentJson);
            return students;
        }
        #endregion

        #region Get students with grades
        public async Task<List<Grades>> GetStudentsWithGrades(string subjectName)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44310/api/Teacher/get-student-grades/{subjectName}");
            var gradesJson = await response.Content.ReadAsStringAsync();
            var grades = JsonConvert.DeserializeObject<List<Grades>>(gradesJson);
            return grades;
        }
        #endregion

        #region Get grades for single student
        public async Task<Grades> GetOneStudentGrades(int gradeId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44310/api/Teacher/get-one-student-grades/{gradeId}");
            var gradeJson = await response.Content.ReadAsStringAsync();
            var grade = JsonConvert.DeserializeObject<Grades>(gradeJson);
            return grade;
        }
        #endregion
    }
}
