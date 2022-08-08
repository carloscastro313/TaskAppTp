using Microsoft.AspNetCore.Mvc;
using TaskAppTp.Data;
using TaskAppTp.Models;

namespace TaskAppTp.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly ComentarioData _comentarioData;

        public ComentarioController()
        {
            _comentarioData = new ComentarioData();
        }

        [HttpPost]
        public IActionResult Crear(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.FechaCreada = DateTime.Now;
                _comentarioData.CreateComentario(comentario);
            }

            return RedirectToAction("Detalle", "Tarea", new { Id = comentario.IdTarea });
        }

        [HttpPost]
        public IActionResult Eliminar(int id, int idTarea)
        {
            _comentarioData.DeleteComentario(id);

            return RedirectToAction("Detalle", "Tarea", new { Id = idTarea });
        }
    }
}
