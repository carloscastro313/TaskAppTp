using System.ComponentModel.DataAnnotations;

namespace TaskAppTp.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La tarea tiene que tener un nombre")]
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Completo { get; set; }
        public int IdCarpeta { get; set; }
    }
}
