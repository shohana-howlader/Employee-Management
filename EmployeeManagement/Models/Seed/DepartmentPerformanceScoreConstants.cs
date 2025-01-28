namespace EmployeeManagement.Models.Seed
{
    public static class DepartmentPerformanceScoreConstants
    {
        public const string ProcedureName = "GetDepartmentPerformanceScores";

        public static string GetSql()
        {
            return @"
        create PROCEDURE GetDepartmentPerformanceScores
            AS
            BEGIN
                SELECT 
                    d.Id,
                    d.DepartmentName,
                    AVG(pr.ReviewScore) AS AverageScore
                FROM Departments d
                JOIN Employees e ON d.Id = e.DepartmentId
                JOIN PerformanceReviews pr ON e.Id = pr.EmployeeId
                GROUP BY d.Id, d.DepartmentName
                HAVING COUNT(pr.Id) > 0
                ORDER BY AverageScore DESC;
            END";
        }
    }
}
