using Newtonsoft.Json;
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
    }
}
