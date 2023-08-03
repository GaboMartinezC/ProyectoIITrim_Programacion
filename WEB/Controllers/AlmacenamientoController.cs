using BL;
using ET;
using ET.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class AlmacenamientoController : Controller
    {
        private AlmacenamientoBL bl = new();
        public IActionResult Index()
        {
            var lista = bl.BuscarAlmacenamiento();
            return View(lista);
        }
    }
}
