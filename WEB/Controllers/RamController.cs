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
            var convertModelos = Tools.ConvertDataTable<RAM_DTO>(listadoRam);
            return View(convertModelos);
        }
    }
}
