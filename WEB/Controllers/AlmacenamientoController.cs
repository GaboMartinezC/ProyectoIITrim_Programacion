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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Almacenamiento almacenamiento)
        {
            try
            {
                if(bl.IngresarAlmacenamiento(almacenamiento))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Almacenamiento almacenamiento)
        {
            try
            {
                bl.ActualizarAlmacenamiento(almacenamiento);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (bl.EliminarAlmacenamiento(id))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
