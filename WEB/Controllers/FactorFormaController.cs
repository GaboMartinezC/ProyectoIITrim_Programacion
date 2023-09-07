using BL;
using ET;
using ET.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class FactorFormaController : Controller
    {
        private FactorFormaBL bl = new FactorFormaBL();
        public IActionResult Index()
        {
            return View(bl.BuscarFactorForma());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FactorForma factorForma)
        {
            try 
            {
                if (bl.IngresarFactorForma(factorForma))
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
            FactorForma_DTO dto = bl.BuscarFactorForma().Where(r => r.id == id).FirstOrDefault();
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FactorForma_DTO dto)
        {
            try
            {
                FactorForma factorForma = new FactorForma();
                factorForma.Id = dto.id;
                factorForma.Descripcion = dto.descripcion;
                factorForma.Ancho = dto.ancho;
                factorForma.Largo = dto.largo;
                if (bl.ActualizarFactorForma(factorForma))
                    return RedirectToAction("Index");
                else
                    return View(dto);
            }
            catch(Exception ex)
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
                if (bl.EliminarFactorForma(id))
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
