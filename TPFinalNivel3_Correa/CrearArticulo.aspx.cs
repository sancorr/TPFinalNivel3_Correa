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
		public bool Eliminar { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				CategoriaArticuloNegocio catArtNegocio = new CategoriaArticuloNegocio();
				MarcaArticuloNegocio marArtNegocio = new MarcaArticuloNegocio();
				Eliminar = false;

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

				//modificacion
				string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

				if (id != "" && !IsPostBack)
				{
					ArticuloNegocio negocio = new ArticuloNegocio();
					List<Articulo> lista = negocio.listar(id);
					Articulo seleccionado = lista[0];
					Eliminar = true;

					//precargar los campos del formulario
					tbxCodigo.Text = seleccionado.Codigo;
					tbxNombre.Text = seleccionado.Nombre;
					tbxDescripcion.Text = seleccionado.Descripcion;
					tbxImagen.Text = seleccionado.ImagenUrl;

					ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
					ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
					tbxImagen_TextChanged(sender, e);
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
				//Redireccion a error pendiente
				Session.Add("error", "Error al direccionar");
				throw;
			}
		}

		protected void tbxImagen_TextChanged(object sender, EventArgs e)
		{
			artImagen.ImageUrl = tbxImagen.Text;
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
	}
}