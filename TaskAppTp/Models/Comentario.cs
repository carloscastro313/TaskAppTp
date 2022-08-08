using System.ComponentModel.DataAnnotations;

namespace TaskAppTp.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        [Required]
        public string Texto { get; set; }
        public DateTime FechaCreada { get; set; }
        public int IdTarea { get; set; }
    }
}
