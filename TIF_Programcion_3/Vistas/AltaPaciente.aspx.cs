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
{ ///v35
    public partial class AltaPaciente : System.Web.UI.Page
    {
        private NegocioPaciente neg = new NegocioPaciente();
        private NegocioSituacionLaboral negocioSituacionLaboral = new NegocioSituacionLaboral();
        private NegocioAcercamiento negocioAcercamiento = new NegocioAcercamiento();
        private NegocioUsuario negU = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Server.Transfer("InicioSesion.aspx");
            }
            lblUsuario.Text = ((Usuario)Session["Admin"]).getDNI_U();
            if (IsPostBack == false)
            {
               
                ddlSituacionLaboral.DataSource = negocioSituacionLaboral.getTabla();
                ddlSituacionLaboral.DataTextField = "Descripcion_SL";
                ddlSituacionLaboral.DataValueField = "CodSitLab_SL";
                ddlSituacionLaboral.DataBind();
                
                ddlAcercamiento.DataSource = negocioAcercamiento.getTabla();
                ddlAcercamiento.DataTextField = "Descripcion_A";
                ddlAcercamiento.DataValueField = "CodAcerc_A";
                ddlAcercamiento.DataBind();
            }
        }

        protected void btnDarAlta_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = new DateTime(1900,1,1,1,1,1);
            Boolean estado,estadoUsuario;
            Paciente paciente = new Paciente();
            SituacionLaboral SitLab = new SituacionLaboral();
            Acercamiento Acer = new Acercamiento();
            Usuario Usuario = new Usuario();

                paciente.setDNIPac_Pa(txtDNI.Text.ToString());
                paciente.setNombreApellido_PA(txtNombre.Text.ToString());
                paciente.setNomAcompaniante_Pa(txtNombreAcompaniante.Text.ToString());
                paciente.setEdad_PA(txtEdad.Text.ToString());
                paciente.setParentezco_Pa(txtParentezco.Text.ToString());
                paciente.setFechaEntrevista_Pa(Convert.ToDateTime(txtFechaEntrevista.Text));
                if (chkbxCUD.Checked == true)
                {
                    paciente.setCUD_Pa(chkbxCUD.Checked);
                    paciente.setVencimientoCUD_Pa(Convert.ToDateTime(txtVencimientoCUD.Text));
                }
                else
                {
                    paciente.setCUD_Pa(false);
                    paciente.setVencimientoCUD_Pa(Convert.ToDateTime(fechaActual));
                }
            SitLab.setCodSitLab_SL(ddlSituacionLaboral.SelectedValue);
                
                paciente.setCodSitLab_SL_Pa(SitLab);
                Acer.setCodAcerc_A(ddlAcercamiento.SelectedValue);
                paciente.setCodAcerc_A_Pa(Acer);
                paciente.setMotivoConsulta_Pa(txtMotivoConsulta.Text.ToString());
                //Usuario.setDNI_U("");
                Usuario.setDNI_U(paciente.getDNIPac_Pa());
                Usuario.setContraseña_U(txtContraseña1.Text.ToString());


                if (txtContraseña1.Text != txtContraseña2.Text)
                {
                    estadoUsuario = false;
                    estado = false;
                    lblContraseñasIguales.Visible = true;
                }
                else
                {
                    estadoUsuario = true;
                    estado = neg.agregarPaciente(paciente);
                    estadoUsuario = negU.agregarUsuario(Usuario);
                }

                if (estado == true && estadoUsuario == true)
                {
                    lblPacienteAgregado.Text = "Paciente agregado con exito";

                    txtDNI.Text = "";
                    txtFechaEntrevista.Text = "";
                    txtNombre.Text = "";
                    txtEdad.Text = "";
                    txtNombreAcompaniante.Text = "";
                    txtParentezco.Text = "";
                    txtFechaEntrevista.Text = "";
                    chkbxCUD.Checked = false;
                    txtVencimientoCUD.Text = "";
                    ddlSituacionLaboral.SelectedIndex = 0;
                    ddlAcercamiento.SelectedIndex = 0;
                    txtMotivoConsulta.Text = "";
                    txtContraseña1.Text = "";
                    txtContraseña2.Text = "";
                    lblContraseñasIguales.Visible = false;

                }
                else
                {
                    Usuario.setDNI_U(txtDNI.Text);
                    if (negU.existeUsuariorDNI(Usuario))
                    {
                        lblPacienteAgregado.Text = "El DNI ya existe dentro del sistema";
                    }
                    else
                    {
                        lblPacienteAgregado.Text = "No se pudo dar de alta el  Paciente";
                    }
                }
        }

        protected void lnkbtnCerrarSecion_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Server.Transfer("MenuInicio.aspx");
        }

        protected void chkbxCUD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxCUD.Checked == true)
            {
                txtVencimientoCUD.Enabled = true;
            }
            else
            {
                txtVencimientoCUD.Enabled = false;
            }
        }
       
    }
}