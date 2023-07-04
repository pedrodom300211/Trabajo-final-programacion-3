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
    public partial class Tratamiento : System.Web.UI.Page
    {
        private NegocioTratamiento Tra = new NegocioTratamiento();
        private NegocioPaciente np = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Server.Transfer("InicioSesion.aspx");
            }
            lblUsuario.Text = ((Usuario)Session["Admin"]).getDNI_U();
            lblAdmin.Text = ((Usuario)Session["Admin"]).getDNI_U();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            bool estado;

            if (Tra.verificarDNI(txtDNIPaciente.Text))
            {
                Tratamientos tratamientos = new Tratamientos();
                Paciente pac = new Paciente();
                pac.setDNIPac_Pa(txtDNIPaciente.Text.ToString());
                tratamientos.setDNIPac_Tr(pac);
                tratamientos.setDroga_Tr(txtDroga.Text.ToString());
                tratamientos.setMarca_Tr(txtMarcaDroga.Text.ToString());
                tratamientos.setPsicoterapia_Tr(chbxPsicoterapiaSI.Checked);
                tratamientos.setRehabilitacion_Tr(chkbxRehabilitacionSI.Checked);
                tratamientos.setTO_Tr(chkbxTOSI.Checked);
                tratamientos.setOtras_Tr(chkbxOtrasSI.Checked);


                estado = Tra.agregarTratamiento(tratamientos);

                if (estado == true)
                {
                    lblTratamientoAgregado.Text = "Tratamiento agregado con exito";

                    txtDNIPaciente.Text = "";
                    txtDroga.Text = "";
                    txtMarcaDroga.Text = "";
                    chbxPsicoterapiaSI.Checked = false;

                    chkbxRehabilitacionSI.Checked = false;

                    chkbxTOSI.Checked = false;

                    chkbxOtrasSI.Checked = false;
                    lblDNIIncorrecto.Text = "";

                }
                else
                {
                    lblTratamientoAgregado.Text = "No se pudo agregar el tratamiento";
                }
            }
            else
            {
                lblDNIIncorrecto.Text = "El DNI no es correcto";
                
            }
        }

        protected void chkbxTOSI_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void lnkbtnCerrarSecion_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Server.Transfer("MenuInicio.aspx");
        }
    }
}