using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class PerformanceReview
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        [Range(1, 10)]
        public int ReviewScore { get; set; }

        public string ReviewNotes { get; set; }
    }
}