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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private NegocioObservacionGeneral negocioObservacionGeneral = new Negocio.NegocioObservacionGeneral();
        private NegocioTratamiento negocioTratamiento = new Negocio.NegocioTratamiento();
        private NegocioComposicionFamiliar negocioComposicionFamiliar1 = new Negocio.NegocioComposicionFamiliar();
        private NegocioPaciente negocioPaciente = new Negocio.NegocioPaciente();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Paciente pac = new Paciente();
            if (Session["Admin"] == null)
            {
                Server.Transfer("InicioSesion.aspx");
            }
            lblUsuario.Text = ((Usuario)Session["Admin"]).getDNI_U();
            lblNombrePaciente.Text = Session["DniPaciente"].ToString();
            if (!IsPostBack)
            {

                grdObservacionesGenerales.DataSource = negocioObservacionGeneral.getTablaDNI2(Session["DniPaciente"].ToString());
                grdObservacionesGenerales.DataBind();

                grdTratamientos.DataSource = negocioTratamiento.getTablaDNI(Session["DniPaciente"].ToString());
                grdTratamientos.DataBind();

                grdComposicionFamiliar.DataSource = negocioComposicionFamiliar1.getTablaDNI(Session["DniPaciente"].ToString());
                grdComposicionFamiliar.DataBind();

                grdPaciente.DataSource = negocioPaciente.getTablaDNI(Session["DniPaciente"].ToString());
                grdPaciente.DataBind(); 
            }
        }

        public void cargarGridViewObservacionesGenerales()
        {
            NegocioObservacionGeneral negocioObservacionGeneral = new NegocioObservacionGeneral();
            grdObservacionesGenerales.DataSource = negocioObservacionGeneral.obtenerTabla();
            grdObservacionesGenerales.DataBind();
        }

        public void cargarGridViewObservacionesGeneralesEspecifica(String dni, String numObserv)
        {
            NegocioObservacionGeneral negocioObservacionGeneral = new NegocioObservacionGeneral();
            grdObservacionesGenerales.DataSource = negocioObservacionGeneral.obtenerTablaEspecifica(dni, numObserv);
            grdObservacionesGenerales.DataBind();
        }

        public void cargarGridViewTratamientosEspecificos(String dni, String numTram)
        {
            NegocioTratamiento negocioTratamiento = new NegocioTratamiento();
            grdTratamientos.DataSource = negocioTratamiento.obtenerTablaEspecifica(dni);
            grdTratamientos.DataBind();
        }

        public void cargarGridViewTratamientos()
        {
            NegocioTratamiento negocioTratamiento = new NegocioTratamiento();
            grdTratamientos.DataSource = negocioTratamiento.obtenerTabla();
            grdTratamientos.DataBind();
        }


        protected void grvTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String s_Observacion = ((Label)grdObservacionesGenerales.Rows[e.NewEditIndex].FindControl("lblNumOG")).Text;
            grdObservacionesGenerales.EditIndex = e.NewEditIndex;
            cargarGridViewObservacionesGeneralesEspecifica(Session["DniPaciente"].ToString(), s_Observacion);
        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String s_NumObser = ((Label)grdObservacionesGenerales.Rows[e.RowIndex].FindControl("labelEditingNum")).Text;
            String s_DniObser = ((Label)grdObservacionesGenerales.Rows[e.RowIndex].FindControl("labelDniEditing")).Text;
            String s_Descrip = ((TextBox)grdObservacionesGenerales.Rows[e.RowIndex].FindControl("txtDescripcion")).Text;
            String s_CodigoArea = ((DropDownList)grdObservacionesGenerales.Rows[e.RowIndex].FindControl("ddlAreas")).SelectedValue;

            if (s_Descrip.Trim() != "")
            {
                ObservacionGeneral observacionGeneral = new ObservacionGeneral();
                Areas Area = new Areas();
                Paciente pac = new Paciente();
                pac.setDNIPac_Pa(s_DniObser);
                observacionGeneral.setNumObser_OG(Convert.ToInt32(s_NumObser));
                observacionGeneral.setDNIPac_OG(pac);
                observacionGeneral.setDescripcion_OG(s_Descrip);
                ///Seteamos obj
                Area.setCodArea_A(s_CodigoArea);
                observacionGeneral.setCodArea_OG(Area);

                NegocioObservacionGeneral negocioObservacionGeneral = new NegocioObservacionGeneral();
                negocioObservacionGeneral.ModificarObservacionGeneral(observacionGeneral);

                grdObservacionesGenerales.EditIndex = -1;
                cargarGridViewObservacionesGeneralesEspecifica(s_DniObser, s_NumObser);

                lblErrorOG.Text = "";
            }
            else {
                lblErrorOG.Text = "Descripcion vacia";
            }
            grdObservacionesGenerales.DataBind();

        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            String s_Observacion = ((Label)grdObservacionesGenerales.Rows[e.RowIndex].FindControl("labelEditingNum")).Text;
            grdObservacionesGenerales.EditIndex = -1;
            cargarGridViewObservacionesGeneralesEspecifica(Session["DniPaciente"].ToString(), s_Observacion);
            grdObservacionesGenerales.DataBind();
        }

        /* ------------------------------------------------------- */

        protected void GridView5_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {       
            String s_NumTram = ((Label)grdTratamientos.Rows[e.RowIndex].FindControl("lblNumTramEditing")).Text;
            String s_DniPaciente = ((Label)grdTratamientos.Rows[e.RowIndex].FindControl("lblDniEditing")).Text;
            String s_DrogaTr = ((TextBox)grdTratamientos.Rows[e.RowIndex].FindControl("txtDrogaEditing")).Text;
            String s_Marca = ((TextBox)grdTratamientos.Rows[e.RowIndex].FindControl("txtMarcaEditing")).Text;
            Boolean s_Psicoterapia = ((CheckBox)grdTratamientos.Rows[e.RowIndex].FindControl("chPsicoterapia")).Checked;
            Boolean s_Rehabilitacion = ((CheckBox)grdTratamientos.Rows[e.RowIndex].FindControl("chBoxRehabilitacion")).Checked;
            Boolean s_TO = ((CheckBox)grdTratamientos.Rows[e.RowIndex].FindControl("chBoxTO")).Checked;
            Boolean s_Otros = ((CheckBox)grdTratamientos.Rows[e.RowIndex].FindControl("chBoxOtrasEditing")).Checked;

            if (s_DrogaTr.Trim() != "" && s_Marca.Trim() != "")
            {
                Paciente pac = new Paciente();
                Tratamientos tratamientos = new Tratamientos();
                tratamientos.setNumTram_Tr(Convert.ToInt32(s_NumTram));
                ///seteamos paciente 
                pac.setDNIPac_Pa(s_DniPaciente);
                tratamientos.setDNIPac_Tr(pac);
                tratamientos.setDroga_Tr(s_DrogaTr);
                tratamientos.setMarca_Tr(s_Marca);
                tratamientos.setPsicoterapia_Tr(s_Psicoterapia);
                tratamientos.setRehabilitacion_Tr(s_Rehabilitacion);
                tratamientos.setTO_Tr(s_TO);
                tratamientos.setOtras_Tr(s_Otros);

                NegocioTratamiento negocioTratamiento = new NegocioTratamiento();
                negocioTratamiento.MOdificarNegocioTratamiento(tratamientos);

                grdTratamientos.EditIndex = -1;
                cargarGridViewTratamientosEspecificos(s_DniPaciente, s_NumTram);

                lblErrorTratamientos.Text = "";
            }
            else
            {
                lblErrorTratamientos.Text = "Rellene todos los campos por favor";
            }
        }

        protected void GridView5_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String s_NumTram = ((Label)grdTratamientos.Rows[e.NewEditIndex].FindControl("lblNumeroTratamiento")).Text;
            grdTratamientos.EditIndex = e.NewEditIndex;
            cargarGridViewTratamientosEspecificos(Session["DniPaciente"].ToString(), s_NumTram);
        }

        protected void GridView5_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            String s_NumTram = ((Label)grdTratamientos.Rows[e.RowIndex].FindControl("lblNumTramEditing")).Text;
            grdTratamientos.EditIndex = -1;
            cargarGridViewTratamientosEspecificos(Session["DniPaciente"].ToString(), s_NumTram);
        }

        /* ---------------------------------------------------------------------- */

        public void cargarGridViewComposicionFamiliarEspecifico( String dnipac)
        {
            NegocioComposicionFamiliar negocioComposicionFamiliar = new NegocioComposicionFamiliar();
            grdComposicionFamiliar.DataSource = negocioComposicionFamiliar.obtenerTablaEspecifica( dnipac);
            grdComposicionFamiliar.DataBind();
        }

        public void cargarGridViewComposicionFamiliar()
        {
            NegocioComposicionFamiliar negocioComposicionFamiliar = new NegocioComposicionFamiliar();
            grdComposicionFamiliar.DataSource = negocioComposicionFamiliar.obtenerTabla();
            grdComposicionFamiliar.DataBind();
        }

        protected void GridView6_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String s_DNIFam = ((Label)grdComposicionFamiliar.Rows[e.NewEditIndex].FindControl("lblDNIFam")).Text;
            grdComposicionFamiliar.EditIndex = e.NewEditIndex;
            cargarGridViewComposicionFamiliarEspecifico(Session["DniPaciente"].ToString()); 
        }

        protected void GridView6_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String s_DNIFam = ((Label)grdComposicionFamiliar.Rows[e.RowIndex].FindControl("lblDNIFamEditing")).Text;
            String s_DNIPac = ((Label)grdComposicionFamiliar.Rows[e.RowIndex].FindControl("lblDNIPacEditing")).Text;
            String s_NombreFamiliar = ((TextBox)grdComposicionFamiliar.Rows[e.RowIndex].FindControl("txtNombreEditing")).Text;
            String s_EdadFamiliar = ((TextBox)grdComposicionFamiliar.Rows[e.RowIndex].FindControl("txtEdadEditing")).Text;
            String s_OCupacionFamiliar = ((TextBox)grdComposicionFamiliar.Rows[e.RowIndex].FindControl("txtOcupacionEditing")).Text;
            Boolean s_ConviveFamiliar = ((CheckBox)grdComposicionFamiliar.Rows[e.RowIndex].FindControl("chBoxConviveEditing")).Checked; ;
            String s_TelefonoFamiliar = ((TextBox)grdComposicionFamiliar.Rows[e.RowIndex].FindControl("txtTelefonoEditing")).Text;
            String s_ParentescoFamiliar = ((TextBox)grdComposicionFamiliar.Rows[e.RowIndex].FindControl("txtParentesco")).Text;

            if (s_NombreFamiliar.Trim() != "" && s_EdadFamiliar.Trim() != "" && s_OCupacionFamiliar.Trim() != "" && s_TelefonoFamiliar.Trim() != "" && s_ParentescoFamiliar.Trim() != "")
            {
                if (Convert.ToInt32(s_EdadFamiliar) > 0)
                {
                    ComposicionFamiliar composicionFamiliar = new ComposicionFamiliar();
                    Paciente pac = new Paciente();
                    pac.setDNIPac_Pa(s_DNIPac);
                    composicionFamiliar.setDNIFAM_CF(s_DNIFam);
                    composicionFamiliar.setDNIPAC_CF(pac);
                    composicionFamiliar.setNombreFamiliar_CF(s_NombreFamiliar);
                    composicionFamiliar.setEdadFamiliar_CF(s_EdadFamiliar);
                    composicionFamiliar.setOcupacionFamiliar_CF(s_OCupacionFamiliar);
                    composicionFamiliar.setConviveFamiliar_CF(s_ConviveFamiliar);
                    composicionFamiliar.setTelefonoFamiliar_CF(s_TelefonoFamiliar);
                    composicionFamiliar.setParentescoFamiliar(s_ParentescoFamiliar);

                    NegocioComposicionFamiliar negocioComposicionFamiliar = new NegocioComposicionFamiliar();
                    negocioComposicionFamiliar.ModificarComposicionFamiliar(composicionFamiliar);

                    grdComposicionFamiliar.EditIndex = -1;
                    cargarGridViewComposicionFamiliarEspecifico( s_DNIPac);

                    lblErrorFamiliar.Text = "";
                }
                else
                {
                    lblErrorFamiliar.Text = "Error en la carga de datos";
                }
            }
            else
            {
                lblErrorFamiliar.Text = "Error en la carga de datos";
            }

        }

        protected void GridView6_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            String s_DNIFam = ((Label)grdComposicionFamiliar.Rows[e.RowIndex].FindControl("lblDNIFamEditing")).Text;
            grdComposicionFamiliar.EditIndex = -1;
            cargarGridViewComposicionFamiliarEspecifico(Session["DniPaciente"].ToString());
        }

        /* --------------------------------------------------------------------- */

        public void cargarGridViewPacientes()
        {
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            grdPaciente.DataSource = negocioPaciente.obtenerTabla();
            grdPaciente.DataBind();
        }

        public void cargarGridViewPacienteEspecifico(String dni)
        {
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            grdPaciente.DataSource = negocioPaciente.obtenerTablaEspecifica(dni);
            grdPaciente.DataBind();
        }

        protected void GridView7_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String s_DNI = ((Label)grdPaciente.Rows[e.RowIndex].FindControl("lbl_it_DNI")).Text;
            String s_NombreApellido = ((TextBox)grdPaciente.Rows[e.RowIndex].FindControl("txt_it_NombreApellido")).Text;
            String s_Edad = ((TextBox)grdPaciente.Rows[e.RowIndex].FindControl("txt_it_Edad")).Text;
            String s_NombreAcompaniante = ((TextBox)grdPaciente.Rows[e.RowIndex].FindControl("txt_it_NomAcompaniante")).Text;
            String s_Parentezco = ((TextBox)grdPaciente.Rows[e.RowIndex].FindControl("txt_it_Parentezco")).Text;
            String s_FechaEntrevista = ((TextBox)grdPaciente.Rows[e.RowIndex].FindControl("txt_it_FechaEntrevista")).Text;
            Boolean s_CUD = ((CheckBox)grdPaciente.Rows[e.RowIndex].FindControl("chBox_it_CUD")).Checked;
            String s_FechaVencimiento = ((TextBox)grdPaciente.Rows[e.RowIndex].FindControl("txt_it_FechaVencimiento")).Text;
            String s_Motivo = ((TextBox)grdPaciente.Rows[e.RowIndex].FindControl("txt_it_MotivoConsulta")).Text;
            String s_CodSit = ((DropDownList)grdPaciente.Rows[e.RowIndex].FindControl("ddlSituacionLaboral")).SelectedValue;
            String s_CodAcer = ((DropDownList)grdPaciente.Rows[e.RowIndex].FindControl("ddlAcercamiento")).SelectedValue;

            DateTime dateTime = DateTime.Now;

            if (s_NombreApellido.Trim() != "" && s_Edad.Trim() != "" && s_NombreAcompaniante.Trim() != "" && s_Parentezco.Trim() != "" && s_Motivo.Trim() != "")
            {
                
                    Paciente paciente = new Paciente();
                   SituacionLaboral sitLab = new SituacionLaboral();
                    Acercamiento Acer = new Acercamiento();

                    paciente.setDNIPac_Pa(s_DNI);
                    paciente.setNombreApellido_PA(s_NombreApellido);
                    paciente.setEdad_PA(s_Edad);
                    paciente.setNomAcompaniante_Pa(s_NombreAcompaniante);
                    paciente.setParentezco_Pa(s_Parentezco);
                    paciente.setFechaEntrevista_Pa(Convert.ToDateTime(s_FechaEntrevista));
                    paciente.setCUD_Pa(s_CUD);
                    paciente.setVencimientoCUD_Pa(Convert.ToDateTime(s_FechaVencimiento));
                    paciente.setMotivoConsulta_Pa(s_Motivo);
                    sitLab.setCodSitLab_SL(s_CodSit);
                    paciente.setCodSitLab_SL_Pa(sitLab);
                    Acer.setCodAcerc_A(s_CodAcer);
                    paciente.setCodAcerc_A_Pa(Acer);

                    NegocioPaciente negocioPaciente = new NegocioPaciente();
                    negocioPaciente.ModificarPaciente(paciente);

                    grdPaciente.EditIndex = -1;
                    cargarGridViewPacienteEspecifico(s_DNI);

                    lblErrorPaciente.Text = "";               
            }
            else
            {
                lblErrorPaciente.Text = "Error en la carga de entrevista";
            }
        }

        protected void GridView7_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String s_DNIPAc = ((Label)grdPaciente.Rows[e.NewEditIndex].FindControl("lblDNIPac")).Text;
            grdPaciente.EditIndex = e.NewEditIndex;
            cargarGridViewPacienteEspecifico(Session["DniPaciente"].ToString());

        }

        protected void GridView7_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            String s_DNI = ((Label)grdPaciente.Rows[e.RowIndex].FindControl("lbl_it_DNI")).Text;
            grdPaciente.EditIndex = -1;
            cargarGridViewPacienteEspecifico(Session["DniPaciente"].ToString());
        }

        protected void lnkbtnCerrarSecion_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Server.Transfer("MenuInicio.aspx");
        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}