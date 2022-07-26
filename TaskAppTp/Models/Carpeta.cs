using System.ComponentModel.DataAnnotations;

namespace TaskAppTp.Models
{
    public class Carpeta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La carpeta tiene que tener un nombre")]
        public string Nombre { get; set; }
        public int? CantidadTareas { get; set; }
    }
}
