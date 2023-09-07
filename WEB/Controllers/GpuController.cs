using BL;
using ET;
using ET.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class GpuController : Controller
    {
        private GPU_BL bl = new();
        public IActionResult Index()
        {
            var lista = bl.BuscarGPU();
            return View(lista);
        }
        public IActionResult Create () 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GPU gpu)
        {
            try
            {
                if (bl.IngresarGPU(gpu))
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
            GPU_DTO dto = bl.BuscarGPU().Where(g => g.id == id).FirstOrDefault();
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GPU_DTO dto)
        {
            try
            {
                GPU gpu = new GPU();
                gpu.Id = dto.id;
                gpu.Descripcion = dto.descripcion;
                gpu.CantidadConectores = dto.cantidadConectores;
                gpu.Pcie16 = dto.pcie16;
                gpu.ConsumoEnergia = dto.consumoEnergia;
                if (bl.ActualizarGPU(gpu))
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
                if (bl.EliminarGPU(id))
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
