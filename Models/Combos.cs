using System.ComponentModel.DataAnnotations;

namespace MarcosRosario_AP1_P2.Models
{
	public class Combos
	{
		[Key]
        public int ComboId { get; set; }

        public string MyName { get; set; }
    }
}
