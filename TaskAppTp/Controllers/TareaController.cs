using Microsoft.AspNetCore.Mvc;
using TaskAppTp.Data;
using TaskAppTp.Models;

namespace TaskAppTp.Controllers
{
    public class TareaController : Controller
    {
        private readonly TareaData _tareaData;

        public TareaController()
        {
            _tareaData = new TareaData();
        }

        public IActionResult Index(int id)
        {
            List<Tarea> tareas = _tareaData.GetTareas(id);

            return View(tareas);
        }

        public IActionResult Crear(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _tareaData.CreateTarea(tarea);

            return RedirectToAction("Index", "Tarea", new { id = tarea.IdCarpeta });
        }

        [HttpPost]
        public IActionResult Estado(int id)
        {
            Tarea tarea = _tareaData.GetTarea(id);

            if (tarea != null)
            {
                tarea.Completo = !tarea.Completo;
                _tareaData.UpdateTarea(tarea);
            }

            return RedirectToAction("Index", "Tarea", new { id = tarea.IdCarpeta });
        }

        public IActionResult Modificar(int id)
        {
            Tarea tarea = _tareaData.GetTarea(id);

            if (tarea == null)
            {
                return RedirectToAction("Index", "Carpeta");
            }

            return View(tarea);
        }

        [HttpPost]
        public IActionResult Modificar(Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return View(tarea);
            }

            _tareaData.UpdateTarea(tarea);

            return RedirectToAction("Index", "Tarea", new { id = tarea.IdCarpeta });
        }

        public IActionResult Eliminar(int id)
        {
            Tarea tarea = _tareaData.GetTarea(id);

            if (tarea == null)
            {
                return RedirectToAction("Index", "Carpeta");
            }

            return View(tarea);
        }

        [HttpPost]
        public IActionResult EliminarTarea(int id)
        {
            Tarea tarea = _tareaData.GetTarea(id);

            if (tarea == null)
            {
                return RedirectToAction("Index", "Carpeta");
            }

            _tareaData.DeleteTarea(tarea.Id);

            return RedirectToAction("Index", "Tarea", new { id = tarea.IdCarpeta });
        }

        public IActionResult Detalle(int id)
        {
            Tarea tarea = _tareaData.GetTarea(id);

            if (tarea == null)
            {
                return RedirectToAction("Index", "Carpeta");
            }

            return View(tarea);
        }
    }
}
