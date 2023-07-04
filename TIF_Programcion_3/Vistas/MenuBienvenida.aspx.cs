using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class MenuBienvenida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DNIuser"] == null)
            {
                Server.Transfer("InicioSesion.aspx");
            }
            lblUsuario.Text = ((Paciente)Session["DNIuser"]).getNombreApellido_PA();
        }

        protected void lbtnCerrarSesionPaciente_Click(object sender, EventArgs e)
        {
            Session["DNIuser"] = null;
            Server.Transfer("MenuInicio.aspx");
        }
    }
}