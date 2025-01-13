using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
	public class CategoriaArticuloNegocio
	{
		public List<CategoriaArticulo> listar()
		{
			List<CategoriaArticulo> lista = new List<CategoriaArticulo>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("select Id, Descripcion from CATEGORIAS");
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					CategoriaArticulo aux = new CategoriaArticulo();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

					lista.Add(aux);
				}
				return lista;
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
