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
        /// POST: ProductController/Create
        /// </summary>
        /// <param name="descrip"></param>
        /// <param name="ddr"></param>
        /// <param name="capacidad"></param>
        /// <param name="cons"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string descrip, int ddr, int capacidad, int cons)
        {
            try
            {
                RAM ram = new RAM();
                ram.Descripcion = descrip;
                ram.VersionDDR = ddr;
                ram.Capacidad = capacidad;
                ram.ConsumoEnergia = cons;
                bl.IngresarRam(ram);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
