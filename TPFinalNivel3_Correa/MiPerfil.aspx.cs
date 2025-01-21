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
				Session.Add("error", "Error al cargar la pagina: " + ex.ToString());
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
				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
		}
	}
}