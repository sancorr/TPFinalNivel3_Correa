using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using TPFinalNivel3_Correa.dominio;

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
					aux.Categoria.Descripcion = datos.Lector["Categoria"] is DBNull ? null : (string)datos.Lector["Categoria"];

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
		//2) ELIMINAR ARTICULOS YENDO A DB
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

		//8) LISTAR MARCAS PARA FILTRO
		public List<MarcaArticulo> listadoMarcas()
		{
			List<MarcaArticulo> marcas = new List<MarcaArticulo>();
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setConsulta("select Id, Descripcion from MARCAS");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					MarcaArticulo aux = new MarcaArticulo();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? null : (string)datos.Lector["Descripcion"];

					marcas.Add(aux);
				}

				return marcas;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		//9) LISTAR CATEGORIAS PARA FILTRO
		public List<CategoriaArticulo> listadoCategorias()
		{
			List<CategoriaArticulo> categorias = new List<CategoriaArticulo>();
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setConsulta("select Id, Descripcion from CATEGORIAS");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					CategoriaArticulo aux = new CategoriaArticulo();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? null : (string)datos.Lector["Descripcion"];

					categorias.Add(aux);
				}

				return categorias;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		//10) FILTRAR PRODUCTOS EN DB
		public List<Articulo> filtroProductos(string campo, string criterio, string filtro)
		{
			List<Articulo> listaFiltrada = new List<Articulo>();
			AccesoDatos datos = new AccesoDatos();

			try
			{
				string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio, C.Descripcion Categoria, M.Descripcion Marca from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id AND A.IdMarca = M.Id AND A.Nombre NOT LIKE 'ELIMINADO_%' AND ";

				if (campo == "Precio")
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
				}
				else if (campo == "Nombre")
				{
					switch (criterio)
					{
						case "Comienza con":
							consulta += "Nombre like @filtro + '%' ";
							break;
						case "Contiene":
							consulta += "LOWER(Nombre) like '%' + @filtro + '%'";
							break;
						default:
							consulta += "LOWER(Nombre) like '%' + @filtro";
							break;
					}
				}
				else if (campo == "Marca")
				{
					//LOWER(M.Descripcion) like '%' + @filtro + '%'
					consulta += "LOWER(Nombre) like '%' + @filtro + '%'";
				}
				else
				{
					//LOWER(C.Descripcion) like '%' + @filtro + '%'
					consulta += "LOWER(Nombre) like '%' + @filtro + '%'";
				}

				datos.setConsulta(consulta);
				datos.setParametros("@filtro", filtro.ToLower());
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Articulo aux = new Articulo();

					aux.Codigo = datos.Lector["Codigo"] is DBNull ? null : (string)datos.Lector["Codigo"];
					aux.Nombre = datos.Lector["Nombre"] is DBNull ? null : (string)datos.Lector["Nombre"];
					aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? null : (string)datos.Lector["Descripcion"];
					aux.Precio = (decimal)datos.Lector["Precio"];
					aux.ImagenUrl = datos.Lector["ImagenUrl"] is DBNull ? null : (string)datos.Lector["ImagenUrl"];

					aux.Marca = new MarcaArticulo();
					aux.Marca.Descripcion = datos.Lector["Marca"] is DBNull ? null : (string)datos.Lector["Marca"];

					aux.Categoria = new CategoriaArticulo();
					aux.Categoria.Descripcion = datos.Lector["Categoria"] is DBNull ? null : (string)datos.Lector["Categoria"];

					aux.IdMarca = (int)datos.Lector["IdMarca"];
					aux.IdCategoria = (int)datos.Lector["IdCategoria"];

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
		//11) INSERTAR ARTICULO EN FAVORITOS
		public void agregarFavorito(int idUser, int idArt)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo) values (@idUser, @idArticulo)");
				datos.setParametros("idUser", idUser);
				datos.setParametros("idArticulo", idArt);
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
		//12) LISTAR FAVORITOS
		public List<Articulo> listarFavoritos(int idUser, string idArt = "")
		{
			AccesoDatos datos = new AccesoDatos();
			List<Articulo> favoritos = new List<Articulo>();
			try
			{
				string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, F.IdUser, F.IdArticulo, F.Id FROM ARTICULOS A INNER JOIN FAVORITOS F ON A.Id = F.IdArticulo WHERE F.IdUser = @IdUser ";

				if (idArt != "")
					datos.setConsulta(consulta + " AND F.IdArticulo =" + idArt);
				else
					datos.setConsulta(consulta);

				datos.setParametros("@IdUser", idUser);
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Articulo aux = new Articulo();
					aux.Id = (int)datos.Lector["Id"];
					aux.Codigo = datos.Lector["Codigo"] is DBNull ? null : (string)datos.Lector["Codigo"];
					aux.Nombre = datos.Lector["Nombre"] is DBNull ? null : (string)datos.Lector["Nombre"];
					aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? null : (string)datos.Lector["Descripcion"];

					aux.ImagenUrl = datos.Lector["ImagenUrl"] is DBNull ? null : (string)datos.Lector["ImagenUrl"];
					aux.Precio = (decimal)datos.Lector["Precio"];

					aux.Favorito = new ArtFavorito();
					aux.Favorito.Id = (int)datos.Lector["Id"];
					aux.Favorito.IdUser = (int)datos.Lector["IdUser"];
					aux.Favorito.IdArticulo = (int)datos.Lector["IdArticulo"];

					favoritos.Add(aux);
				}
				return favoritos;
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
		//13) ELIMNAR FAVORITO
		public void eliminarFavorito(int id, int userId)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("delete from FAVORITOS where IdArticulo = @id AND IdUser = @userId");
				datos.setParametros("@id", id);
				datos.setParametros("@userId", userId);
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
		//14) AGREGAR MARCA
		public void agregarMarca(string marca)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("INSERT INTO MARCAS values (@marca)");
				datos.setParametros("@marca", marca);
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
		//15) AGREGAR CATEGORIA
		public void agregarCategoria(string categoria)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("INSERT INTO CATEGORIAS values (@categoria)");
				datos.setParametros("@categoria", categoria);
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
	}
}
