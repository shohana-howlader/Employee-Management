using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        [Required]
        public decimal Budget { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}