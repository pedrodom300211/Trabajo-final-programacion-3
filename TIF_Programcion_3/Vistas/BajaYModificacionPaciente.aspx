<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaYModificacionPaciente.aspx.cs" Inherits="Vistas.BajaYModificacionPaciente" %>

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
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            width: 340px;
            height: 36px;
        }
        .auto-style5 {
            width: 100%;
            height: 22px;
            margin-bottom: 0px;
        }
        .auto-style6 {
            height: 36px;
        }
        .auto-style7 {
            width: 1381px;
        }
        .auto-style8 {
            height: 23px;
            width: 1381px;
        }
        .auto-style9 {
            width: 90px;
            height: 34px;
        }
        .auto-style10 {
            width: 1381px;
            height: 34px;
        }
        .auto-style11 {
            height: 34px;
        }
        .auto-style12 {
            width: 133px;
            height: 26px;
        }
        .auto-style14 {
            width: 19px;
            height: 26px;
        }
        .auto-style15 {
            width: 130px;
            height: 26px;
        }
        .auto-style16 {
            height: 26px;
            width: 284px;
        }
        .auto-style17 {
            width: 96px;
            height: 26px;
        }
        .auto-style19 {
            width: 64px;
            height: 26px;
        }
        .auto-style20 {
            height: 26px;
            width: 281px;
        }
        .auto-style21 {
            width: 142px;
            height: 26px;
        }
        .auto-style22 {
            width: 5px;
            height: 26px;
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
            <table class="auto-style1">
                <tr>
                    <td class="auto-style7"><span class="auto-style2">Bienvenido:</span>
                    <asp:Label ID="lblNombreAdmin" runat="server" CssClass="auto-style2"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style8">Baja y Modificacion de pacientes</td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style12">
                                    <asp:Label ID="lblBuscarPaciente" runat="server" Text="Buscar Paciente: DNI"></asp:Label>
                                </td>
                                <td class="auto-style21">
                        <asp:DropDownList ID="ddlSimbolo" runat="server" ValidationGroup="Buscar">
                            <asp:ListItem Value="--Seleccionar--">--Seleccionar--</asp:ListItem>
                            <asp:ListItem>=</asp:ListItem>
                            <asp:ListItem>&gt;</asp:ListItem>
                            <asp:ListItem>&gt;=</asp:ListItem>
                            <asp:ListItem>&lt;</asp:ListItem>
                            <asp:ListItem>&lt;=</asp:ListItem>
                        </asp:DropDownList>
                                </td>
                                <td class="auto-style14">a</td>
                                <td class="auto-style15">
                        <asp:TextBox ID="txtDNI" runat="server" ValidationGroup="Buscar" Width="100px" TextMode="Number"></asp:TextBox>
                                </td>
                                <td class="auto-style17">
                        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" ValidationGroup="Buscar" />
                                </td>
                                <td class="auto-style22">&nbsp;</td>
                                <td class="auto-style19">
                        <asp:Button ID="btnMostrarTodo" runat="server" OnClick="btnMostrarTodo_Click" Text="Mostrar Todos los Pacientes" />
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style12"></td>
                                <td class="auto-style21">
                        <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="ddlSimbolo" Operator="NotEqual" ValueToCompare="--Seleccionar--" ValidationGroup="Buscar">*Ingrese una condicion</asp:CompareValidator>
                                </td>
                                <td class="auto-style14"></td>
                                <td class="auto-style15">
                        <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ValidationGroup="Buscar">*Ingrese un DNI</asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style17"></td>
                                <td class="auto-style22"></td>
                                <td class="auto-style19"></td>
                                <td class="auto-style16"></td>
                                <td class="auto-style20"></td>
                            </tr>
                        </table>
                    </td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <div class="GridBajaYModificacion">
                        <asp:GridView ID="grdBajaModificacion" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowEditing="grdBajaModificacion_RowEditing" OnSelectedIndexChanged="grdBajaModificacion_SelectedIndexChanged" OnRowDeleting="grdBajaModificacion_RowDeleting" AllowPaging="True" OnPageIndexChanging="grdBajaModificacion_PageIndexChanging" PageSize="5">
                            <Columns>
                                <asp:TemplateField HeaderText="DNI">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDNI" runat="server" Text='<%# Bind("DNIPac_Pa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre Apellido">
                                    <ItemTemplate>
                                        <asp:Label ID="NombreApellido" runat="server" Text='<%# Bind("NombreApellido_PA") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edad">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEdad" runat="server" Text='<%# Bind("Edad_PA") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre Acompañante">
                                    <ItemTemplate>
                                        <asp:Label ID="NomAcompañante" runat="server" Text='<%# Bind("NomAcompaniante_Pa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parentezco">
                                    <ItemTemplate>
                                        <asp:Label ID="lblParentezco" runat="server" Text='<%# Bind("Parentezco_Pa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Entrevista">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFechaEntrevista" runat="server" Text='<%# Bind("FechaEntrevista_Pa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CUD">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCUD" runat="server" Text='<%# Bind("CUD_Pa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vencimiento CUD">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVencimientoCUD" runat="server" Text='<%# Bind("VencimientoCUD_Pa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motivo Consulta">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMotivoConsulta" runat="server" Text='<%# Bind("MotivoConsulta_Pa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Situacion Laboral">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSituacionLaboral" runat="server" Text='<%# Bind("Descripcion_SL") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acercamiento">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodAcercamiento" runat="server" Text='<%# Bind("Descripcion_A") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            <br />
                            <asp:Label ID="lblVacio" runat="server"></asp:Label>
                            </div>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
               <table class="auto-style5">
                   <tr>
                       <td class="auto-style4">
                           <asp:Label ID="lblMensaje" runat="server" Visible="False">¿Desea darde de baja al paciente </asp:Label>
                       </td>
                       <td class="auto-style6">
                           <table class="auto-style1">
                               <tr>
                                   <td class="auto-style9">
                           <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Continuar" Visible="False" Width="77px" />
                                   </td>
                                   <td class="auto-style11">
                           <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" Visible="False" Width="85px" />
                                       <asp:Label ID="lblDatoEliminacion" runat="server" Visible="False"></asp:Label>
                                   </td>
                               </tr>
                           </table>
                       </td>
                   </tr>
                   <tr>
                       <td class="auto-style4">
                           <asp:Label ID="lblMensaje2" runat="server"></asp:Label>
                       </td>
                       <td class="auto-style6">
                           <asp:Button ID="btnAceptar2" runat="server" OnClick="btnAceptar2_Click" Text="Aceptar" Visible="False" Width="80px" />
                       </td>
                   </tr>
               </table>
    </form>
</body>