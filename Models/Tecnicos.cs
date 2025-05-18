using System.ComponentModel.DataAnnotations;

namespace RegistrosTenicos.Models
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "El Nombre es Requerido")]
        public string TecnicoName { get; set; } = null!;

        [Required(ErrorMessage = "El Sueldo es Requerido")]
        public double SueldoHora { get; set; }
    }
}
