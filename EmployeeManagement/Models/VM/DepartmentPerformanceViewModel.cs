namespace EmployeeManagement.Models.VM
{
    public class DepartmentPerformanceViewModel
    {
        public int? Id { get; set; }
        public string? DepartmentName { get; set; }
        public decimal? AverageScore { get; set; }
        public decimal? Budget { get; set; }
    }
}
