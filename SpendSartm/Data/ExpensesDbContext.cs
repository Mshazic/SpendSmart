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

<<<<<<< Updated upstream
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Expense>().HasData(
				new Expense
				{
					Id = 1,
                    Discription  = "Groceries",
					Value = 150.00m,
         
                },
				new Expense
				{
					Id = 2,
					Discription = "Rent",
					Value = 1200.00m,
                   
                },
				new Expense
				{
					Id = 3,
					Discription = "Utilities",
					Value = 200.00m,
                  
                }
			);
           }



    }
}

