using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPFinalNivel3_Correa.negocio;
using TPFinalNivel3_Correa.dominio;

namespace TPFinalNivel3_Correa
{
	public partial class MiPerfil : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					if (Seguridad.sesionActiva(Session["sesionAbierta"]))
					{

						Usuario usuario = (Usuario)Session["sesionAbierta"];
						tbxNombre.Text = usuario.Nombre;
						tbxApellido.Text = usuario.Apellido;
						if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
							imagenPerfil.ImageUrl = "~/Imagenes/Perfil/" + usuario.ImagenPerfil;
						tbxEmail.Text = usuario.Email;
						tbxEmail.ReadOnly = true;
					}
				}
			} 
			catch (Exception ex)
			{
				Session.Add("error", "Error al cargar la página");
				Response.Redirect("Error.aspx", false);
			}
		}

		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			try
			{
				Page.Validate();
				if (!Page.IsValid)
					return;

				Usuario usuario = (Usuario)Session["sesionAbierta"];
				UsuarioNegocio negocio = new UsuarioNegocio();

				usuario.Nombre = tbxNombre.Text;
				usuario.Apellido = tbxApellido.Text;

				if (tbxImagenPerfil.PostedFile.FileName != "")
				{
					string path = Server.MapPath("./Imagenes/Perfil/");
					tbxImagenPerfil.PostedFile.SaveAs(path + "FotoPerfil-" + usuario.Id + ".jpg");
					usuario.ImagenPerfil = "FotoPerfil-" + usuario.Id + ".jpg";
				}

				negocio.actualizarUsuario(usuario);

				Image avatar = (Image)Master.FindControl("imgAvatar");
				avatar.ImageUrl = "~/Imagenes/Perfil/" + usuario.ImagenPerfil;
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al intentar guardar los cambios.");
				Response.Redirect("Error.aspx", false);
			}
		}

		protected void btnEliminarAdmin_Click(object sender, EventArgs e)
		{
			UsuarioNegocio negocio = new UsuarioNegocio();
			Usuario usuario = (Usuario)Session["sesionAbierta"];
			try
			{
				negocio.quitarAdmin(usuario);
				usuario = negocio.obtenerUsuarioPorId(usuario.Id);

				Session["sesionAbierta"] = usuario;

				Response.Redirect("Default.aspx", false);
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al intentar modificar el tipo de usuario.");
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