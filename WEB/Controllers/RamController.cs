using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class RamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
