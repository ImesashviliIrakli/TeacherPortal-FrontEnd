using Newtonsoft.Json;
using System.Text;
using TeacherPortal_FrontEnd.Models.GradesModels;

namespace TeacherPortal_FrontEnd.Repositories.GradesRepo
{
    public class GradesRepository : IGradesRepository
    {
        #region Injection
        private readonly HttpClient _httpClient;
        private readonly ILogger<GradesRepository> _logger;

        public GradesRepository(HttpClient httpClient, ILogger<GradesRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        #endregion

        #region Get students with grades
        public async Task<List<Grades>> GetStudentsWithGrades(string subjectName)
        {
            var response = await _httpClient.GetAsync($"https://schoolmanagement-frontend.azurewebsites.net/api/StudentApi/get-grades-one-subject/{subjectName}");
            var gradesJson = await response.Content.ReadAsStringAsync();
            var grades = JsonConvert.DeserializeObject<List<Grades>>(gradesJson);
            return grades;
        }

        public async Task<Grades> GetOneStudentGrade(int gradeId)
        {
            var response = await _httpClient.GetAsync($"https://schoolmanagement-frontend.azurewebsites.net/api/StudentApi/get-one-student-grade/{gradeId}");
            var gradeJson = await response.Content.ReadAsStringAsync();
            var grade = JsonConvert.DeserializeObject<Grades>(gradeJson);
            return grade;
        }
        #endregion

        #region Update grade
        public async Task<bool> UpdateGrade(Grades updatedGrade)
        {
            try
            {
                var gradeJson = JsonConvert.SerializeObject(updatedGrade);

                var requestContent = new StringContent(gradeJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync("https://schoolmanagement-frontend.azurewebsites.net/api/StudentApi/update-student-grade", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Updating grade was successfull");
                    return true;
                }

                _logger.LogError("Something went wrong");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception => {ex}");
                return false;
            }
            
        }
        #endregion
    }
}
