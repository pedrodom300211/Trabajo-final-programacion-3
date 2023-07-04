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
    public partial class DatosPacienteID : System.Web.UI.Page
    {
        private NegocioObservacionGeneral negocioObservacionGeneral = new NegocioObservacionGeneral();
        private NegocioTratamiento negocioTratamiento = new NegocioTratamiento();
        private NegocioComposicionFamiliar negocioComposicionFamiliar = new NegocioComposicionFamiliar();
        private NegocioAcercamiento negocioAcercamiento = new NegocioAcercamiento();
        private NegocioSituacionLaboral negocioSituacionLaboral = new NegocioSituacionLaboral();
        private NegocioAreas negocioAreas = new NegocioAreas();
        private NegocioPaciente negocioPaciente = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DNIuser"] == null)
            {
                Server.Transfer("InicioSesion.aspx");
            }
            String session = ((Paciente)Session["DNIUser"]).getDNIPac_Pa();
            lblUsuario.Text = ((Paciente)Session["DNIuser"]).getNombreApellido_PA();
            if (!IsPostBack)
            {
                // GridView Paciente por DNI
                cargarGridPacienteDNILaborAcercamiento();
                // GridView Observaciones Generales por DNI
                cargarGridObservacionesGenerales();
                // GridView Tratamientos por DNI
                cargarGridTratamientos();
                // GridView Composicion Familiar por DNI
                cargarGridComposicionFamiliar();
            }
        }
        protected void lbtnCerrarSesionPaciente_Click(object sender, EventArgs e)
        {
            Session["DNIuser"] = null;
            Server.Transfer("MenuInicio.aspx");
        }
        // GridView Paciente por DNI Situacion Laboral y Acercamiento
        public void cargarGridPacienteDNILaborAcercamiento()
        {
            String session = ((Paciente)Session["DNIUser"]).getDNIPac_Pa();
            grdPaciente.DataSource = negocioPaciente.getTablaDNILaborAcercamiento(session);
            grdPaciente.DataBind();
        }
        // GridView Observaciones Generales por DNI
        public void cargarGridObservacionesGenerales()
        {
            String session = ((Paciente)Session["DNIUser"]).getDNIPac_Pa();
            grdObsGeneral.DataSource = negocioObservacionGeneral.getTablaDNI(session);
            grdObsGeneral.DataBind();
        }
        // GridView Tratamientos por DNI
        public void cargarGridTratamientos()
        {
            String session = ((Paciente)Session["DNIUser"]).getDNIPac_Pa();
            grdvTratamiento.DataSource = negocioTratamiento.getTablaDNI(session);
            grdvTratamiento.DataBind();
        }
        // GridView Composicion Familiar por DNI
        public void cargarGridComposicionFamiliar()
        {
            String session = ((Paciente)Session["DNIUser"]).getDNIPac_Pa();
            grdvComposicionFamiliar.DataSource = negocioComposicionFamiliar.getTablaDNI(session);
            grdvComposicionFamiliar.DataBind();
        }
    }
}