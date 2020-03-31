using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using silver_octo.Models;
using silver_octo.Data;
using silver_octo.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace silver_octo.Controllers
{
    [Authorize]
    public class BudgetItemsController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BudgetItemsController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            // TODO: Not sure what disposing boolean is supposed to be here.
            this._context.Dispose();
        }

        [Route("BudgetItems/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var budgetItem = _context.BudgetItems.SingleOrDefault(b => b.Id == id);

            if (budgetItem == null)
            {
                return StatusCode(404);
            }
            ViewBag.Title = "Edit Budget Item";
            return View("BudgetItemForm", budgetItem);
        }


        public ViewResult Index()
        {
            return View();
        }

        [Route("BudgetItems/Details{id}")]
        public ActionResult Details(int id)
        {
            var budgetItem = _context.BudgetItems.SingleOrDefault(b => b.Id == id);

            if (budgetItem == null)
            {
                return StatusCode(404);
            }

            return View(budgetItem);
        }

        public ActionResult New()
        {
            ViewBag.Title = "New Budget Item";
            BudgetItem budgetItem = new BudgetItem();
            return View("BudgetItemForm", budgetItem);
        }

        //[HttpPost]
        //public ActionResult Create(BudgetItem budgetItem)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    budgetItem.ApplicationUserId = userId;
        //    budgetItem.DateCreated = DateTime.Now;
        //    budgetItem.DateUpdated = DateTime.Now;

        //    _context.BudgetItems.Add(budgetItem);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index", "BudgetItems");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BudgetItem budgetItem)
        {
            if (string.IsNullOrEmpty(budgetItem.CategoryName) || !ModelState.IsValid)
            {
                return View("BudgetItemForm", budgetItem);
            }

            if (budgetItem.Id == 0) // if new budgetItem
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                budgetItem.ApplicationUserId = userId;
                budgetItem.DateCreated = DateTime.Now;
                budgetItem.DateUpdated = DateTime.Now;

                _context.BudgetItems.Add(budgetItem);
            }
            else
            {
                budgetItem.DateUpdated = DateTime.Now;

                var budgetItemInDb = _context.BudgetItems.Single(b => b.Id == budgetItem.Id);
                budgetItemInDb.Amount = budgetItem.Amount;
                budgetItemInDb.CategoryName = budgetItem.CategoryName;
                budgetItemInDb.DateUpdated = budgetItem.DateUpdated;
                budgetItemInDb.Description = budgetItem.Description;
            }


            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "BudgetItems");
        }

    }
}
