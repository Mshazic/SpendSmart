using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

           // var totalExpenses = allExpenses.Sum(x => x.Value);

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
           // var suplus = allExpenses.Average(x => x.)
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
        // ExpenseController.cs
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEditForm(Expense model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEditExpense", model);
            }
            if (model.Id == 0)
            {
                _context.Expenses.Add(model);
                _context.SaveChanges();
            }
            else
            {
                _context.Expenses.Update(model);
                
            }
            _context.SaveChanges();
             //return View("CreateEditExpense", model);
             return RedirectToAction("Expense");
        }
        
      
        public IActionResult DeleteExpense(int? id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }
            //get items from DB
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return RedirectToAction("DeleteExpense");
        }

        //Get - delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //get items from DB
            var expense = _context.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);  // return the view with out object so we can display the info we are getting
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}
