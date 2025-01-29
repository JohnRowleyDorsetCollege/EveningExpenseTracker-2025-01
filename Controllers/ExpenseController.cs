using EveningExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace EveningExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseDbContext _context;
        private readonly ILogger<ExpenseController> _logger;

        public ExpenseController(ExpenseDbContext context, ILogger<ExpenseController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Index has been called");
            var listOfExpenses = _context.Expenses.ToList();
            return View(listOfExpenses);
        }

        public IActionResult CreateEditExpense(int? Id)
        {
            if (Id is not null)
            {
                var item = _context.Expenses.Find(Id);
                return View(item);
            }
            return View();
        }

        public IActionResult Delete(int Id)
        {
            var expenseItem = _context.Expenses.Find(Id);
            _context.Expenses.Remove(expenseItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult CreateEditExpenseForm(Expense model)
        {
            // code here to save the changes to the database
            // and then return to the main expenses page
            // where we will list the expenses we have saved

            if(model.Id == 0)
            {
                _context.Expenses.Add(model);
            } else
            {
                _context.Expenses.Update(model);
            }


            _logger.LogInformation("CreateEditExpenseForm has been called");
           
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
