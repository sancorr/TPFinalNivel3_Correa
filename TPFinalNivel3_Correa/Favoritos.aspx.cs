using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPFinalNivel3_Correa.dominio;
using dominio;
using negocio;

namespace TPFinalNivel3_Correa
{
	public partial class Favoritos : System.Web.UI.Page
	{
		public List<Articulo> ListaFavoritos { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ArticuloNegocio negocio = new ArticuloNegocio();
				try
				{
					Usuario usuario = (Usuario)Session["sesionAbierta"];
					//Verificar usuario activo, si no redireccionar a login
					ListaFavoritos = negocio.listarFavoritos(usuario.Id, "");

					if(ListaFavoritos.Count >= 1 && ListaFavoritos != null)
					{
						repeaterFavoritos.DataSource = ListaFavoritos;
						repeaterFavoritos.DataBind();
					}
					else
					{
						lblMensaje.Text = "No hay articulos para mostrar";
						lblMensaje.Visible = true;
					}
				}
				catch (Exception ex)
				{
					Session.Add("error", ex.ToString());
					Response.Redirect("Error.aspx", false);
				}
			}
		}

		protected void btnEliminarFavoritos_Click(object sender, EventArgs e)
		{
			string idArticulo = ((Button)sender).CommandArgument;
			ArticuloNegocio negocio = new ArticuloNegocio();
			try
			{
				Usuario usuario = (Usuario)Session["sesionAbierta"];
				ListaFavoritos = negocio.listarFavoritos(usuario.Id);

				if (ListaFavoritos.Count > 0)
				{
					Articulo seleccionado = negocio.listarFavoritos(usuario.Id, idArticulo).Find(x => x.Id == int.Parse(idArticulo));
					negocio.eliminarFavorito(seleccionado.Id);
					ListaFavoritos = negocio.listarFavoritos(usuario.Id);

					if (ListaFavoritos.Count == 0)
					{
						lblMensaje.Text = "No hay articulos para mostrar";
						lblMensaje.Visible = true;
					}

					repeaterFavoritos.DataSource = ListaFavoritos;
					repeaterFavoritos.DataBind();
					
				}
				else
				{
					lblMensaje.Text = "No hay articulos para mostrar";
					lblMensaje.Visible = true;
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