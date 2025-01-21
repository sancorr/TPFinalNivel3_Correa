﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPFinalNivel3_Correa.negocio;
using TPFinalNivel3_Correa.dominio;

namespace TPFinalNivel3_Correa
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				imgAvatar.ImageUrl = "https://imgs.search.brave.com/UoEGoEVhpqRO83GQUva4-8Xw_r1PhAGKGtCKmb9aaDA/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly90NC5m/dGNkbi5uZXQvanBn/LzA4Lzc1LzQ1Lzk3/LzM2MF9GXzg3NTQ1/OTcxOV84aTdKM2F0/R2JzRG9SUFQwWlcw/RGpCcGdBRlZUcktB/ZS5qcGc";

				if(!(Page is Default || Page is Registro || Page is Login || Page is Detalle))
				{
					if (!Seguridad.sesionActiva(Session["sesionAbierta"]))
					{
						Response.Redirect("Login.aspx", false);
					}
					else
					{
						Usuario usuario = (Usuario)Session["sesionAbierta"];
						if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
							imgAvatar.ImageUrl = "~/Imagenes/Perfil/" + usuario.ImagenPerfil;
					}
				}
				else if((Page is Default || Page is Detalle) && Seguridad.sesionActiva(Session["sesionAbierta"]))
				{
					Usuario usuario = (Usuario)Session["sesionAbierta"];
					if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
						imgAvatar.ImageUrl = "~/Imagenes/Perfil/" + usuario.ImagenPerfil;
				}
			}
		}

		protected void btnSalir_Click(object sender, EventArgs e)
		{
			try
			{
				Session.Clear();
				Response.Redirect("Default.aspx", false);
			}
			catch (Exception ex)
			{
				Session.Add("error", ex);
				//REDIRECCIONAR A ERROR
				throw;
			}
		}
	}
}