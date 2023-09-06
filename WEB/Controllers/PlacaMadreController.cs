using BL;
using ET;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class PlacaMadreController : Controller
    {
        private PlacaMadreBL bl = new();

        public IActionResult Index()
        {
            var lista = bl.BuscarPlacaMadre();
            return View(lista);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlacaMadre placaMadre)
        {
            try
            {
                if (bl.IngresarPlacaMadre(placaMadre))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        public IActionResult Edit(int id)
        {

            return View();
        }
    }
}
