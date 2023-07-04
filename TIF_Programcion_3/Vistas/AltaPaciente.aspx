<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Vistas.AltaPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin-bottom: 0px;
        }
        .auto-style2 {
            height: 25px;
        }
        .auto-style13 {
            font-size: xx-large;
        }
        .auto-style26 {
            height: 23px;
        }
        .auto-style37 {
            width: 100%;
        }
        .auto-style38 {
            width: 203px;
        }
        .auto-style74 {
            width: 145px;
        }
        .auto-style76 {
            width: 100%;
            height: 35px;
        }
        .auto-style77 {
            width: 86px;
        }
        .auto-style78 {
            display: inline-block;
            background-color: #FD512C;
            border: 2px solid black;
            margin-left: 189px;
            margin-top: 59px;
            width: 586px;
        }
        .auto-style81 {
            width: 149px;
            height: 26px;
        }
        .auto-style82 {
            width: 149px;
            height: 23px;
        }
        .auto-style83 {
            width: 149px;
        }
        .auto-style84 {
            height: 25px;
            width: 149px;
        }
        .auto-style85 {
            width: 149px;
            height: 24px;
        }
        .auto-style87 {
            width: 251px;
            height: 26px;
        }
        .auto-style88 {
            width: 251px;
            height: 23px;
        }
        .auto-style90 {
            height: 25px;
            width: 251px;
        }
        .auto-style91 {
            width: 251px;
            height: 24px;
        }
        .auto-style92 {
            width: 251px;
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
        <div class="auto-style78">

       
        <div >
            <table class="auto-style1">
                <tr>
                    <td colspan="2">
                        <span class="auto-style13">Bienvenido:<asp:Label ID="lblNombreAdmin" runat="server" CssClass="auto-style2"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style88"><strong>ALTA DE PACIENTE:</strong></td>
                    <td class="auto-style82"></td>
                </tr>
                <tr>
                    <td class="auto-style92">&nbsp;</td>
                    <td class="auto-style83">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style87">
                        <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" Text="- DNI del paciente: "></asp:Label>
                    </td>
                    <td class="auto-style81">
                        <asp:TextBox ID="txtDNI" runat="server" Width="220px" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" Display="Dynamic" ValidationGroup="Alta">Ingrese un DNI</asp:RequiredFieldValidator>
                    &nbsp;<asp:RangeValidator ID="rvDNI" runat="server" ControlToValidate="txtDNI" MaximumValue="99999999" MinimumValue="900000" Type="Integer" ValidationGroup="Alta" Display="Dynamic">*Ingrese un DNI valido/El DNI ya existe en el sistema</asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style90">
                        <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="Black" Text="- Nombre y apellido del paciente:"></asp:Label>
                    </td>
                    <td class="auto-style84">
                        <asp:TextBox ID="txtNombre" runat="server" Width="220px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqfNombre" runat="server" ControlToValidate="txtNombre" ValidationGroup="Alta">*Ingrese un nombre valido</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style90">
                        -EDAD</td>
                    <td class="auto-style84">
                        <asp:TextBox ID="txtEdad" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:RangeValidator ID="rvEdad" runat="server" ControlToValidate="txtEdad" MaximumValue="120" MinimumValue="1" Type="Integer" ValidationGroup="Alta" Display="Dynamic">*Ingrese una edad valida</asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="rfvEDAD" runat="server" ControlToValidate="txtEdad" Display="Dynamic" ValidationGroup="Alta">Ingrese una Edad</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style90">
                        <asp:Label ID="Label3" runat="server" Font-Size="Large" ForeColor="Black" Text="- Nombre Acompañante:"></asp:Label>
                    </td>
                    <td class="auto-style84">
                        <asp:TextBox ID="txtNombreAcompaniante" runat="server" Width="220px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqfNombreAcompañante" runat="server" ControlToValidate="txtNombreAcompaniante" ValidationGroup="Alta">*Ingrese un Nombre de acompañante Valido</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style87">
                        <asp:Label ID="Label5" runat="server" Font-Size="Large" ForeColor="Black" Text="- Parentezco:"></asp:Label>
                    </td>
                    <td class="auto-style81">
                        <asp:TextBox ID="txtParentezco" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtParentezco" ValidationGroup="Alta">*Ingrese un Parentezco correcto</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style91">
                        <asp:Label ID="Label6" runat="server" Font-Size="Large" ForeColor="Black" Text="- Fecha de entrevista:"></asp:Label>
                    </td>
                    <td class="auto-style85">
                        <asp:TextBox ID="txtFechaEntrevista" runat="server" Width="220px" TextMode="DateTimeLocal"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaEntrevista" ValidationGroup="Alta">*Ingrese una fecha valida</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style92">
                        <asp:Label ID="Label7" runat="server" Font-Size="Large" ForeColor="Black" Text="- CUD:"></asp:Label>
                    </td>
                    <td class="auto-style83">
                        <asp:CheckBox ID="chkbxCUD" runat="server" Text="Certificado Unico de Discapacidad" AutoPostBack="True" OnCheckedChanged="chkbxCUD_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style92">
                        <asp:Label ID="Label8" runat="server" Font-Size="Large" ForeColor="Black" Text="- Vencimiento del CUD:"></asp:Label>
                    </td>
                    <td class="auto-style83">
                        <asp:TextBox ID="txtVencimientoCUD" runat="server" Width="220px" Enabled="False" TextMode="DateTimeLocal"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style87">
                        <asp:Label ID="Label9" runat="server" Font-Size="Large" ForeColor="Black" Text="- Situacion laboral del paciente:"></asp:Label>
                    </td>
                    <td class="auto-style81">
                        <asp:DropDownList ID="ddlSituacionLaboral" runat="server" Height="22px" Width="190px">
                            <asp:ListItem>-- Seleccionar --</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style87">
                        <asp:Label ID="Label10" runat="server" Font-Size="Large" ForeColor="Black" Text="- Acercamiento:"></asp:Label>
                    </td>
                    <td class="auto-style81">
                        <asp:DropDownList ID="ddlAcercamiento" runat="server" Height="22px" Width="190px"  DataTextField="Descripcion_A" DataValueField="CodAcerc_A">
                            <asp:ListItem>-- Seleccionar --</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                </table>
        </div>
        <table class="auto-style37">
            <tr>
                <td class="auto-style26">
                    <table class="auto-style76">
                        <tr>
                            <td class="auto-style38">
                                <asp:Label ID="Label11" runat="server" Font-Size="Large" ForeColor="Black" Text="- Motivo de la consulta:"></asp:Label>
                            </td>
                            <td class="auto-style77">&nbsp;</td>
                            <td class="auto-style74">
                                <asp:TextBox ID="txtMotivoConsulta" runat="server" Height="45px" TextMode="MultiLine" Width="220px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMotivoConsulta" ValidationGroup="Alta">*Ingrese una descripcion</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                -Contraseña:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtContraseña1" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqfvContraseña1" runat="server" ControlToValidate="txtContraseña1" ValidationGroup="Alta">*Ingrese una contraseña</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                -Confirme la contraseña:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtContraseña2" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqfvContraseña2" runat="server" ControlToValidate="txtContraseña2" ValidationGroup="Alta">*Confirme la contraseña</asp:RequiredFieldValidator>
                                <br />
                                <asp:Label ID="lblContraseñasIguales" runat="server" Text="*Las contraseñas no son iguales" Visible="False"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style87">
                        <asp:Button ID="btnDarAlta" runat="server" Text="Dar de alta paciente" OnClick="btnDarAlta_Click" ValidationGroup="Alta"/>
                    </td>
                    <td class="auto-style81">
                        &nbsp;</td>
                </tr>
                </table>
            <asp:Label ID="lblPacienteAgregado" runat="server"></asp:Label>
        <br />
             </div>
    <p>
        &nbsp;</p>
                 <br />
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
