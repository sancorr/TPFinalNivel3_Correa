using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
		
        //METODOS DE ACCESO A DATOS PARA LOS ARTICULOS

        //1)LISTAR ARTICULOS DESDE DB
        public List<Articulo> listar(string id = "")
		{
            List<Articulo> lista = new List<Articulo>();
			AccesoDatos datos = new AccesoDatos();
			string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, C.Descripcion Categoria, M.Descripcion Marca, A.IdMarca, A.IdCategoria from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id AND A.IdMarca = M.Id AND Nombre NOT LIKE 'ELIMINADO%' ";

			try
			{
				if (id != "")
					consulta += "AND A.Id = " + id;

				datos.setConsulta(consulta);
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Articulo aux = new Articulo();
					aux.Id = (int)datos.Lector["Id"];
					aux.Codigo = datos.Lector["Codigo"] is DBNull ? null : (string)datos.Lector["Codigo"];
					aux.Nombre = datos.Lector["Nombre"] is DBNull ? null : (string)datos.Lector["Nombre"];
					aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? null : (string)datos.Lector["Descripcion"];

					aux.Marca = new MarcaArticulo();
					aux.Marca.Id = (int)datos.Lector["IdMarca"];
					aux.Marca.Descripcion = datos.Lector["Marca"] is DBNull ? null : (string)datos.Lector["Marca"];

					aux.Categoria = new CategoriaArticulo();
					aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
					aux.Categoria.Descripcion = datos.Lector["Categoria"] is DBNull ? null :  (string)datos.Lector["Categoria"];

					aux.ImagenUrl = datos.Lector["ImagenUrl"] is DBNull ? null : (string)datos.Lector["ImagenUrl"];
					aux.Precio = (decimal)datos.Lector["Precio"];

					lista.Add(aux);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al listar articulos: " + ex.Message);
			}
			finally
			{
				datos.cerrarConexion();
			}


		}

		internal void eliminarDefinitivo(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
				datos.setParametros("@id", id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		//2) FILTRAR ARTICULOS YENDO A DB
		public List<Articulo> filtrarDB(string campo, string criterio, string filtro)
		{
			List<Articulo> listaFiltrada = new List<Articulo>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio, C.Descripcion Categoria, M.Descripcion Marca from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id AND A.IdMarca = M.Id AND A.Nombre NOT LIKE 'ELIMINADO_%' AND ";

				if(campo == "Precio")
				{
					switch (criterio)
					{
						case "Mayor a":
							consulta += "Precio > " + filtro;
							break;
						case "Igual a":
							consulta += "Precio = " + filtro;
							break;
						default:
							consulta += "Precio < " + filtro;
							break;
					}
				} else if(campo == "Codigo de articulo")
				{
					switch (criterio)
					{
						case "Comienza con":
							consulta += "Codigo like '" + filtro + "%' ";
							break;
						case "Contiene":
							consulta += "Codigo like '%" + filtro + "%'";
							break;
						default:
							consulta += "Codigo like '%" + filtro + "'";
							break;
					}
				}
				else if (campo == "Nombre de articulo")
				{
					switch (criterio)
					{
						case "Comienza con":
							consulta += "Nombre like '" + filtro + "%' ";
							break;
						case "Contiene":
							consulta += "Nombre like '%" + filtro + "%'";
							break;
						default:
							consulta += "Nombre like '%" + filtro + "'";
							break;
					}
				}
				else if (campo == "Marca")
				{
					switch (criterio)
					{
						case "Comienza con":
							consulta += "M.Descripcion like '" + filtro + "%' ";
							break;
						case "Contiene":
							consulta += "M.Descripcion like '%" + filtro + "%'";
							break;
						default:
							consulta += "M.Descripcion like '%" + filtro + "'";
							break;
					}
				}
				else
				{
					switch (criterio)
					{
						case "Comienza con":
							consulta += "C.Descripcion like '" + filtro + "%' ";
							break;
						case "Contiene":
							consulta += "C.Descripcion like '%" + filtro + "%'";
							break;
						default:
							consulta += "C.Descripcion like '%" + filtro + "'";
							break;
					}
				}
				datos.setConsulta(consulta);

				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					Articulo aux = new Articulo();
					aux.Id = (int)datos.Lector["Id"];
					aux.Codigo = datos.Lector["Codigo"] is DBNull ? null : (string)datos.Lector["Codigo"];
					aux.Nombre = datos.Lector["Nombre"] is DBNull ? null : (string)datos.Lector["Nombre"];
					aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? null : (string)datos.Lector["Descripcion"];

					aux.Marca = new MarcaArticulo();
					aux.Marca.Descripcion = datos.Lector["Marca"] is DBNull ? null : (string)datos.Lector["Marca"];

					aux.Categoria = new CategoriaArticulo();
					aux.Categoria.Descripcion = datos.Lector["Categoria"] is DBNull ? null : (string)datos.Lector["Categoria"];

					aux.IdMarca = (int)datos.Lector["IdMarca"];
					aux.IdCategoria = (int)datos.Lector["IdCategoria"];
					aux.ImagenUrl = datos.Lector["ImagenUrl"] is DBNull ? null : (string)datos.Lector["ImagenUrl"];
					aux.Precio = (decimal)datos.Lector["Precio"];

					listaFiltrada.Add(aux);
				}

				return listaFiltrada;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
		
		//3) AGREGAR REGISTROS A LA BASE DE DATOS
		public void agregarArticulo(Articulo articulo)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)");

				datos.setParametros("@codigo", articulo.Codigo);
				datos.setParametros("@nombre", articulo.Nombre);
				datos.setParametros("@descripcion", articulo.Descripcion);
				datos.setParametros("@idMarca", articulo.Marca.Id);
				datos.setParametros("@idCategoria", articulo.Categoria.Id);
				datos.setParametros("@imagenUrl", articulo.ImagenUrl);
				datos.setParametros("@precio", articulo.Precio);

				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		//4) MODIFICAR REGISTROS EN LA BASE DE DATOS
		public void modificarArticulo(Articulo articulo)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("update ARTICULOS set Codigo= @codigo, Nombre= @nombre, Descripcion= @descripcion, IdMarca= @idMarca, IdCategoria= @idCategoria,ImagenUrl= @imagenUrl, Precio= @precio where id= @id");
				datos.setParametros("@codigo", articulo.Codigo);
				datos.setParametros("@nombre", articulo.Nombre);
				datos.setParametros("@descripcion", articulo.Descripcion);
				datos.setParametros("@idMarca", articulo.Marca.Id);
				datos.setParametros("@idCategoria", articulo.Categoria.Id);
				datos.setParametros("@imagenUrl", articulo.ImagenUrl);
				datos.setParametros("@precio", articulo.Precio);
				datos.setParametros("@id", articulo.Id);

				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		//5) ELIMINAR REGISTROS EN LA BASE DE DATOS
		public void eliminarArticulo(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("UPDATE ARTICULOS SET Nombre = CONCAT('ELIMINADO_', Nombre) WHERE Id = @id");
				datos.setParametros("@id", id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
	
		//6) LISTAR ARTICULOS ELIMINADOS (INACTIVOS)
		public List<Articulo> listarEliminados()
		{
			List<Articulo> listaEliminados = new List<Articulo>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, C.Descripcion Categoria, M.Descripcion Marca, A.IdMarca, A.IdCategoria from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id AND A.IdMarca = M.Id AND Nombre LIKE 'ELIMINADO%'");
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					Articulo aux = new Articulo();
					aux.Id = (int)datos.Lector["Id"];
					aux.Codigo = datos.Lector["Codigo"] is DBNull ? null : (string)datos.Lector["Codigo"];
					aux.Nombre = datos.Lector["Nombre"] is DBNull ? null : (string)datos.Lector["Nombre"];
					aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? null : (string)datos.Lector["Descripcion"];

					aux.Marca = new MarcaArticulo();
					aux.Marca.Id = (int)datos.Lector["IdMarca"];
					aux.Marca.Descripcion = datos.Lector["Marca"] is DBNull ? null : (string)datos.Lector["Marca"];

					aux.Categoria = new CategoriaArticulo();
					aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
					aux.Categoria.Descripcion = datos.Lector["Categoria"] is DBNull ? null : (string)datos.Lector["Categoria"];

					aux.ImagenUrl = datos.Lector["ImagenUrl"] is DBNull ? null : (string)datos.Lector["ImagenUrl"];
					aux.Precio = (decimal)datos.Lector["Precio"];

					listaEliminados.Add(aux);
				}

				return listaEliminados;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
	
		//7) REACTIVAR UN REGISTRO
		public void reactivarArticulo(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("UPDATE ARTICULOS SET Nombre = REPLACE(Nombre, 'ELIMINADO_', '') WHERE Id = @id");
				datos.setParametros("@id", id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		//8) AGREGAR A FAVORITOS
		public void agregarFavoritos(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("UPDATE SET FAVORITOS ");
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

	}
}
