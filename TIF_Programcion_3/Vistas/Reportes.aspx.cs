using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio; 

namespace Vistas
{
    public partial class Reportes : System.Web.UI.Page
    {
        private NegocioObservacionGeneral negocioObservacionGeneral = new NegocioObservacionGeneral();
        private NegocioTratamiento negocioTratamiento = new NegocioTratamiento(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DNIuser"] == null)
            {
                Server.Transfer("InicioSesion.aspx");
            }
            String session = ((Paciente)Session["DNIUser"]).getDNIPac_Pa();
            lblUsuarioNavBar.Text= ((Paciente)Session["DNIuser"]).getNombreApellido_PA();
            lblUsuario.Text = ((Paciente)Session["DNIuser"]).getNombreApellido_PA();

            grdObsGenerales.DataSource = negocioObservacionGeneral.getTablaDNI(session);
            grdObsGenerales.DataBind();

            grdvTratamientos.DataSource = negocioTratamiento.getTablaDNI(session);
            grdvTratamientos.DataBind(); 
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String session = ((Paciente)Session["DNIUser"]).getDNIPac_Pa();

            grdObsGenerales.DataSource = negocioObservacionGeneral.getObservacionGeneral(ddlAreas.SelectedValue.ToString(), session);
            grdObsGenerales.DataBind();

            if (grdObsGenerales.Rows.Count == 0)
            {
                lblVacio.Text = "Ninguna observacion encontrada con ese area";
            }
            else {
                lblVacio.Text = "";
                lblVacioDroga.Text = "";
            }
        }

        protected void btnBuscarDroga_Click(object sender, EventArgs e)
        {
            String session = ((Paciente)Session["DNIUser"]).getDNIPac_Pa();

            grdvTratamientos.DataSource = negocioTratamiento.getTratamiento(txtDroga.Text, session);
            grdvTratamientos.DataBind();

            if (grdvTratamientos.Rows.Count == 0)
            {
                lblVacioDroga.Text = "Tratamiento con droga no encontrada";
            }
            else {
                lblVacioDroga.Text = "";
                lblVacio.Text = "";
            }

        }

        protected void lbtnCerrarSesionPaciente_Click(object sender, EventArgs e)
        {
            Session["DNIuser"] = null;
            Server.Transfer("MenuInicio.aspx");
        }
    }
}