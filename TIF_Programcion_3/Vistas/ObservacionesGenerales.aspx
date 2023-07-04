<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObservacionesGenerales.aspx.cs" Inherits="Vistas.ObservacionesGenerales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            font-size: xx-large;
        }
        .auto-style2 {
            height: 25px;
            font-size: xx-large;
        }
        .auto-style17 {
            height: 23px;
        }
        .auto-style19 {
            width: 138px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
                  <div class="BarraHerramientas">
             <asp:Label ID="lblUsuario" runat="server"></asp:Label>    
            <asp:HyperLink ID="hplnkMenuAdmin" runat="server"  NavigateUrl="~/MenuAdmin.aspx" Text="Menu Admin">Menu Admin</asp:HyperLink>
             <asp:HyperLink ID="hyplnkAltaPaciente" runat="server" NavigateUrl="~/AltaPaciente.aspx">Dar de alta Paciente</asp:HyperLink>
            <asp:HyperLink ID="hyplnkModificacion" runat="server"  NavigateUrl="~/BajaYModificacionPaciente.aspx" >Modificar/Dar de baja Paciente/Ver Datos Paciente</asp:HyperLink>
            <asp:HyperLink ID="hyplnkObsGenerales" runat="server" NavigateUrl="~/ObservacionesGenerales.aspx">Agregar Observaciones Generales</asp:HyperLink>
            <asp:HyperLink ID="hyplnkTratamiento" runat="server" NavigateUrl="~/Tratamiento.aspx">Agregar Tratamiento</asp:HyperLink>
                        <asp:HyperLink ID="hyplnkAgregarFamiliar" runat="server" NavigateUrl="~/AgregarFamiliar.aspx">Agregar Familiar</asp:HyperLink>
            <asp:LinkButton ID="lnkbtnCerrarSecion" runat="server" Text="Cerrar sesion" OnClick="lnkbtnCerrarSecion_Click">Cerrar sesion</asp:LinkButton>
        </div>
        <div>
            <span class="auto-style3">Bienvenido: </span>
                    <asp:Label ID="lblNombreAdmin" runat="server" CssClass="auto-style2"></asp:Label>
                        <span class="auto-style3">&nbsp;a Observaciones generales</span></div>
        <div class="FormObsGenerales">
       
            <table class="auto-style1">
                <tr>
                    <td class="auto-style19">DNI Paciente:</td>
                    <td>
                        <asp:TextBox ID="txtDniPacienteOG" runat="server" Width="191px" TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDNIPaciente" runat="server" ControlToValidate="txtDniPacienteOG" ErrorMessage="DNI vacio" ValidationGroup="OG"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style19">Descripcion Observacion:</td>
                    <td>
                        <asp:TextBox ID="txtDescripcionOG" runat="server" Width="190px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcionOG" ErrorMessage="Descripcion vacia" ValidationGroup="OG"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style19">Codigo de Area:</td>
                    <td>
                        <asp:DropDownList ID="ddlCodigoArea" runat="server" DataTextField="Descripcion_A" DataValueField="CodArea_A" ValidationGroup="ObsGeneral">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style17" colspan="2">
                        <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" ValidationGroup="OG" />
                    </td>
                    <td class="auto-style17"></td>
                    <td class="auto-style17"></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblAgregarObsGeneral" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                
            </table>
            </div>
       
    </form>
</body>
</html>
