using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPFinalNivel3_Correa.dominio;
using TPFinalNivel3_Correa.negocio;

namespace TPFinalNivel3_Correa
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnIngreso_Click(object sender, EventArgs e)
		{
			try
			{
				Page.Validate();
				if (!Page.IsValid)
					return;

				Usuario usuario = new Usuario();
				UsuarioNegocio negocio = new UsuarioNegocio();

				usuario.Email = tbxEmailIngreso.Text;
				usuario.Pass = tbxPassIngreso.Text;

				if (negocio.ingresarUsuario(usuario))
				{
					Session.Add("sesionAbierta", usuario);
					Response.Redirect("MiPerfil.aspx", false);
				}
				else
				{
					Session.Add("error", "Usuario o contraseña inválidos");
					Response.Redirect("Error.aspx", false);
				}
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al cargar la página");
				Response.Redirect("Error.aspx", false);
			}
		}
		private void Page_Error(object sender, EventArgs e)
		{
			Exception exc = Server.GetLastError();

			Session.Add("error", exc.ToString());
			Server.Transfer("Error.aspx");
		}
	}
}