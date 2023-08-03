using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace WEB.Controllers
{ 
    public class FuentePoderController : Controller
    {
        private FuentePoderBL bl = new();
        public IActionResult Index()
        {
            var lista = bl.BuscarFuentePoder();
            return View(lista);
        }
    }
}
