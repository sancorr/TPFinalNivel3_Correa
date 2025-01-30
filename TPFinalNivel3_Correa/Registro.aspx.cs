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
		private bool UserAdmin
		{
			get
			{
				return Session["UserAdmin"] != null ? (bool)Session["UserAdmin"] : false;
			}
			set
			{
				Session["UserAdmin"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
				UserAdmin = false;
		}

		protected void btnRegistro_Click(object sender, EventArgs e)
		{
			try
			{
				Page.Validate();
				if (!Page.IsValid)
					return;

				Usuario usuario = new Usuario();
				UsuarioNegocio negocio = new UsuarioNegocio();

				usuario.Nombre = tbxNombre.Text;
				usuario.Apellido = tbxApellido.Text;
				usuario.Email = tbxEmail.Text;
				usuario.Pass = tbxPass.Text;

				if (UserAdmin)
					usuario.Id = negocio.registrarAdministrador(usuario);
				else
					usuario.Id = negocio.registrarUsuario(usuario);

				usuario = negocio.obtenerUsuarioPorId(usuario.Id);

				Session.Add("sesionAbierta", usuario);
				Response.Redirect("MiPerfil.aspx", false);
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al intentar registrar el usuario");
				Response.Redirect("Error.aspx", false);
			}
		}

		protected void chkAdmin_CheckedChanged(object sender, EventArgs e)
		{
			UserAdmin = chkAdmin.Checked;
		}
		private void Page_Error(object sender, EventArgs e)
		{
			Exception exc = Server.GetLastError();

			Session.Add("error", exc.ToString());
			Server.Transfer("Error.aspx");
		}


	}
}