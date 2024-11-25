using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcosRosario_AP1_P2.Models;

public class Combos
{
	[Key]
	public int ComboId { get; set; }
	[Required]
	public DateTime Fecha { get; set; } = DateTime.Now;
	[Required]
	[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras.")]
	public string Descripcion { get; set; }
	[Required]
	[Range(1, double.MaxValue, ErrorMessage = "No puede ser menor a 0.")]
	public decimal Precio { get; set; }

	[Required]
	public bool Vendido { get; set; }

	[ForeignKey("ComboId")]
	public virtual ICollection<CombosDetalle> CombosDetalle { get; set; } = new List<CombosDetalle>();
}
