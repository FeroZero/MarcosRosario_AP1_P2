using System.ComponentModel.DataAnnotations;

namespace MarcosRosario_AP1_P2.Models
{
    public class Articulo
    {
        [Key]
        public int ArticuloId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras.")]
        public string Descripcion { get; set; }
    }
}
