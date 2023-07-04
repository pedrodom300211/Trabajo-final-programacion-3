using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data.SqlClient;

namespace Vistas
{
    public partial class ObservacionesGenerales : System.Web.UI.Page
    { 
        NegocioObservacionGeneral neg = new NegocioObservacionGeneral();
        NegocioAreas negocioAreas = new NegocioAreas();
        NegocioPaciente negPaciente = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Server.Transfer("InicioSesion.aspx");
            }
            lblUsuario.Text = ((Usuario)Session["Admin"]).getDNI_U();
            lblNombreAdmin.Text = ((Usuario)Session["Admin"]).getDNI_U();
            if (IsPostBack == false)
            {
                // DropDownList Areas
                ddlCodigoArea.DataSource = negocioAreas.getTabla();
                ddlCodigoArea.DataTextField = "Descripcion_A";
                ddlCodigoArea.DataValueField = "CodArea_A";
                ddlCodigoArea.DataBind();
            }
        }
        
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Boolean estado;
           
            ObservacionGeneral obsGeneral = new ObservacionGeneral();
            Areas Area = new Areas();
            Paciente pac = new Paciente();

            if (neg.ValidarExistePaciente(txtDniPacienteOG.Text))
            {
                pac.setDNIPac_Pa(txtDniPacienteOG.Text.ToString());
                    obsGeneral.setDNIPac_OG(pac);
                    obsGeneral.setDescripcion_OG(txtDescripcionOG.Text.ToString());
                Area.setCodArea_A(ddlCodigoArea.Text.ToString());
                    obsGeneral.setCodArea_OG(Area);
                    estado = neg.agregarObsGeneral(obsGeneral);
                    if (estado == true)
                    {
                        lblAgregarObsGeneral.Text = "Observacion Agregada";
                        txtDniPacienteOG.Text = "";
                        txtDescripcionOG.Text = "";

                        ddlCodigoArea.SelectedIndex = 0;

                    }
               
            }else { lblAgregarObsGeneral.Text = "El DNI ingresado no es correcto"; }

           

        }

        protected void lnkbtnCerrarSecion_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Server.Transfer("MenuInicio.aspx");
        }
    }
}