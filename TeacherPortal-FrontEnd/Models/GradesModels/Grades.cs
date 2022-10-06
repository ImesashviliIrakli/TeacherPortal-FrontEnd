using System.ComponentModel.DataAnnotations;

namespace TeacherPortal_FrontEnd.Models.GradesModels
{
    public class Grades
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentUser { get; set; }

        [Required]
        public string StudentFirstName { get; set; }

        [Required]
        public string StudentLastName { get; set; }

        [Required]
        public string TeacherUser { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public int GradeOne { get; set; }

        [Required]
        public int GradeTwo { get; set; }

        [Required]
        public int GradeThree { get; set; }

        [Required]
        public int GradeFour { get; set; }

        [Required]
        public int GradeFive { get; set; }

        private int average;
        public int AvgGrade
        {
            get { return average; }
            set { average = GradeOne + GradeTwo + GradeThree + GradeFour + GradeFive; }
        }
    }
}
