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
                new ExpenseItem { Name = "Grande Hot Latte" },
                new ExpenseItem { Name = "Tall Pike Place Roast" }
            };

            var viewModel = new RandomCategoryViewModel
            {
                Category = category,
                ExpenseItems = expenseItems
            };

            return View(viewModel);
        }

        // GET: Categories/ListCategories
        [Route("categories/list")]
        public ActionResult ListCategories()
        {
            var categories = new List<Category>
            {
                new Category { Name = "Coffee" },
                new Category { Name = "Groceries" }
            };

            var viewModel = new ListCategoriesViewModel
            {
                Categories = categories
            };

            return View(viewModel);
        }
    }


}
