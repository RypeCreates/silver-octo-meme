using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        //public string ApplicationUserId { get; set; }
        //[ForeignKey("ApplicationUserId")]
        //public ApplicationUser ApplicationUser { get; set; }
    }
}
