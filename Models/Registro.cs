using System.ComponentModel.DataAnnotations;

namespace MarcosRosario_AP1_P2.Models
{
	public class Registro
	{
		[Key]
        public int MyProperty { get; set; }

        public string MyName { get; set; }
    }
}
