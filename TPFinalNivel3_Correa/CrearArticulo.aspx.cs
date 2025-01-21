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
	public partial class CrearArticulo : System.Web.UI.Page
	{
		public List<CategoriaArticulo> ListaCategorias { get; set; }
		public List<MarcaArticulo> ListaMarcas { get; set; }
		public bool AgregarMyC { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				AgregarMyC = false;
				CategoriaArticuloNegocio catArtNegocio = new CategoriaArticuloNegocio();
				MarcaArticuloNegocio marArtNegocio = new MarcaArticuloNegocio();

				if (!IsPostBack)
				{
					ListaCategorias = catArtNegocio.listar();
					ListaMarcas = marArtNegocio.listar();

					ddlCategoria.DataSource = ListaCategorias;
					ddlCategoria.DataValueField = "Id";
					ddlCategoria.DataTextField = "Descripcion";
					ddlCategoria.DataBind();

					ddlMarca.DataSource = ListaMarcas;
					ddlMarca.DataValueField = "Id";
					ddlMarca.DataTextField = "Descripcion";
					ddlMarca.DataBind();
				}

				btnOcultar.Visible = false;

				//modificacion
				string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

				if (id != "" && !IsPostBack)
				{
					ArticuloNegocio negocio = new ArticuloNegocio();
					List<Articulo> lista = negocio.listar(id);
					Articulo seleccionado = lista[0];
					AgregarMyC = false;

					//precargar los campos del formulario
					tbxCodigo.Text = seleccionado.Codigo;
					tbxNombre.Text = seleccionado.Nombre;
					tbxDescripcion.Text = seleccionado.Descripcion;
					tbxImagen.Text = seleccionado.ImagenUrl;

					ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
					ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
					tbxImagen_TextChanged(sender, e);

					btnOcultar.Visible = true;
				}
			}
			catch (Exception ex)
			{
				//Redireccion a error pendiente
				Session.Add("error", ex);
				throw;
			}
		}

		protected void btnCrearArt_Click(object sender, EventArgs e)
		{
			try
			{
				Page.Validate();
				if (!Page.IsValid)
					return;
				//crear articulo
				//Faltan Las VALIDACIONES DE LOS CAMPOS Y METODOS PARA EVITAR DATOS REPETIDOS EN DB.
				ArticuloNegocio negocio = new ArticuloNegocio();
				Articulo art = new Articulo();

				art.Codigo = tbxCodigo.Text;
				art.Nombre = tbxNombre.Text;
				art.Descripcion = tbxDescripcion.Text;
				art.ImagenUrl = tbxImagen.Text;


				art.Marca = new MarcaArticulo();
				art.Marca.Id = int.Parse(ddlMarca.SelectedValue);

				art.Categoria = new CategoriaArticulo();
				art.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
				art.Precio = decimal.Parse(tbxPrecio.Text);

				if(Request.QueryString["id"] != null)
				{
					art.Id = int.Parse(Request.QueryString["id"].ToString());
					negocio.modificarArticulo(art);
				}
				else
				{
					negocio.agregarArticulo(art);
				}

				Response.Redirect("Listado.aspx", false);
			}
			catch (Exception ex)
			{
				//Redireccion a error pendiente
				Session.Add("error", ex);
				throw;
			}
			
		}

		protected void btnCancelarArt_Click(object sender, EventArgs e)
		{
			try
			{
				Response.Redirect("Default.aspx", false);
			}
			catch (Exception ex)
			{
				Session.Add("error", "Error al direccionar ");
				Response.Redirect("Error.aspx", false);
			}
		}

		protected void tbxImagen_TextChanged(object sender, EventArgs e)
		{
			artImagen.ImageUrl = tbxImagen.Text;

			if (!tbxImagen.Text.Contains("http"))
			{
				artImagen.ImageUrl = "https://imgs.search.brave.com/TvImnNqSmkLvWLy9Y1Hkith2FQJECMibPyhZ122wNb0/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/dmVjdG9yLWdyYXRp/cy9pbHVzdHJhY2lv/bi1jb25jZXB0by1j/YXJwZXRhLWltYWdl/bmVzXzExNDM2MC0x/MTQuanBnP3NlbXQ9/YWlzX2h5YnJpZA";
			}
		}

		protected void btnOcultar_Click(object sender, EventArgs e)
		{
			ArticuloNegocio negocio = new ArticuloNegocio();
			try
			{
				var id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
				if (id != "")
				{
					negocio.eliminarArticulo(int.Parse(id));
					Response.Redirect("Listado.aspx", false);
				}
				else
				{
					//MENSAJE DE ERROR AQUI
				}
			}
			catch (Exception ex)
			{
				//REDIRECCION A ERROR
				Session.Add("error", ex);
				throw;
			}
		}

		protected void chkAgregarMyC_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				AgregarMyC = true;
			}
			catch (Exception ex)
			{
				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
		}

		protected void btnAgregarMarca_Click(object sender, EventArgs e)
		{
			MarcaArticuloNegocio negocioMarca = new MarcaArticuloNegocio();
			ArticuloNegocio negocio = new ArticuloNegocio();

			try
			{
				if (!string.IsNullOrEmpty(tbxAgregarMarca.Text))
				{
					ListaMarcas = negocioMarca.listar();
					var marcaExistente = ListaMarcas.Find(x => x.Descripcion.ToLower() == tbxAgregarMarca.Text.ToLower());

					if(marcaExistente == null)
					{
						negocio.agregarMarca(tbxAgregarMarca.Text);

						ListaMarcas = negocioMarca.listar();
						ddlMarca.DataSource = ListaMarcas;
						ddlMarca.DataValueField = "Id";
						ddlMarca.DataTextField = "Descripcion";
						ddlMarca.DataBind();

						lblMarcaAgregada.Text = "Marca agregada con éxito";
						lblMarcaAgregada.Visible = true;
					}
					else
					{
						lblMarcaAgregada.Text = "¡Esa marca ya existe!";
						lblMarcaAgregada.Visible = true;
					}
				}
				else
				{
					lblMarcaAgregada.Text = "El campo MARCA es requerido";
					lblMarcaAgregada.Visible = true;
				}
			}
			catch (Exception ex)
			{
				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
		}

		protected void btnAgregarCategoria_Click(object sender, EventArgs e)
		{
			CategoriaArticuloNegocio negocioCategoria = new CategoriaArticuloNegocio();
			ArticuloNegocio negocio = new ArticuloNegocio();
			try
			{
				if (!string.IsNullOrEmpty(tbxAgregarCategoria.Text))
				{
					ListaCategorias = negocioCategoria.listar();
					var categoriaExistente = ListaCategorias.Find(x => x.Descripcion.ToLower() == tbxAgregarCategoria.Text.ToLower());

					if(categoriaExistente == null)
					{
						negocio.agregarCategoria(tbxAgregarCategoria.Text);

						ListaCategorias = negocioCategoria.listar();
						ddlCategoria.DataSource = ListaCategorias;
						ddlCategoria.DataValueField = "Id";
						ddlCategoria.DataTextField = "Descripcion";
						ddlCategoria.DataBind();

						lblCategoriaAgregada.Text = "Categoria agregada con éxito";
						lblCategoriaAgregada.Visible = true;
					}
					else
					{
						lblCategoriaAgregada.Text = "¡Esa categoria ya existe!";
						lblCategoriaAgregada.Visible = true;
					}
				}
				else
				{
					lblCategoriaAgregada.Text = "El campo CATEGORIA es requerido";
					lblCategoriaAgregada.Visible = true;
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