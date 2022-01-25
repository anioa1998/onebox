using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneBox.Controllers
{
    public class HomeController : Controller
    {
        //Obsługa kafelka "nadaj paczkę"
        public IActionResult Index()
        {
            return View();
        }
    }
}
