using System;
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
				if(!(Page is Default || Page is Registro || Page is Login || Page is Detalle))
				{
					if (!Seguridad.sesionActiva(Session["sesionAbierta"]))
					{
						Response.Redirect("Login.aspx", false);
					}
				}
				else
				{
					Usuario usuario = (Usuario)Session["sesionAbierta"];
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