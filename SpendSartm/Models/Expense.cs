using System;
using System.ComponentModel.DataAnnotations;

namespace SpendSartm.Models
{
	public class Expense
	{
		public int Id { get; set; }
		//Allocate a budget to be spesnd
		[Required]
		public decimal Budget { get; set; }

		public decimal Value { get; set; }
		[Required]
		public string?  Decription { get; set; }
	}
}

