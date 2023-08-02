using Microsoft.AspNetCore.Mvc;
using BL;
using ET;
using ET.DTO;
using WEB.Utilities;

namespace WEB.Controllers
{
    public class RamController : Controller
    {
        private RAM_BL bl = new RAM_BL();
        public IActionResult Index()
        {
            var listadoRam = bl.BuscarRam();
            return View(listadoRam);
        }
        /// <summary>
        /// GET: ProductController/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// POST: ProductController/Create
        /// </summary>
        /// <param name="ram"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RAM_DTO ram)
        {
            try
            {
                RAM ramEstatica = new();
                ramEstatica.Descripcion = ram.Descripcion;
                ramEstatica.VersionDDR = Convert.ToInt32(ram.VersionDDR);
                ramEstatica.ConsumoEnergia = Convert.ToDouble(ram.ConsumoEnergia);
                ramEstatica.Capacidad = Convert.ToInt32(ram.Capacidad);
                bool resp = bl.IngresarRam(ramEstatica);
                if (resp)
                    return RedirectToAction("Index");
                else
                    return View();
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
        /// <summary>
        /// POST: ProductController/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (bl.EliminarRam(id))
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
