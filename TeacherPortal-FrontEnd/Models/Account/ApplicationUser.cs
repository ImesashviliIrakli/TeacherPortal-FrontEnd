using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TeacherPortal_FrontEnd.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [Required]
        public string PersonalId { get; set; }
    }
}
