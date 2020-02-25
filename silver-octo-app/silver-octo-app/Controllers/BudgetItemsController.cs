using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using silver_octo_app.Models;
using silver_octo_app.ViewModels;

namespace silver_octo_app.Controllers
{
    public class BudgetItemsController : Controller
    {
        private ApplicationDbContext _context;

        public BudgetItemsController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            // TODO: Not sure what disposing boolean is supposed to be here.
            this._context.Dispose();
        }

        // Get: BudgetItems/Random
        //public ViewResult Random()
        //{
        //    var budgetItem = new BudgetItem()
        //    {
        //        Amount = 1.00,
        //        CategoryName = "coffee",
        //        Description ="all the caffeine I can spend."
        //    };
        //    return View(budgetItem);

        //}

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ViewResult Index()
        {
            var budgetItems = this._context.BudgetItems.ToList();

            return View(budgetItems);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if(string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Category";
        //    }

        //    return Content(string.Format("pageIndex={0}@sortBy={1}", pageIndex, sortBy));
        //}

        [Route("budgetItems/details")]
        public ActionResult Details(int id)
        {
            var budgetItem = _context.BudgetItems.SingleOrDefault(b => b.Id == id);

            if (budgetItem == null)
            {
                return StatusCode(404);
            }

            return View(budgetItem);
        }

        [Route("budgetItems/entered/{month:range(1,12)}/{day}")]
        public ActionResult ByEntryDate(int month, int day)
        {
            return Content(string.Format("{0}/{1}",month,day));
        }

        //[Route("budgetItems/categories/{category}")]
        //public ActionResult ByCategory(string category)
        //{
        //    List<BudgetItem> BudgetList = new List<BudgetItem>();

        //    return View(BudgetList);
        //}

        [Route("budgetItems/list")]
        public ActionResult ListBudgetItems()
        {
            var budgetItems = this._context.BudgetItems.ToList();

            //return View(budgetItems);

            var viewModel = new ListBudgetItemsViewModel
            {
                BudgetItems = budgetItems
            };

            return View(viewModel);
        }
    }
}
