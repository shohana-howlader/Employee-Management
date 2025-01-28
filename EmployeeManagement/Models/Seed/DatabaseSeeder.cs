namespace EmployeeManagement.Models.Seed
{
    public static class DatabaseSeeder
    {
        public static string InsertSql()
        {
            return @"
                INSERT INTO [dbo].[Departments] ([DepartmentName], [ManagerId], [Budget])
                VALUES 
                (N'Sales', NULL, 50000.00),
                (N'Marketing', NULL, 30000.00),
                (N'IT', NULL, 100000.00);
                go

                INSERT INTO [dbo].[Employees] ([Name], [Email], [Phone], [Position], [JoiningDate], [IsDeleted], [DepartmentId])
                VALUES 
                (N'John Doe', N'john.doe@example.com', N'1234567890', N'Sales Manager', '2023-01-15', 0, 1),
                (N'Jane Smith', N'jane.smith@example.com', N'0987654321', N'Marketing Specialist', '2023-02-10', 0, 2),
                (N'Paul Johnson', N'paul.johnson@example.com', N'5551234567', N'IT Technician', '2023-03-05', 0, 3);
                go

                UPDATE [dbo].[Departments]
                SET ManagerId = (SELECT [Id] FROM [dbo].[Employees] WHERE [Position] = N'Sales Manager')
                WHERE [DepartmentName] = N'Sales';
                go

                INSERT INTO [dbo].[PerformanceReviews] ([EmployeeId], [ReviewDate], [ReviewScore], [ReviewNotes])
                VALUES 
                (1, '2024-01-15', 8, N'Excellent leadership in the Sales team.'),
                (2, '2024-01-16', 9, N'Consistently delivering strong marketing campaigns.'),
                (3, '2024-01-17', 7, N'Good technical skills but needs improvement in documentation.');
               ";
        }


    }
}
