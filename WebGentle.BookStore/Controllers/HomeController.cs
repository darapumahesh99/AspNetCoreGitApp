using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Controllers
{
    public class HomeController: Controller
    {
        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public string Property { get; set; }
        public ViewResult Index()
        {
            //var obj = new { id = 1, name = "mahesh" };
            //return View(obj);
            //return View("~/TempView/TempVie.cshtml");
            //return View("TempView/TempVie.cshtml");

            // ViewData
            Title = "Home";
            Property = "Mahesh Darapu";
            return View(); //searching from root level
        }
        public ViewResult AboutUs()
        {
            Title = "About Us";
            return View();
        }
    }
}
