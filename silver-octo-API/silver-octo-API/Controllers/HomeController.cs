using System;
using Microsoft.AspNetCore.Mvc;
using silver_octo_API.Models;

namespace silver_octo_API.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        SilverDatabase dbop = new SilverDatabase();

        [Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/Index")]
        [HttpPost]
        public IActionResult Index([Bind] Login login)
        {
            int res = dbop.LoginCheck(login);
            if(res.Equals(1))
            {
                TempData["Message"] = "Welcome!";
            }
            else
            {
                TempData["Message"] = "Incorrect ID or Password.";
            }
            return View();
        }

        [Route("Home/About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Application Description Page";
            return View();
        }

        [Route("Home/Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Page";
            return View();
        }
    }
}
