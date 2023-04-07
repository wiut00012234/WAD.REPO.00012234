using System;
using System.ComponentModel.DataAnnotations;

namespace TeachingCenter.Models
{
    public class ExamDate
    {
        public int ID { get; set; }

        [Required]
        public string Course { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string Notes { get; set; }
    }
}
