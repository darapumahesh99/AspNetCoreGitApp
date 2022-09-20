using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Controllers
{
    
    [Route("[controller]/[action]")]
    public class HomeController: Controller
    {
        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public string Property { get; set; }

        [Route("~/")]
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

        [Route("about-us/{name:alpha:minlength(5)}")]
        //[Route("about-us/{id:int:min(1)}")]
        public ViewResult AboutUs(string name)
        {
            Title = "About Us";
            return View();
        }

        /*[Route("test1/a{a}")]
        public ViewResult Test1(string a)
        {
            return View();
        }

        [Route("test2/b{a}")]
        public ViewResult Test2(string a)
        {
            return View();
        }*/
    }
}
