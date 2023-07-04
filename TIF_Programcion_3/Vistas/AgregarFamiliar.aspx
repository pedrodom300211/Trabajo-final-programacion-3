<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarFamiliar.aspx.cs" Inherits="Vistas.AgregarFamiliar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 299px;
        }
        .auto-style4 {
            width: 299px;
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            width: 299px;
            height: 84px;
        }
        .auto-style7 {
            height: 84px;
        }
    </style>
</head>
<body>
            
    <form id="form1" runat="server" >
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
        <div class="FormAgregarFamilia">
            <div class="auto-style1">
                Agregar Familiar
            
               <table class="auto-style2">
                <tr>
                    <td class="auto-style6">Dni Familiar:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtDniFamiliar" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:RequiredFieldValidator ID="rfvDNIFamiliar" runat="server" ControlToValidate="txtDniFamiliar" ErrorMessage="DNI vacio" ValidationGroup="Familia"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revDNIFamiliar" runat="server" ControlToValidate="txtDniFamiliar" ErrorMessage="Ingrese numeros" ValidationExpression="^[0-9]+$" ValidationGroup="Familia"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Dni Paciente:</td>
                    <td>
                        <asp:TextBox ID="txtDNIPaciente" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDNIPaciente" runat="server" ControlToValidate="txtDNIPaciente" ErrorMessage="DNI vacio" ValidationGroup="Familia"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revDNIPaciente" runat="server" ControlToValidate="txtDNIPaciente" ErrorMessage="Ingrese numeros" ValidationExpression="^[0-9]+$" ValidationGroup="Familia"></asp:RegularExpressionValidator>
                        <br />
                        <asp:CompareValidator ID="cvDNIs" runat="server" ControlToCompare="txtDniFamiliar" ControlToValidate="txtDNIPaciente" ErrorMessage="Los DNI tienen que ser diferentes" Operator="NotEqual" ValidationGroup="Familia"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Nombre Familiar:</td>
                    <td>
                        <asp:TextBox ID="txtNombreFamiliar" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNombreFamiliar" runat="server" ControlToValidate="txtNombreFamiliar" ErrorMessage="Nombre vacio" ValidationGroup="Familia"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Edad Familiar:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtEdadFamiliar" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="rfvEdadFamiliar" runat="server" ControlToValidate="txtEdadFamiliar" ErrorMessage="Edad vacia" ValidationGroup="Familia"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revEdad" runat="server" ControlToValidate="txtEdadFamiliar" ErrorMessage="Ingrese numeros" ValidationExpression="^[0-9]+$" ValidationGroup="Familia"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Ocupacion Familiar:</td>
                    <td>
                        <asp:TextBox ID="txtOcupacionFamiliar" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvOcupacionFamiliar" runat="server" ControlToValidate="txtOcupacionFamiliar" ErrorMessage="Ocupacion  vacia" ValidationGroup="Familia"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Convive Familiar:</td>
                    <td>
                        <asp:CheckBox ID="chkbxConviveSI" runat="server" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Telefono Familiar:</td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTelefonoFamiliar" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Telefono vacio" ValidationGroup="Familia"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Parentezco:</td>
                    <td>
                        <asp:TextBox ID="txtParentezco" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvParentezco" runat="server" ControlToValidate="txtParentezco" ErrorMessage="Parentezco  vacio" ValidationGroup="Familia"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" ValidationGroup="Familia" />
                <br />
                <asp:Label ID="lblAgregarFamiliar" runat="server"></asp:Label>
        </div>
       
    </form>
</body>
</html>
