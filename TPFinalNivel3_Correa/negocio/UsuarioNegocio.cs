using negocio;
using System;
using TPFinalNivel3_Correa.dominio;

namespace TPFinalNivel3_Correa.negocio
{
	public class UsuarioNegocio
	{
		public int registrarUsuario(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			try  
			{
				datos.setConsulta("INSERT INTO users (email, pass, nombre, apellido) OUTPUT INSERTED.Id VALUES (@email, @pass, @nombre, @apellido)");
				datos.setParametros("@email", usuario.Email);
				datos.setParametros("@pass", usuario.Pass);
				datos.setParametros("@nombre", usuario.Nombre);
				datos.setParametros("@apellido", usuario.Apellido);
				return datos.ejecutarAccionScalar();
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
	
	
		public bool ingresarUsuario(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{

				datos.setConsulta("select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from users Where email = @email And pass = @pass");
				datos.setParametros("@email",usuario.Email);
				datos.setParametros("@pass",usuario.Pass);
				datos.ejecutarLectura();
				if (datos.Lector.Read())
				{
					usuario.Id = (int)datos.Lector["Id"];
					usuario.Email = (string)datos.Lector["email"];
					usuario.Pass = (string)datos.Lector["pass"];
					usuario.Admin = (bool)datos.Lector["admin"];
					if(!(datos.Lector["nombre"] is DBNull))
						usuario.Nombre = (string)datos.Lector["nombre"];
					if (!(datos.Lector["apellido"] is DBNull))
						usuario.Apellido = (string)datos.Lector["apellido"];
					if (!(datos.Lector["urlImagenPerfil"] is DBNull))
						usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];

					return true;
				}
				return false;
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
	
		public void actualizarUsuario(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("UPDATE USERS SET nombre = @nombre, apellido = @apellido, urlImagenPerfil = @imagen Where Id = @id");
				datos.setParametros("@nombre", (object)usuario.Nombre ?? DBNull.Value);
				datos.setParametros("@apellido", (object)usuario.Apellido ?? DBNull.Value);
				datos.setParametros("@imagen", (object)usuario.ImagenPerfil ?? DBNull.Value);
				datos.setParametros("@id", usuario.Id);
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