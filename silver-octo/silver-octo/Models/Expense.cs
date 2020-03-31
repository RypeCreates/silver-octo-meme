using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace silver_octo.Models
{
    public class Expense
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please specify a Category.")]
        public long BudgetItemId { get; set; }


        public BudgetItem BudgetItem { get; set; }

        [Required]
        [Display(Name = "Cost")]
        public float ExpenseAmount { get; set; }

        public DateTime EntryDate { get; set; }

        [Display(Name = "Date Made")]
        public DateTime ExpenseDate { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
