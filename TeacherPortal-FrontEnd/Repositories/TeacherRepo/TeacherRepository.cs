using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text;
using TeacherPortal_FrontEnd.Data;
using TeacherPortal_FrontEnd.Models;
using TeacherPortal_FrontEnd.Models.GradesModels;
using TeacherPortal_FrontEnd.Models.TeacherModels;

namespace TeacherPortal_FrontEnd.Repositories.TeacherRepo
{
    public class TeacherRepository : ITeacherRepository
    {
        #region Injection
        private readonly AppDbContext _context;
        private readonly ILogger<TeacherRepository> _logger;
        public TeacherRepository(AppDbContext context, ILogger<TeacherRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        #region Get
        public Teacher GetByEmail(string email)
        {

            string methodName = nameof(GetByEmail);

            if (string.IsNullOrEmpty(email))
            {
                _logger.LogError($"{methodName} => Need Email to get student");
                return null;
            }

            try
            {
                var teacher = _context.Teachers.FirstOrDefault(x => x.Email == email);
                if (teacher == null)
                {
                    _logger.LogError($"{methodName} => Couldn't get student");
                    return null;
                }

                return teacher;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{methodName} => Exception: {ex}");
                return null;
            }

        }
        #endregion

        #region Add
        public async Task<bool> Add(Teacher body)
        {
            string methodName = nameof(Add);
            if (body == null)
            {
                _logger.LogError($"{methodName} => The model body was NULL");
                return false;
            }

            try
            {
                await _context.Teachers.AddAsync(body);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"{methodName} => The teacher {body.FirstName} {body.LastName} was added successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{methodName} => Exception: {ex}");
                return false;
            }
        }
        #endregion
    }
}
