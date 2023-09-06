using BL;
using ET;
using ET.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WEB.Controllers
{
    public class CpuController : Controller
    {
        private CPU_BL bl = new();
        public IActionResult Index()
        {
            var lista = bl.BuscarCPU();
            return View(lista);
        }
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (CPU cpu)
        {
            try
            {
                if (bl.IngresarCPU(cpu))
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
            var listadoCPU = bl.BuscarCPU();
            CPU_DTO dto = listadoCPU.Where(c => c.id == id).FirstOrDefault();
            return View(dto);
        }
        [HttpPost]
        public IActionResult Edit(CPU_DTO dto)
        {
            try
            {
                CPU cpu = new();
                cpu.Id = dto.id;
                cpu.Descripcion = dto.descripcion;
                cpu.IdSocket = dto.idSocket;
                cpu.ConsumoEnergetico = dto.consumoEnergetico;
                if (bl.ActualizarCPU(cpu))
                    return RedirectToAction("Index");
                else
                    return View(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
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
                if (bl.EliminarCPU(id))
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
