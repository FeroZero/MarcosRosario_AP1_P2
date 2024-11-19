using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcosRosario_AP1_P2.Models
{
    public class CombosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "No puede ser menor que 0.")]
        public int Costo { get; set; }

        [ForeignKey("ComboId")]
        public int ComboId { get; set; }

        [ForeignKey("ArticuloId")]
        public int ArticuloId { get; set; }
    }
}
