using BL;
using ET;
using ET.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class EnfriamientoController : Controller
    {
        public EnfriamientoBL bl = new ();
        public IActionResult Index()
        {
            var lista = bl.BuscarEnfriamiento();
            return View(lista);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Enfriamiento enfriamiento)
        {
            try
            {
                if (bl.IngresarEnfriamiento(enfriamiento))
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
            var listadoEnfriamiento = bl.BuscarEnfriamiento();
            Enfriamiento_DTO dto = listadoEnfriamiento.Where(f => f.id == id).FirstOrDefault();
            return View(dto);
        }
        [HttpPost]
        public ActionResult Edit(Enfriamiento_DTO dto)
        {
            try
            {
                Enfriamiento enfriamiento = new();
                enfriamiento.Id = dto.id;
                enfriamiento.Descripcion = dto.descripcion;
                enfriamiento.IdSocket = dto.idSocket;
                enfriamiento.Liquido = dto.liquido;
                if (bl.ActualizarEnfriamiento(enfriamiento))
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
                if (bl.EliminarEnfriamiento(id))
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
