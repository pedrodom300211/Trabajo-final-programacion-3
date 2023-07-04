<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tratamiento.aspx.cs" Inherits="Vistas.Tratamiento" %>

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
        .auto-style2 {
            font-size: xx-large;
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
        <p>
        <span class="auto-style2">Bienvenido:</span><asp:Label ID="lblAdmin" runat="server" CssClass="auto-style2"></asp:Label><span class="auto-style2"> a Tratamientos</span>
        </p>
            <div class="FormTratamiento">
            <table class="auto-style1">
                <tr>
                    <td>
                        <br />
                        Ingrese DNI del paciente:<asp:TextBox ID="txtDNIPaciente" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqfvDNI" runat="server" ControlToValidate="txtDNIPaciente" ValidationGroup="tratamientos">Ingrese un DNI</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Ingrese la droga utilizada:<asp:TextBox ID="txtDroga" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDroga" runat="server" ControlToValidate="txtDroga" ValidationGroup="tratamientos">Ingrese una droga</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Ingrese la marca de la droga:<asp:TextBox ID="txtMarcaDroga" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqfvMarcaDroga" runat="server" ControlToValidate="txtMarcaDroga" ValidationGroup="tratamientos">Ingrese la marca de la droga</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Psicoterapia:<asp:CheckBox ID="chbxPsicoterapiaSI" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Rehabilitacion:<asp:CheckBox ID="chkbxRehabilitacionSI" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>TO:<asp:CheckBox ID="chkbxTOSI" runat="server" OnCheckedChanged="chkbxTOSI_CheckedChanged" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Otras:<asp:CheckBox ID="chkbxOtrasSI" runat="server" />
                        <br />
                        <asp:Label ID="lblDNIIncorrecto" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" ValidationGroup="tratamientos" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
    <asp:Label style="margin-left:750px" ID="lblTratamientoAgregado" runat="server"></asp:Label>
</body>
</html>
