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
	public partial class Registro : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

			}
		}

		protected void btnRegistro_Click(object sender, EventArgs e)
		{
			try
			{
				Usuario usuario = new Usuario();
				UsuarioNegocio negocio = new UsuarioNegocio();

				usuario.Nombre = tbxNombre.Text;
				usuario.Apellido = tbxApellido.Text;
				usuario.Email = tbxEmail.Text;
				usuario.Pass = tbxPass.Text;
				usuario.Id = negocio.registrarUsuario(usuario);

				Session.Add("sesionAbierta", usuario);
				Response.Redirect("MiPerfil.aspx", false);
			}
			catch (Exception ex)
			{
				Session.Add("error", ex);
				throw;
			}
		}
	}
}