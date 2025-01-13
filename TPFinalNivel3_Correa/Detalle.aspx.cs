using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

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
			//string idArticulo = ((Button)sender).CommandArgument;
			//Response.Redirect("Favoritos.aspx?id=" + idArticulo, false);
		}
	}
}