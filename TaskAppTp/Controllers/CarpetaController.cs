using Microsoft.AspNetCore.Mvc;
using TaskAppTp.Data;
using TaskAppTp.Models;

namespace TaskAppTp.Controllers
{
    public class CarpetaController : Controller
    {
        private readonly CarpetaData _carpetaData;

        public CarpetaController()
        {
            _carpetaData = new CarpetaData();
        }

        public IActionResult Index()
        {
            List<Carpeta> carpetas = _carpetaData.GetCarpetas();
            return View(carpetas);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Carpeta carpeta)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _carpetaData.CreateCarpeta(carpeta);

            return RedirectToAction("Index");
        }

        public IActionResult Modificar(int id)
        {
            Carpeta carpeta = _carpetaData.GetCarpeta(id);

            if (carpeta == null)
            {
                return RedirectToAction("Index");
            }

            return View(carpeta);
        }

        [HttpPost]
        public IActionResult Modificar(Carpeta carpeta)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _carpetaData.UpdateCarpeta(carpeta);

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            Carpeta carpeta = _carpetaData.GetCarpeta(id);

            if (carpeta == null)
            {
                return RedirectToAction("Index");
            }

            return View(carpeta);
        }

        [HttpPost]
        public IActionResult EliminarCarpeta(int id)
        {
            _carpetaData.DeleteCarpeta(id);

            return RedirectToAction("Index");
        }
    }
}
