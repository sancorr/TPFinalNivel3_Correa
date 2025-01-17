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
				Usuario usuario = (Usuario)Session["sesionAbierta"];
				UsuarioNegocio negocio = new UsuarioNegocio();
				if(tbxImagenPerfil.PostedFile.FileName != "")
				{
					string path = Server.MapPath("./Imagenes/Perfil/");
					tbxImagenPerfil.PostedFile.SaveAs(path + "FotoPerfil-" + usuario.Id + ".jpg");
					usuario.ImagenPerfil = "FotoPerfil-" + usuario.Id + ".jpg";

					negocio.actualizarUsuario(usuario);
				}
			}
			catch (Exception ex)
			{
				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
		}
	}
}