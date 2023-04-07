using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachingCenter.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Attendance { get; set; }

        public int Progress { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public ExamDate Exam { get; set; }
    }
}
