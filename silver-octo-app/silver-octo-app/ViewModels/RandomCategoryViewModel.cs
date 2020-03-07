using System;
using System.Collections.Generic;
using silver_octo_app.Models;

namespace silver_octo_app.ViewModels
{
    public class RandomCategoryViewModel
    {
        public Category Category { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
