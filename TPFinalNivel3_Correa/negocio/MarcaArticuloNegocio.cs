using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
	public class MarcaArticuloNegocio
	{
		public List<MarcaArticulo> listar()
		{
			List<MarcaArticulo> lista = new List<MarcaArticulo>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("select Id, Descripcion from MARCAS");
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					MarcaArticulo aux = new MarcaArticulo();
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
