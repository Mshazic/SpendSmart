using System;
using SpendSartm.Models;

namespace SpendSartm.Repository
{
	public interface IExpenseRepository
	{
		IEnumerable<Expense> GetAll();

		Expense GetById(int expenseId);

		void Insert(Expense expense);

		void Update(Expense expense);

		void Delete(Expense expense);

		void Save();
	}
}

