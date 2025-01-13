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
	public partial class Listado : System.Web.UI.Page
	{
		public List<Articulo> ListaArticulos { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ArticuloNegocio negocio = new ArticuloNegocio();
				try
				{
					if(GvListado != null)
					{
						ListaArticulos = negocio.listar();			
						GvListado.DataSource = ListaArticulos;
						GvListado.DataBind();
					}
					else
					{
						//mensaje de error
					}
				}
				catch (Exception ex)
				{
					Session.Add("error", ex);
					//REDIRECCIONAR A ERROR
				}
			}
		}

		protected void GvListado_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				var registro = GvListado.SelectedRow.Cells[0].Text;
				var id = GvListado.SelectedDataKey.Value.ToString();

				Response.Redirect("CrearArticulo.aspx?id=" + id, false);

			}
			catch (Exception ex)
			{
				Session.Add("error", ex);
				//REDIRECCIONAR A ERROR
			}
		}

		protected void btnAgregarArt_Click(object sender, EventArgs e)
		{
			try
			{
				Response.Redirect("CrearArticulo.aspx", false);
			}
			catch (Exception ex)
			{
				//Redireccionar a ERROR
				Session.Add("error", ex);
				throw;
			}
		}
	}
}