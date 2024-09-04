using System;
using SpendSartm.Data;
using SpendSartm.Models;

namespace SpendSartm.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpensesDbContext _context;

        public ExpenseRepository(ExpensesDbContext context)
        {

            _context = context;
        }
        public void Delete(Expense expense)
        {
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
        }

        public IEnumerable<Expense> GetAll()
        {
            return _context.Expenses.ToList();
        }

        public Expense GetById(int expenseId)
        {
            return _context.Expenses.Find(expenseId);
        }

        public void Insert(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Expense expense)
        {
            _context.Expenses.Update(expense);
            _context.SaveChanges();
        }
    }
}

