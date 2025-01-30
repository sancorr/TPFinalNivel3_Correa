using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using TPFinalNivel3_Correa.negocio;
using TPFinalNivel3_Correa.dominio;

namespace TPFinalNivel3_Correa
{
	public partial class Listado : System.Web.UI.Page 
	{
		public List<Articulo> ListaArticulos { get; set; }
		public List<Articulo> Ocultos { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ArticuloNegocio negocio = new ArticuloNegocio();
				try
				{
					Ocultos = negocio.listarEliminados() ?? new List<Articulo>();

					if (!Seguridad.verificarAdmin((Usuario)Session["sesionAbierta"]))
					{
						Session.Add("error", "Necesitas permisos de administrador para entrar aqui");
						Response.Redirect("Error.aspx", false);
					}

					if(GvListado != null)
					{
						ListaArticulos = negocio.listar();			
						GvListado.DataSource = ListaArticulos;
						GvListado.DataBind();
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
				Session.Add("error", "Error al cargar la página");
				Response.Redirect("Error.aspx", false);
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
				Session.Add("error", "Error al redireccionar.");
				Response.Redirect("Error.aspx", false);
			}
		}

		protected void btnOcultos_Click(object sender, EventArgs e)
		{
			try
			{
				Response.Redirect("ArticulosOcultos.aspx", false);
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al redireccionar");
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