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
    public partial class AgregarFamiliar : System.Web.UI.Page
    { private NegocioComposicionFamiliar NegFam = new NegocioComposicionFamiliar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Server.Transfer("InicioSesion.aspx");
            }
            lblUsuario.Text = ((Usuario)Session["Admin"]).getDNI_U();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            bool estado;
            if (NegFam.ValidarExistePaciente(txtDNIPaciente.Text))
            {
                ComposicionFamiliar ComFamiliar = new ComposicionFamiliar();
                Paciente pac = new Paciente();
                pac.setDNIPac_Pa(txtDNIPaciente.Text.ToString());
                ComFamiliar.setDNIPAC_CF(pac);
                ComFamiliar.setDNIFAM_CF(txtDniFamiliar.Text.ToString());
                ComFamiliar.setNombreFamiliar_CF(txtNombreFamiliar.Text.ToString());
                ComFamiliar.setEdadFamiliar_CF(txtEdadFamiliar.Text.ToString());
                ComFamiliar.setOcupacionFamiliar_CF(txtOcupacionFamiliar.Text.ToString());
                ComFamiliar.setConviveFamiliar_CF(chkbxConviveSI.Checked);
                ComFamiliar.setTelefonoFamiliar_CF(txtTelefono.Text.ToString());
                ComFamiliar.setParentescoFamiliar(txtParentezco.Text.ToString());
                estado = NegFam.agregarFamiliar(ComFamiliar);
                if (estado == true)
                {
                    txtDniFamiliar.Text = "";
                    txtDNIPaciente.Text = "";
                    txtEdadFamiliar.Text = "";
                    txtNombreFamiliar.Text = "";
                    txtOcupacionFamiliar.Text = "";
                    chkbxConviveSI.Checked = false;
                    txtTelefono.Text = "";
                    txtParentezco.Text = "";
                    lblAgregarFamiliar.Text = "Familiar Agregado con exito";

                }
                else
                {
                    lblAgregarFamiliar.Text = "Error al cargar familiar";
                }
            }
            else { lblAgregarFamiliar.Text = "El DNI del paciente no es valido"; }
            
        }

        protected void lnkbtnCerrarSecion_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Server.Transfer("MenuInicio.aspx");
        }
        /* protected void BtnAgregar_Click(object sender, EventArgs e)
{
@NombreFamiliar_CF varchar(50),
@EdadFamiliar_CF varchar(50),
@OcupacionFaimiliar_CF varchar(50) ,
@ConviveFamiliar_CF bit,
@TelefonoFamiliar_CF varchar(50),
@ParentescoFamiliar_CF varchar(50)	


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

}
else
{
lblTratamientoAgregado.Text = "No se pudo agregar el tratamiento";
}
}*/
    }
}