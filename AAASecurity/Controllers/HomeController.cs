using Microsoft.AspNetCore.Mvc;

namespace AAASecurity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult IndexHome()
        {
            return View();
        }
    }
}
