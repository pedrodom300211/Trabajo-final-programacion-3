using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MenuInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgBtnEMAWeb_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://ema.org.ar/");
        }

        protected void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            Server.Transfer("InicioSesion.aspx");
        }
    }
}