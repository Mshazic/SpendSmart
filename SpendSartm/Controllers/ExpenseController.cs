using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpendSartm.Data;
using SpendSartm.Models;

namespace SpendSartm.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpensesDbContext _context;

        public ExpenseController(ExpensesDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Expense> allExpenses = _context.Expenses.ToList();

            var totalExpenses = allExpenses.Sum(x => x.Value);

            return View(allExpenses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Expense(Expense model)
        {
            List<Expense> allExpenses = _context.Expenses.ToList();
            
            var totalExpenses = allExpenses.Sum(x => x.Value);

            ViewBag.Expenses = totalExpenses;

            return View(allExpenses);
        }

        public IActionResult CreateEditExpense(int? id)
        {
            if (id != null)
            {
                var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
                return View(expenseInDb);
            }

            return View();
        }

        public IActionResult CreateEditForm(Expense model)
        {
            if (model.Id == 0)
            {
                _context.Expenses.Add(model);

            }
            else
            {
                _context.Expenses.Update(model);
            }
            _context.SaveChanges();
            return Redirect("Expense");
        }

        public IActionResult DeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return Redirect("Expense");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}
