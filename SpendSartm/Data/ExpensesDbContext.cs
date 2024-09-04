using System;
using Microsoft.EntityFrameworkCore;
using SpendSartm.Models;

namespace SpendSartm.Data
{
	public class ExpensesDbContext : DbContext
	{
		public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options) 
		{
		}

        public DbSet<Expense> Expenses { get; set; }

      
    }
}

