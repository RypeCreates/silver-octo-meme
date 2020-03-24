using System;
using System.ComponentModel.DataAnnotations;

namespace silver_octo.Models
{
    public class BudgetItem
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public double Amount { get; set; }

        public long UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
