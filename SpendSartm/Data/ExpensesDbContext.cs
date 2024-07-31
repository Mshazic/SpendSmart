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

		DbSet<Expense> Expenses { get; set; }
	}
}

