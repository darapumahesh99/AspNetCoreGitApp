using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Controllers
{
    public class AccountController : Controller
    {
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
