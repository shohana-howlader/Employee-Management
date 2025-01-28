using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Position { get; set; }

        public DateTime JoiningDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<PerformanceReview> PerformanceReviews { get; set; }
    }
}
