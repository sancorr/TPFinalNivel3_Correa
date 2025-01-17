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
		public bool Filtro { get; set; }

		private void cargarCampo()
		{
			ddlCampo.Items.Add("Nombre");
			ddlCampo.Items.Add("Categoria");
			ddlCampo.Items.Add("Marca");
			ddlCampo.Items.Add("Precio");
		}
		private bool validarNumeros(string cadena)
		{
			foreach (char x in cadena)
			{
				if (!(char.IsNumber(x)))
				{
					return false;
				}
			}
				return true;
		}
		private bool validacionFiltro()
		{

			if(ddlCampo.SelectedIndex < 0)
			{
				lblError.Text = "Debe seleccionar un campo";
				lblError.Visible = true;
				return true;
			}

			if(ddlCampo.SelectedItem.ToString() == "Precio")
			{
				if(string.IsNullOrEmpty(tbxFiltro.Text))
				{
					lblError.Text = "Precio no puede ser vacio o menor a 1";
					lblError.Visible = true;
					return true;
				}

				if (!(validarNumeros(tbxFiltro.Text))){
					lblError.Text = "Precio debe ser un número";
					lblError.Visible = true;
					return true;
				}
				return false;
			}

			if(ddlCriterio.SelectedIndex < 0)
			{
				lblError.Text = "Debe seleccionar un criterio";
				lblError.Visible = true;
				return true;
			}

			if (string.IsNullOrEmpty(tbxFiltro.Text))
			{
				lblError.Text = "No puede realizar una búsqueda vacia";
				lblError.Visible = true;
				return true;
			}

			return false;
		}
		
		protected void Page_Load(object sender, EventArgs e)
		{
			ArticuloNegocio articuloNegocio = new ArticuloNegocio();
			ListaArticulos = articuloNegocio.listar();

			lblError.Visible = false;
			lblResBusqueda.Visible = false;
			if (!IsPostBack)
			{
				Filtro = false;
				cargarCampo();

				repeaterHome.DataSource = ListaArticulos;
				repeaterHome.DataBind();
			}
		}

		protected void btnVerDetaller_Click(object sender, EventArgs e)
		{
			string idArticulo = ((Button)sender).CommandArgument;
			Response.Redirect("Detalle.aspx?id=" + idArticulo, false);
		}

		protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
		{
			string opcion = ddlCampo.SelectedItem.ToString();
			ArticuloNegocio negocio = new ArticuloNegocio();

			ddlCriterio.Items.Clear();

			if(opcion == "Precio")
			{
				ddlCriterio.Items.Add("Mayor a");
				ddlCriterio.Items.Add("Menor a");
				ddlCriterio.Items.Add("Igual a");
			}
			else if(opcion == "Nombre")
			{
				ddlCriterio.Items.Add("Comienza con");
				ddlCriterio.Items.Add("Contiene");
				ddlCriterio.Items.Add("Termina con");
			}
			else if(opcion == "Marca")
			{
				foreach (var marca in negocio.listadoMarcas())
				{
					ddlCriterio.Items.Add(marca.ToString());
				}
			}
			else if (opcion == "Categoria")
			{
				foreach (var categoria in negocio.listadoCategorias())
				{
					ddlCriterio.Items.Add(categoria.ToString());
				}
			}
		}

		protected void btnBuscarFiltro_Click(object sender, EventArgs e)
		{
			ArticuloNegocio negocio = new ArticuloNegocio();

			if (validacionFiltro())
				return;

			string campo = ddlCampo.SelectedValue;
			string criterio = ddlCriterio.SelectedValue;
			string filtro = tbxFiltro.Text.ToLower();

			ListaArticulos = negocio.filtroProductos(campo, criterio, filtro);

			if(ListaArticulos.Count >= 1)
			{
				lblResBusqueda.Text = $"Se encontraron {ListaArticulos.Count} artículos";
				lblResBusqueda.Visible = true;
				repeaterHome.DataSource = ListaArticulos;
				repeaterHome.DataBind();
			}
			else
			{
				lblResBusqueda.Text = " No se encontraron artículos que coincidan con los criterios de búsqueda";
				lblResBusqueda.Visible = true;
				repeaterHome.DataSource = null;
				repeaterHome.DataBind();
			}

		}

		protected void chkFiltro_CheckedChanged(object sender, EventArgs e)
		{
			Filtro = true;
		}
	}
}