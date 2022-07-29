using System.ComponentModel.DataAnnotations;

namespace TaskAppTp.Models
{
    public class Carpeta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La carpeta tiene que tener un nombre")]
        [MaxLength(20, ErrorMessage = "Se permite como maximo 20 caracteres")]
        public string Nombre { get; set; }
        public int? CantidadTareas { get; set; }
        public int? Terminadas { get; set; }
        public int? Pendiente { get; set; }
    }
}
