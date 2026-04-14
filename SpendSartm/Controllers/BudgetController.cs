using Microsoft.AspNetCore.Mvc;
using SpendSartm.Data;
using SpendSartm.Models;

namespace SpendSartm.Controllers
{

    public class BudgetController : Controller
    {
        private readonly ExpensesDbContext _context;

        public BudgetController(ExpensesDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEditBudget(int? id)
        {
            if (id != null)
            {
                var budgetInDb = _context.Budgets.SingleOrDefault(x => x.Id == id);
                return View(budgetInDb);
            }
            return View();
        }
         [HttpPost]
         public IActionResult CreateEditBudgetForm(Budget model)
         {
             if (!ModelState.IsValid)
             {
                 return View("CreateEditBudget", model);
             }
             if (model.Id == 0)
             {
                 _context.Budgets.Add(model);
                 _context.SaveChanges();
             }
             else
             {
                 _context.Budgets.Update(model);
             }
             _context.SaveChanges();
             return RedirectToAction("Index");
        }

        public IActionResult DeleteBudget(int id)
        {
            var budgetInDb = _context.Budgets.SingleOrDefault(x => x.Id == id);
            if (budgetInDb == null)
            {
                return NotFound();
            }
            _context.Budgets.Remove(budgetInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DetailsBudget(int id)
        {
            var budgetInDb = _context.Budgets.SingleOrDefault(x => x.Id == id);
            if (budgetInDb == null)
            {
                return NotFound();
            }
            return View(budgetInDb);
        }
        public IActionResult BudgetIndex() 
        {
            LinkedList<Budget> linkedListBudget = new LinkedList<Budget>(_context.Budgets.ToList());
            return View(linkedListBudget);
        }
    }
}
