using Microsoft.AspNetCore.Mvc;

namespace SmartTech_Store.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
