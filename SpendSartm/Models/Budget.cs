using System.ComponentModel.DataAnnotations;

namespace SpendSartm.Models
{
    public class Budget
    {

        public int Id { get; set; }
        //Allocate a budget to be spesnd
        [Required]
        public decimal AllocateBudget { get; set; }

    }
}
