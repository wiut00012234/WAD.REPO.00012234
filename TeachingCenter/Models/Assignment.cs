using System;
using System.ComponentModel.DataAnnotations;

namespace TeachingCenter.Models
{
    public class Assignment
    {
        public int ID { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public string Notes { get; set; }
    }
}
