using BL;
using ET;
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
        /// <summary>
        /// POST: ProductController/Create
        /// </summary>
        /// <param name="descrip"></param>
        /// <param name="cantSata"></param>
        /// <param name="cantPci"></param>
        /// <param name="pot"></param>
        /// <param name="anch"></param>
        /// <param name="alt"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(string descrip, int cantSata, int cantPci, double pot, double anch, double alt)
        {
            try
            {
                FuentePoder fuente = new();
                fuente.Descripcion = descrip;
                fuente.CantidadConectoresSATA = cantSata;
                fuente.CantidadConectoresPCIe = cantPci;
                fuente.Potencia = pot;
                fuente.Ancho = anch;
                fuente.Altura = alt;
                bl.IngresarFuentePoder(fuente);
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
        public ActionResult Edit(int id, string descrip, int cantSata, int cantPci, double pot, double anch, double alt)
        {
            try
            {
                FuentePoder fuente = new();
                fuente.Id = id;
                fuente.Descripcion = descrip;
                fuente.CantidadConectoresSATA = cantSata;
                fuente.CantidadConectoresPCIe = cantPci;
                fuente.Potencia = pot;
                fuente.Ancho = anch;
                fuente.Altura = alt;
                bl.ActualizarFuentePoder(fuente);
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
