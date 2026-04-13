using System.ComponentModel.DataAnnotations;

namespace SpendSartm.Models
{
    public class Budget
    {
        //Allocate a budget to be spesnd
        [Required]
        public decimal AllocateBudget { get; set; }

    }
}
