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

        public IActionResult Index(int id, int prioridad = -1)
        {
            if (!CarpetaData.CarpetaExiste(id))
            {
                return RedirectToAction("Index", "Carpeta");
            }


            List<Tarea> tareas = prioridad == -1 ? _tareaData.GetTareas(id) : _tareaData.GetTareasPorPrioridad(id, prioridad);

            ViewBag.prioridad = prioridad;

            return View(tareas);
        }

        public IActionResult Crear(int id)
        {
            if (!CarpetaData.CarpetaExiste(id))
            {
                return RedirectToAction("Index", "Carpeta");
            }

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

        public IActionResult CambiarEstado(int id, int estado)
        {
            Tarea tarea = _tareaData.GetTarea(id);

            if (tarea == null || !System.Enum.IsDefined(typeof(eEstado), estado))
            {
                return RedirectToAction("Index", "Carpeta");
            }

            tarea.Completo = (eEstado)estado;

            return Modificar(tarea);
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
