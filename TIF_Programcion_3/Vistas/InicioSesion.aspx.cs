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
    public partial class MenuInicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            NegocioPaciente negocioPaciente = new NegocioPaciente();
            Usuario usuario = new Usuario();
            usuario.setDNI_U(txtDniDeUsuario.Text);
            lblUsuarioInexistente.Visible = false;
            lblContraseñaIncorrecta.Visible = false;

            if (negocioUsuario.existeUsuariorDNI(usuario)) // Comprobacion de la existencia del usuario dentro del sistema
            {
                usuario = negocioUsuario.get(txtDniDeUsuario.Text);
                if (usuario.getDNI_U() == txtDniDeUsuario.Text && usuario.getContraseña_U() == txtContraseña.Text && usuario.getEstado())
                {
                    if (Session["DNIUser"] == null & !usuario.getRol_U())
                    {
                        Session["DNIUser"] = negocioPaciente.getPaciente(usuario.getDNI_U());
                    }
                    txtDniDeUsuario.Text = "";
                    txtContraseña.Text = "";
                    lblUsuarioInexistente.Text = "";
                    if (usuario.getRol_U())
                    {
                        if (Session["Admin"] == null)
                        {
                            Session["Admin"] = usuario;
                        }
                        Server.Transfer("MenuAdmin.aspx");
                    }
                    Server.Transfer("MenuBienvenida.aspx");
                }
                else
                {
                    if (usuario.getEstado())
                    {
                        lblContraseñaIncorrecta.Visible = true;
                    }
                    else
                    {
                        lblUsuarioInexistente.Visible = true;
                    }
                }
            }
            else // Si el usuario no existe da una alerta
            {
                if (txtContraseña.Text == "")
                {
                    lblUsuarioInexistente.Visible = true;
                    lblContraseñaIncorrecta.Visible = true;
                }
                else
                {
                    lblUsuarioInexistente.Visible = true;
                }

            }
        }
    }
}