using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPFinalNivel3_Correa.dominio;

namespace TPFinalNivel3_Correa.negocio
{
	public static class Seguridad
	{
		public static bool sesionActiva(object usuario)
		{
			Usuario usuarioActivo = usuario != null ? (Usuario)usuario : null;
			if (usuarioActivo != null && usuarioActivo.Id != 0)
				return true;
			else
				return false;
		}

		public static bool verificarAdmin(object usuarioAdmin)
		{
			Usuario admin = usuarioAdmin != null ? (Usuario)usuarioAdmin : null;
			return admin != null ? admin.Admin : false;

		}
	}
}