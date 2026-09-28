using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    { 
        private readonly ApplicationDbContext dbContext;
        

        public ExpenseController(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public IActionResult Index()
        {
            var expensesList = dbContext.Expenses.ToList();
            return View(expensesList);
        }

        public IActionResult Create() {
            return View();
        }


        [HttpPost]
        public IActionResult Create (Expense expense)
        {
            dbContext.Add(expense);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
 }
}
