using System.ComponentModel.DataAnnotations;

namespace TeacherPortal_FrontEnd.Models.Teacher
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(5)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime BirthDate { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

        [Required]
        public string SubjectName { get; set; }
    }
}
