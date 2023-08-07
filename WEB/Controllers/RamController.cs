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
        [HttpPost]
        public ActionResult Create(RAM ram)
        {
            try
            {
                if (bl.IngresarRam(ram))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult Edit(int id)
        {
            var listadoProd = bl.BuscarRam();
            RAM_DTO ram = listadoProd.Where(p => p.Id == id).FirstOrDefault();
            return View(ram);
        }
        [HttpPost]
        public ActionResult Edit(RAM_DTO ram)
        {
            try
            {
                RAM ramET = new();
                ramET.Id = ram.Id;
                ramET.Descripcion = ram.Descripcion;
                ramET.ConsumoEnergia = Convert.ToDouble(ram.ConsumoEnergia);
                ramET.VersionDDR = Convert.ToInt32(ram.VersionDDR);
                ramET.Capacidad = Convert.ToInt32(ram.Capacidad);
                ramET.ConsumoEnergia = Convert.ToDouble(ram.ConsumoEnergia);
                bl.ActualizarRam(ramET);
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
