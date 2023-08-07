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
            var listadoAlm = bl.BuscarAlmacenamiento();
            Almacenamiento_DTO alm = listadoAlm.Where(r => r.id == id).FirstOrDefault();
            return View(alm);
        }
        [HttpPost]
        public ActionResult Edit(Almacenamiento_DTO almacenamiento)
        {
            try
            {
                Almacenamiento almacenamientoET = new();
                almacenamientoET.Id = almacenamiento.id;
                almacenamientoET.Descripcion = almacenamiento.descripcion;
                almacenamientoET.ConsumoEnergia = almacenamiento.consumoEnergia;
                almacenamientoET.Capacidad = almacenamiento.capacidad;
                almacenamientoET.M2 = almacenamiento.m2;
                if (bl.ActualizarAlmacenamiento(almacenamientoET))
                    return RedirectToAction("Index");
                else
                    return View();
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
