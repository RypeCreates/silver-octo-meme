using System;
using System.ComponentModel.DataAnnotations;

namespace silver_octo_app.Models
{
    public class Expense
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Category")]
        [Required]
        public long BudgetItemId { get; set; }

        public BudgetItem BudgetItem { get; set; }

        [Required]
        [Display(Name="Cost")]
        public float ExpenseAmount { get; set; }

        public DateTime EntryDate { get; set; }

        [Display(Name="Date Made")]
        public DateTime ExpenseDate { get; set; }
    }
}
