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
        public ActionResult Create(string descrip, int capacidad, double cons, bool m2)
        {
            try
            {
                Almacenamiento almacenamiento = new();
                almacenamiento.Descripcion = descrip;
                almacenamiento.Capacidad = capacidad;
                almacenamiento.ConsumoEnergia = cons;
                almacenamiento.M2 = m2;
                bl.IngresarAlmacenamiento(almacenamiento);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Edit(int id, string descrip, int capacidad, double cons, bool m2)
        {
            try
            {
                Almacenamiento almacenamiento = new();
                almacenamiento.Descripcion = descrip;
                almacenamiento.Capacidad = capacidad;
                almacenamiento.ConsumoEnergia = cons;
                almacenamiento.M2 = m2;
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
