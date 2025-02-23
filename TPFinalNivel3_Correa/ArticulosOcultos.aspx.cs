﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPFinalNivel3_Correa
{
	public partial class ArticulosOcultos : System.Web.UI.Page
	{
		public List<Articulo> ListaOcultos { get; set; }
		public void renderLabel(string texto)
		{
			lblOcultosVacio.Text = texto; 
			lblOcultosVacio.Visible = true;
		}

		public void renderLista()
		{
			repeaterOcultos.DataSource = ListaOcultos;
			repeaterOcultos.DataBind();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			ArticuloNegocio negocio = new ArticuloNegocio();
			try
			{
				if (!IsPostBack)
				{
					ListaOcultos = negocio.listarEliminados();

					if (ListaOcultos.Count < 1)
					{
						renderLabel("No hay articulos para mostrar...");
					}
					else
					{
						renderLista();
					}
				}
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al cargar la página.");
				Response.Redirect("Error.aspx", false);
			}
		}

		protected void btnRestaurar_Click(object sender, EventArgs e)
		{
			ArticuloNegocio negocio = new ArticuloNegocio();
			string id = ((Button)sender).CommandArgument;
			try
			{
				negocio.reactivarArticulo(int.Parse(id));
				ListaOcultos = negocio.listarEliminados();

				if (ListaOcultos.Count < 1)
				{
					renderLabel("No hay articulos para mostrar...");
				}
				renderLista();
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al restaurar artículo.");
				Response.Redirect("Error.aspx", false);
			}
		}

		protected void btnEliminar_Click(object sender, EventArgs e)
		{
			ArticuloNegocio negocio = new ArticuloNegocio();
			string id = ((Button)sender).CommandArgument;
			try
			{
				negocio.eliminarDefinitivo(int.Parse(id));
				ListaOcultos = negocio.listarEliminados();

				if (ListaOcultos.Count < 1)
				{
					renderLabel("No hay articulos para mostrar...");
				}
				renderLista();
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al eliminar artículo.");
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