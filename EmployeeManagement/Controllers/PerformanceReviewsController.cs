using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeManagement.Controllers
{
    public class PerformanceReviewsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public PerformanceReviewsController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var performanceReviews = await _context.PerformanceReviews
                .Include(pr => pr.Employee)
                .ToListAsync();
            return View(performanceReviews);
        }

        public IActionResult Create()
        {
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PerformanceReview performanceReview)
        {

            _context.PerformanceReviews.Add(performanceReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var performanceReview = await _context.PerformanceReviews.FindAsync(id);
            if (performanceReview == null) return NotFound();

            ViewBag.Employees = _context.Employees.ToList();
            return View(performanceReview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PerformanceReview performanceReview)
        {
            if (id != performanceReview.Id) return NotFound();


            try
            {
                _context.Update(performanceReview);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PerformanceReviews.Any(pr => pr.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var performanceReview = await _context.PerformanceReviews
                .Include(pr => pr.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performanceReview == null) return NotFound();

            return View(performanceReview);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var performanceReview = await _context.PerformanceReviews.FindAsync(id);
            _context.PerformanceReviews.Remove(performanceReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> DepartmentPerformance()
        {
            var departmentScores = await _context.Departments
                .Where(d => d.Employees.Any(e => e.PerformanceReviews.Any()))
                .Select(d => new
                {
                    DepartmentName = d.DepartmentName,
                    AverageScore = d.Employees
                        .SelectMany(e => e.PerformanceReviews)
                        .Average(pr => (double?)pr.ReviewScore) ?? 0
                })
                .OrderByDescending(d => d.AverageScore)
                .ToListAsync();

            return View(departmentScores);
        }


        //public ActionResult PerformanceScores()
        //{
        //    var departmentScores = GetDepartmentPerformanceScores();
        //    return View(departmentScores);
        //}

        //private List<DepartmentPerformanceScore> GetDepartmentPerformanceScores()
        //{
        //    var scores = new List<DepartmentPerformanceScore>();

        //    var connectionString = _configuration.GetConnectionString("DefaultConnection");

        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        using (var command = new SqlCommand("[dbo].[GetDepartmentPerformanceScores]", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            connection.Open();
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    scores.Add(new DepartmentPerformanceScore
        //                    {
        //                        Id = reader.GetInt32(0),
        //                        DepartmentName = reader.GetString(1),
        //                        // Safely convert the ReviewScore to decimal, assuming it's returned as an int
        //                        AverageScore = reader.IsDBNull(2) ? 0 : Convert.ToDecimal(reader.GetInt32(2))
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return scores;
        //}


        ////public async Task<IActionResult> DepartmentPerformance()
        ////{
        ////    var result = await _context.Departments
        ////        .FromSqlRaw("EXEC GetDepartmentPerformanceScores")
        ////        .ToListAsync();

        ////    return View("DepartmentPerformance", result);
        ////}


    }
}
