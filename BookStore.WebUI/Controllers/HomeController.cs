using BookStore.WebUI.Frameworks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
