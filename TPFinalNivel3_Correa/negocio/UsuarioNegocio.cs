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
		public int registrarAdministrador(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("INSERT INTO users (email, pass, nombre, apellido, admin) OUTPUT INSERTED.Id VALUES (@email, @pass, @nombre, @apellido, @admin)");
				datos.setParametros("@email", usuario.Email);
				datos.setParametros("@pass", usuario.Pass);
				datos.setParametros("@nombre", usuario.Nombre);
				datos.setParametros("@apellido", usuario.Apellido);
				datos.setParametros("@admin", true);
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
		public Usuario obtenerUsuarioPorId(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("SELECT Id, Email, Pass, Nombre, Apellido, urlImagenPerfil, Admin FROM USERS WHERE Id = @id");
				datos.setParametros("@id", id);
				datos.ejecutarLectura();

				if (datos.Lector.Read())
				{
					Usuario usuario = new Usuario();
					usuario.Id = (int)datos.Lector["Id"];
					usuario.Email = datos.Lector["Email"] is DBNull ? null : (string)datos.Lector["Email"];
					usuario.Pass = datos.Lector["Pass"] is DBNull ? null : (string)datos.Lector["Pass"];
					usuario.Nombre = datos.Lector["Nombre"] is DBNull ? null : (string)datos.Lector["Nombre"];
					usuario.Apellido = datos.Lector["Apellido"] is DBNull ? null : (string)datos.Lector["Apellido"];
					usuario.ImagenPerfil = datos.Lector["urlImagenPerfil"] is DBNull ? null : (string)datos.Lector["urlImagenPerfil"];
					usuario.Admin = (bool)datos.Lector["Admin"];

					return usuario;
				}
				return null;
			}
			catch (Exception ex)
			{
				throw ex;
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

		public void quitarAdmin(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("UPDATE USERS SET admin = @admin Where Id = @id");
				datos.setParametros("@id", usuario.Id);
				datos.setParametros("@admin", false);
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