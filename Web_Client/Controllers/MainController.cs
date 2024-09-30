using Microsoft.AspNetCore.Mvc;

namespace Web_Client.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Configuration()
        {
            return View();
        }
    }
}
