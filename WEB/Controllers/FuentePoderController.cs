using BL;
using ET;
using ET.DTO;
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FuentePoder fuente)
        {
            try
            {
                if (bl.IngresarFuentePoder(fuente))
                    return RedirectToAction("Index");
                else
                    return View();
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
        public ActionResult Edit(FuentePoder_DTO dto)
        {
            try
            {
                FuentePoder fuente = new();
                fuente.Id = dto.id;
                fuente.Descripcion = dto.descripcion;
                fuente.CantidadConectoresSATA = dto.cantidadConectoresSATA;
                fuente.CantidadConectoresPCIe = dto.cantidadConectoresPCIe;
                fuente.Potencia = dto.potencia;
                fuente.Ancho = dto.ancho;
                fuente.Altura = dto.altura;
                if (bl.ActualizarFuentePoder(fuente))
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
        public ActionResult Delete(int id)
        {
            try
            {
                if (bl.EliminarFuentePoder(id))
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
