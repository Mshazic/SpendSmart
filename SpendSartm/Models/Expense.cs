using System;
using System.ComponentModel.DataAnnotations;

namespace SpendSartm.Models
{
	public class Expense
	{
		public int Id { get; set; }
		
		public decimal Value { get; set; }
		[Required]
		public string? Discription { get; set; } = string.Empty;
	}
}

