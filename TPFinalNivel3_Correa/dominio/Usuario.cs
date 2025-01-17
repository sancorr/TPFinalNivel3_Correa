using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinalNivel3_Correa.dominio
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Pass { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string ImagenPerfil { get; set; }
		public bool Admin { get; set; }
	}
}