using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Correa
{
	public partial class Error : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["error"] != null)
			{
				string sessionError = Session["error"].ToString();

				if (isErrorFriendly(sessionError))
				{
					lblError.Text = sessionError;
				}
				else
				{
					lblError.Text = friendlyError(sessionError);
				}

			}
			else
			{
				lblError.Text = "Ocurrió algo inesperado, intenta nuevamente o contacta con soporte.";
			}
		}

		private bool isErrorFriendly(string error)
		{
			return !error.Contains("Exception") && !error.Contains("error") && error.Length < 100;
		}
		private string friendlyError(string detallesError)
		{
			if (detallesError.Contains("404"))
			{
				return "Parece que la pagina que buscas no existe.";
			}
			else if (detallesError.Contains("500"))
			{
				return "Ocurrio un error en el servidor, estamos trabajando para solucionarlo.";
			}
			else if (detallesError.Contains("timeout"))
			{
				return "La carga tardó demasiado, intente nuevamente";
			}
			else
			{
				return "Ocurrió un error inesperado. Por favor intente nuevamente más tárde o contacte a soporte";
			}
		}
	}
}