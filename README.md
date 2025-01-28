# Employee Management System

## Setup Instructions

### Prerequisites
- .NET 6.0 or later
- SQL Server
- Visual Studio 2022 or later

### Installation Steps
1. **Clone the Repository**
   ```sh
   git clone <your-repository-url>
   cd EmployeeManagement
   ```
2. **Configure Database**
   - Update `appsettings.json` with your SQL Server connection string:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```
   - Run migrations to create the database:
     ```sh
     dotnet ef database update
     ```

3. **Run the Application**
   ```sh
   dotnet run
   ```
   OR launch the project in **Visual Studio** and press **F5**.

## Project Overview and Features
### Overview
The **Employee Management System** is a web-based application that allows users to manage employee records efficiently. The application provides CRUD (Create, Read, Update, Delete) operations and supports search and pagination.

### Features
- **Employee Management:** Add, edit, delete, and view employee details.
- **Search Functionality:** Search employees by name.
- **Pagination:** Users can navigate pages and select how many records to display per page.
- **Department Association:** Assign employees to departments.
- **User-friendly UI:** Responsive design using Bootstrap.

## Additional Notes & Optimizations
- **Security Enhancements:** Implement authentication and authorization.
- **API Integration:** Convert the backend to expose RESTful APIs.
- **Performance Improvements:** Optimize database queries for large datasets.
- **Logging & Error Handling:** Use Serilog for logging and global exception handling.

---

