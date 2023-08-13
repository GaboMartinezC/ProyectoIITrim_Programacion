using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEB.Models;
using ET.DTO;
using ET;
using BL;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EnsamblajeBL bl = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listado = bl.BuscarTodoEnsamblaje();
            return View(listado);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EnsamblajeFull_DTO dto)
        {
            try
            {
                Ensamblaje ensamblaje = new()
                {
                    IdPlacaMadre = dto.IdPlacaMadre,
                    IdProcesador = dto.IdProcesador,
                    IdEnfriamiento = dto.IdEnfriamiento,
                    IdRam = dto.IdRam,
                    CantidadRam = dto.CantidadRam,
                    IdGrafica = dto.IdGrafica,
                    IdCase = dto.IdCase,
                    IdUnidadAlmacenamiento = dto.IdUnidadAlmacenamiento,
                    CantidadUnidades = dto.CantidadUnidades,
                    IdFuente = dto.IdFuente
                };
                if (bl.IngresarEnsamblaje(ensamblaje) == 0)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}