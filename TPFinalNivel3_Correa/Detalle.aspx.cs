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
						//mensaje de error
					}
				}
				catch (Exception ex)
				{
					//Vista de error
					throw ex;
				}
			}
		}

		protected void btnFavoritos_Click(object sender, EventArgs e)
		{
			//ID del articulo proveniente del boton
			string idArticulo = ((Button)sender).CommandArgument;
			//ID del usuario de la session
			Usuario usuario = (Usuario)Session["sesionAbierta"];
			try
			{
				ArticuloNegocio negocio = new ArticuloNegocio();
				Button btn = (Button)sender;
				RepeaterItem i = (RepeaterItem)btn.NamingContainer;
				Label lblFavoritos = (Label)i.FindControl("lblFavoritos");

				negocio.agregarFavorito(usuario.Id, int.Parse(idArticulo));

				lblFavoritos.Text = "¡Agregado a Favoritos!";
				lblFavoritos.Visible = true;
				
			}
			catch (Exception ex)
			{
				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
		}
	}
}