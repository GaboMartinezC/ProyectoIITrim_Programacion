using BL;
using ET;
using ET.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class CaseController : Controller
    {
        private CaseBL bl = new();
        public IActionResult Index()
        {
            var lista = bl.BuscarCase();
            return View(lista);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Case casepc)
        {
            try
            {
                if (bl.IngresarCase(casepc))
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
        [HttpPost]
        public ActionResult Edit(Case_DTO dto)
        {
            try
            {
                Case casepc = new();
                casepc.Id = dto.id;
                casepc.Descripcion = dto.descripcion;
                casepc.IdFactorForma = dto.idFactorForma;
                casepc.RefrigeracionLiquida = dto.refrigeracionLiquida;
                if (bl.ActualizarCase(casepc))
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
                if (bl.EliminarCase(id))
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
