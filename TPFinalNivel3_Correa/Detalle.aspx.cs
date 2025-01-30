using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using TPFinalNivel3_Correa.dominio;

namespace TPFinalNivel3_Correa
{
	public partial class Detalle : System.Web.UI.Page
	{
		public List<Articulo> ListaArticulo { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string articuloId = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
				try
				{
					if (!string.IsNullOrEmpty(articuloId))
					{
						ArticuloNegocio negocio = new ArticuloNegocio();
						ListaArticulo = negocio.listar(articuloId);

						repeaterDetalle.DataSource = ListaArticulo;
						repeaterDetalle.DataBind();
					}
					else
					{
						Session.Add("error", "Error al cargar la página");
						Response.Redirect("Error.aspx", false);
					}
				}
				catch (Exception ex)
				{
					Session.Add("error", "Error al cargar la página");
					Response.Redirect("Error.aspx", false);
				}
			}
		}

		protected void btnFavoritos_Click(object sender, EventArgs e)
		{
			
			string idArticulo = ((Button)sender).CommandArgument;
			
			Usuario usuario = (Usuario)Session["sesionAbierta"];
			try
			{
				ArticuloNegocio negocio = new ArticuloNegocio();
				Button btn = (Button)sender;
				RepeaterItem i = (RepeaterItem)btn.NamingContainer;
				Label lblFavoritos = (Label)i.FindControl("lblFavoritos");

				Articulo artExistenteFav = negocio.listarFavoritos(usuario.Id, idArticulo).Find(x => x.Id == int.Parse(idArticulo));

				if(artExistenteFav == null)
				{
					negocio.agregarFavorito(usuario.Id, int.Parse(idArticulo));
					lblFavoritos.Text = "¡Agregado a Favoritos!";
					lblFavoritos.Visible = true;
				}
				else
				{
					lblFavoritos.Text = "¡Ese articulo ya existe en Favoritos!";
					lblFavoritos.Visible = true;
				}
				
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al agregar a favoritos");
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