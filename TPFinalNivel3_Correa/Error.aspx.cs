using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Correa
{
	public partial class Error : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(Session["error"] != null)
			{
				string error = Session["error"].ToString();

				lblError.Text = error;
				lblError.Visible = true;
			}
		}
	}
}