using System.ComponentModel.DataAnnotations;

namespace MarcosRosario_AP1_P2.Models;

public class Articulos
{
	[Key]
	public int ArticuloId { get; set; }

	[Required]
	[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras.")]
	public string Descripcion { get; set; }

	public decimal Costo { get; set; }

	public int Existencia { get; set; }
}

