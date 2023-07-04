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
    public partial class BajaYModificacionPaciente : System.Web.UI.Page
    { 
        private NegocioPaciente negocioPaciente = new NegocioPaciente();        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Server.Transfer("InicioSesion.aspx");
            }
            lblUsuario.Text = ((Usuario)Session["Admin"]).getDNI_U();
            if (!IsPostBack)
            {
                CargaGridView();

            }
        }

        protected void grdBajaModificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void grdBajaModificacion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String s_DNI = ((Label)grdBajaModificacion.Rows[e.NewEditIndex].FindControl("lblDNI")).Text;
            Session["DniPaciente"] = s_DNI;
            Server.Transfer("ModificarDatosPacientes.aspx");

        }

        protected void grdBajaModificacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            condicionPreviaEliminacion();
            lblDatoEliminacion.Text = ((Label)grdBajaModificacion.Rows[e.RowIndex].FindControl("lblDNI")).Text;
            string nombreApellido = ((Label)grdBajaModificacion.Rows[e.RowIndex].FindControl("NombreApellido")).Text;
            lblMensaje.Text = lblMensaje.Text + " " + nombreApellido +"?";   
        }

        private void CargaGridView()
        {
            grdBajaModificacion.DataSource = negocioPaciente.getTabla();
            grdBajaModificacion.DataBind();
        }

        private void CargaGridViewFiltro(String dni, String simbolo)
        {
            grdBajaModificacion.DataSource = negocioPaciente.obtenerTablaEspecificaConFiltro(dni, simbolo);
            grdBajaModificacion.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e) /// ---> Botón continuar !!!
        {
            grdBajaModificacion.Enabled = true;
            string dni = lblDatoEliminacion.Text;
            Boolean confirmacionDeEliminacion = false;
            confirmacionDeEliminacion = negocioPaciente.BajaPaciente(dni);

            if (confirmacionDeEliminacion == true)
            {
                CargaGridView();
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAceptar2.Enabled = true;
                btnAceptar2.Visible = true;
                lblMensaje2.Enabled = true;
                lblMensaje2.Text = "¡La baja del paciente ha sido exitosa!";
            }
            else
            {
                CargaGridView();
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAceptar2.Enabled = true;
                lblMensaje2.Enabled = true;
                btnAceptar2.Visible = true;
                lblMensaje2.Text = "No se ha podido dar de baja al paciente";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            condicionInicial();
        }

        protected void btnAceptar2_Click(object sender, EventArgs e)
        {
            condicionInicial();
        }

        protected void lnkbtnCerrarSecion_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Server.Transfer("MenuInicio.aspx");
        }

        protected void grdBajaModificacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBajaModificacion.PageIndex = e.NewPageIndex;
            if (txtDNI.Text != "")
            {
                CargaGridViewFiltro(txtDNI.Text, ddlSimbolo.SelectedValue);
            }
            else {
                CargaGridView(); 
            }
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            NegocioComposicionFamiliar negocio = new NegocioComposicionFamiliar();
            if (negocio.ValidarExistePaciente(txtDNI.Text))
            {
                grdBajaModificacion.DataSource = negocioPaciente.getTablaDNIFiltro(txtDNI.Text, ddlSimbolo.SelectedValue);
                grdBajaModificacion.DataBind();
                lblVacio.Text = "";
            }
            else {
                lblVacio.Text = "No existe tal DNI"; 
            }                              
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
                grdBajaModificacion.DataSource = negocioPaciente.getTabla();
                grdBajaModificacion.DataBind();
                txtDNI.Text = "";
                ddlSimbolo.SelectedIndex = 0;
                lblVacio.Text = "";  
        }

        private void condicionInicial() /// devuelve todos los controles a sus condiciones iniciales
        {
            ddlSimbolo.Enabled = true;
            txtDNI.Enabled = true;
            btnBuscar.Enabled = true;
            btnMostrarTodo.Enabled = true;
            grdBajaModificacion.Enabled = true;
            lblDatoEliminacion.Text = "";
            lblMensaje.Visible = false;
            lblMensaje.Text = "¿Desea dar de de baja al paciente ";
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            lblMensaje2.Text = "";
            lblMensaje2.Enabled = false;
            btnAceptar2.Visible = false;
            btnAceptar2.Enabled = false;
        }

        private void condicionPreviaEliminacion()
        {
            ddlSimbolo.Enabled = false;
            txtDNI.Enabled = false;
            btnBuscar.Enabled = false;
            btnMostrarTodo.Enabled = false;
            grdBajaModificacion.Enabled = false;
            lblMensaje.Visible = true;
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
        }
    }
}