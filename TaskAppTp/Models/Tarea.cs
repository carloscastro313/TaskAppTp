using System.ComponentModel.DataAnnotations;

namespace TaskAppTp.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La tarea tiene que tener un nombre")]
        [MaxLength(20, ErrorMessage = "Se permite como maximo 20 caracteres")]
        public string Nombre { get; set; }
        [MaxLength(100, ErrorMessage = "Se permite como maximo 100 caracteres")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Se tiene que asignar una prioridad a la tarea")]
        public ePrioridad Prioridad { get; set; }
        public eEstado Completo { get; set; }
        public int IdCarpeta { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime? FechaCambioEstado { get; set; }
    }
}
