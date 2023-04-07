using System.ComponentModel.DataAnnotations;

namespace TeachingCenter.Models
{
    public class EBook
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string URL { get; set; }
    }
}
