﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using dominio;

namespace negocio
{
	public class AccesoDatos
	{
		private SqlConnection conexion;
		private SqlCommand comando;
		private SqlDataReader lector;
		public SqlDataReader Lector
		{
			get { return lector; }
		}

		public AccesoDatos()
		{
				conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
				comando = new SqlCommand();
		}

		public void setConsulta(string consulta)
		{
			comando.CommandType = System.Data.CommandType.Text;
			comando.CommandText = consulta;
		}

		public void ejecutarLectura()
		{
			comando.Connection = conexion;
			try
			{
				conexion.Open();
				lector = comando.ExecuteReader();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al leer archivos: " + ex.Message);
			}
		}

		public void cerrarConexion()
		{
			if (lector != null)
				lector.Close();

			conexion.Close();
		}

		public void setParametros(string nombre, object valor)
		{
			comando.Parameters.AddWithValue(nombre, valor);
		}

		public void ejecutarAccion()
		{
			comando.Connection = conexion;
			try
			{
				conexion.Open();
				comando.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	
		public int ejecutarAccionScalar()
		{
			comando.Connection = conexion;
			try
			{
				conexion.Open();
				return int.Parse(comando.ExecuteScalar().ToString());
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
