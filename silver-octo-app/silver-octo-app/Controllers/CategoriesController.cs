using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using silver_octo_app.Models;
using silver_octo_app.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace silver_octo_app.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories/Random
        [Route("categories/Random")]
        public ActionResult Random()
        {
            var category = new Category { Name = "Coffee", Description = "The good stuff!" };
            var expenseItems = new List<ExpenseItem>
            {
                new ExpenseItem { Name = "Item 1" },
                new ExpenseItem { Name = "Item 2" }
            };

            var viewModel = new RandomCategoryViewModel
            {
                Category = category,
                ExpenseItems = expenseItems
            };

            return View(viewModel);
        }
    }
}
