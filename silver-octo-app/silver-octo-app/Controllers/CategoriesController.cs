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

        // TODO: Remove CategoryList field after relational database setup.
        private List<Category> CategoryList = new List<Category>
            {
                new Category { Name = "Coffee", Id = 0, Description = "The good stuff!" },
                new Category { Name = "Groceries", Id = 1, Description = "Food and things." },
                new Category { Name = "cat3", Id = 2, Description = "" },
                new Category { Name = "cat4", Id = 3, Description = "" },
                new Category { Name = "cat5", Id = 4, Description = "" },
                new Category { Name = "cat6", Id = 5, Description = "" },
                new Category { Name = "cat7", Id = 6, Description = "" }
            };

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
            var categories = CategoryList;

            var viewModel = new ListCategoriesViewModel
            {
                Categories = categories
            };

            return View(viewModel);
        }

        // GET: Categories/Id
        [Route("categories/{id}")]
        public ActionResult Index(int Id)
        {
            return View(GetById(Id));
        }


        // Private Methods

        private Category GetById(int Id)
        {
            return CategoryList.FirstOrDefault(x => x.Id == Id);
        }
    }


}
