using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPFinalNivel3_Correa
{
	public partial class Default : System.Web.UI.Page
	{
		public List<Articulo> ListaArticulos { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			ArticuloNegocio articuloNegocio = new ArticuloNegocio();
			ListaArticulos = articuloNegocio.listar();

			if (!IsPostBack)
			{
				repeaterHome.DataSource = ListaArticulos;
				repeaterHome.DataBind();
			}
		}

		protected void btnVerDetaller_Click(object sender, EventArgs e)
		{
			string idArticulo = ((Button)sender).CommandArgument;
			Response.Redirect("Detalle.aspx?id=" + idArticulo, false);
		}
	}
}