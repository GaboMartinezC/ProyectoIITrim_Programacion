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
        /// <param name="descrip"></param>
        /// <param name="cons"></param>
        /// <param name="ddr"></param>
        /// <param name="cap"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(string descrip, double cons, int ddr, int cap)
        {
            try
            {
                RAM ram = new RAM();
                ram.Descripcion = descrip;
                ram.ConsumoEnergia = cons;
                ram.VersionDDR = ddr;
                ram.Capacidad = cap;
                bl.IngresarRam(ram);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Edit(int id, string descrip, double cons, int ddr, int cap)
        {
            try
            {
                RAM ram = new RAM();
                ram.Id = id;
                ram.Descripcion = descrip;
                ram.ConsumoEnergia = cons;
                ram.VersionDDR = ddr;
                ram.Capacidad = cap;
                bl.ActualizarRam(ram);
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
