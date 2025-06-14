using System.ComponentModel.DataAnnotations;

namespace RegistrosTenicos.Models
{
    public class Sistema
    {
        [Key]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "La Descripcion es Requerida")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "La Complejidad es Requerida")]
        public double Complejidad { get; set; }
    }
}
