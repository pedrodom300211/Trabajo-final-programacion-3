<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarDatosPacientes.aspx.cs" Inherits="Vistas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">

        .auto-style78 {
            display: inline-block;
            background-color: #FD512C;
            border: 2px solid black;
            margin-left: 0px;
            margin-top: 59px;
            width: 100%;
            margin-right: 0px;
        }
        .auto-style1 {
            width: 100%;
            margin-bottom: 0px;
            height: 53px;
        }
        .auto-style88 {
            width: 259px;
            height: 23px;
        }
        .auto-style96 {
            width: 224%;
        }
        .auto-style97 {
            width: 223%;
            height: 22px;
        }
        .auto-style98 {
            width: 223%;
        }
        .auto-style99 {
            height: 42px;
        }
        .auto-style100 {
            width: 224%;
            margin-right: 0px;
        }
        .auto-style101 {
            width: 716px;
        }
        .auto-style102 {
            height: 177px;
        }
    </style>
</head>
<body style="margin-bottom: 0">
    <form id="form1" runat="server">
                 <div class="BarraHerramientas">
             <asp:Label ID="lblUsuario" runat="server"></asp:Label>    
            <asp:HyperLink ID="hplnkMenuAdmin" runat="server"  NavigateUrl="~/MenuAdmin.aspx" Text="Menu Admin">Menu Admin</asp:HyperLink>
             <asp:HyperLink ID="hyplnkAltaPaciente" runat="server" NavigateUrl="~/AltaPaciente.aspx">Dar de alta Paciente</asp:HyperLink>
            <asp:HyperLink ID="hyplnkModificacion" runat="server"  NavigateUrl="~/BajaYModificacionPaciente.aspx" >Modificar/Dar de baja Paciente</asp:HyperLink>
            <asp:HyperLink ID="hyplnkObsGenerales" runat="server" NavigateUrl="~/ObservacionesGenerales.aspx">Agregar Observaciones Generales</asp:HyperLink>
            <asp:HyperLink ID="hyplnkTratamiento" runat="server" NavigateUrl="~/Tratamiento.aspx">Agregar Tratamiento</asp:HyperLink>
                        <asp:HyperLink ID="hyplnkAgregarFamiliar" runat="server" NavigateUrl="~/AgregarFamiliar.aspx">Agregar Familiar</asp:HyperLink>
            <asp:LinkButton ID="lnkbtnCerrarSecion" runat="server" Text="Cerrar sesion" OnClick="lnkbtnCerrarSecion_Click">Cerrar sesion</asp:LinkButton>
        </div>
        <div class="auto-style78">

       
        <div >
            <table class="auto-style1">
                <tr>
                    <td class="auto-style88">
                        <asp:Label ID="lblPaciente" runat="server" Text="DNI Paciente:"></asp:Label>
                        <asp:Label ID="lblNombrePaciente" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style88">
                        <br />
                        <table class="auto-style97">
                            <tr>
                                <td>&nbsp;<asp:Label ID="lblObservacionesGeneralesText" runat="server" Text="Observaciones Generales:"></asp:Label>
                                    <br />
                                    <asp:GridView ID="grdObservacionesGenerales" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="GridView4_RowCancelingEdit" OnRowEditing="GridView4_RowEditing" OnRowUpdating="GridView4_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Numero Observacion">
                                                <EditItemTemplate>
                                                    <asp:Label ID="labelEditingNum" runat="server" Text='<%# Bind("NumObser_OG") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNumOG" runat="server" Text='<%# bind("NumObser_OG") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DNI">
                                                <EditItemTemplate>
                                                    <asp:Label ID="labelDniEditing" runat="server" Text='<%# Bind("DNIPac_OG") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDNI" runat="server" Text='<%# Bind("DNIPac_OG") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descripcion">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Bind("Descripcion_OG") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("Descripcion_OG") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Area">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlAreas" runat="server" AutoPostBack="True">
                                                        <asp:ListItem Value="CodArea1">Area Legal</asp:ListItem>
                                                        <asp:ListItem Value="CodArea2">Area Social</asp:ListItem>
                                                        <asp:ListItem Value="CodArea3">Area de Salud Mental</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblArea" runat="server" Text='<%# Bind("Descripcion_A") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="lblErrorOG" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="auto-style98">
                            <tr>
                                <td class="auto-style101">
                                    <asp:Label ID="lblTratamientosText" runat="server" Text="Tratamientos:"></asp:Label>
                                    <br />
                                    <asp:GridView ID="grdTratamientos" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="GridView5_RowCancelingEdit" OnRowEditing="GridView5_RowEditing" OnRowUpdating="GridView5_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText="NumTram">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblNumTramEditing" runat="server" Text='<%# Bind("NumTram_Tr") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNumeroTratamiento" runat="server" Text='<%# Bind("NumTram_Tr") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dni Paciente">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblDniEditing" runat="server" Text='<%# Bind("DNIPac_Tr") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDniPaciente" runat="server" Text='<%# Bind("DNIPac_Tr") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Droga">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtDrogaEditing" runat="server" Text='<%# Bind("Droga_Tr") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDroga" runat="server" Text='<%# Bind("Droga_Tr") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Marca">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtMarcaEditing" runat="server" Text='<%# Bind("Marca_Tr") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMarca" runat="server" Text='<%# Bind("Marca_Tr") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Psicoterapia">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chPsicoterapia" runat="server" Checked='<%# Bind("Psicoterapia_Tr") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPsicoterapia" runat="server" Text='<%# Bind("Psicoterapia_Tr") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rehabilitacion">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chBoxRehabilitacion" runat="server" Checked='<%# Bind("Rehabilitacion_Tr") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRehabilitacion" runat="server" Text='<%# Bind("Rehabilitacion_Tr") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TO">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chBoxTO" runat="server" Checked='<%# Bind("TO_Tr") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTO" runat="server" Text='<%# Bind("TO_Tr") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Otras">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chBoxOtrasEditing" runat="server" Checked='<%# Bind("Otras_Tr") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOtras" runat="server" Text='<%# Bind("Otras_Tr") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="lblErrorTratamientos" runat="server"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="auto-style96">
                            <tr>
                                <td class="auto-style102">
                                    <asp:Label ID="lblComposicionFamiliarText" runat="server" Text="Composición Familiar:"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:GridView ID="grdComposicionFamiliar" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="GridView6_RowCancelingEdit" OnRowEditing="GridView6_RowEditing" OnRowUpdating="GridView6_RowUpdating" OnSelectedIndexChanged="GridView6_SelectedIndexChanged">
                                        <Columns>
                                            <asp:TemplateField HeaderText="DNIFam">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblDNIFamEditing" runat="server" Text='<%# Bind("DNIFam_CF") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDNIFam" runat="server" Text='<%# Bind("DNIFam_CF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DNIPac">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblDNIPacEditing" runat="server" Text='<%# Bind("DNIPac_CF") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDNIPac" runat="server" Text='<%# Bind("DNIPac_CF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre Familia">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNombreEditing" runat="server" Text='<%# Bind("NombreFamiliar_CF") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombreFamiliar" runat="server" Text='<%# Bind("NombreFamiliar_CF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edad Familiar">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEdadEditing" runat="server" Text='<%# Bind("EdadFamiliar_CF") %>' TextMode="Number"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEdadFamiliar" runat="server" Text='<%# Bind("EdadFamiliar_CF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ocupacion">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtOcupacionEditing" runat="server" Text='<%# Bind("OcupacionFamiliar_CF") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOcupacionFamiliar" runat="server" Text='<%# Bind("OcupacionFamiliar_CF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Convive ">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chBoxConviveEditing" runat="server" Checked='<%# Bind("ConviveFamiliar_CF") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chBoxConviveFamiliar" runat="server" Checked='<%# Bind("ConviveFamiliar_CF") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Telefono">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTelefonoEditing" runat="server" Text='<%# Bind("TelefonoFamiliar_CF") %>' TextMode="Number"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTelofono" runat="server" Text='<%# Bind("TelefonoFamiliar_CF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Parentesco">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtParentesco" runat="server" Text='<%# Bind("ParentescoFamiliar_CF") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParentesco" runat="server" Text='<%# Bind("ParentescoFamiliar_CF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="lblErrorFamiliar" runat="server"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table class="auto-style100">
                            <tr>
                                <td class="auto-style99">
                                    <asp:Label ID="lblPacientes" runat="server" Text="Paciente:"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:GridView ID="grdPaciente" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="GridView7_RowCancelingEdit" OnRowEditing="GridView7_RowEditing" OnRowUpdating="GridView7_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText="DNI">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Bind("DNIPac_Pa") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDNIPac" runat="server" Text='<%# Bind("DNIPac_Pa") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="NombreApellido">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_it_NombreApellido" runat="server" Text='<%# Bind("NombreApellido_PA") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombreApellido" runat="server" Text='<%# Bind("NombreApellido_PA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edad">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_it_Edad" runat="server" Text='<%# Bind("Edad_PA") %>' TextMode="Number"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEdad" runat="server" Text='<%# Bind("Edad_PA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="NomAcompaniante">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_it_NomAcompaniante" runat="server" Text='<%# Bind("NomAcompaniante_Pa") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombreAcompaniante" runat="server" Text='<%# Bind("NomAcompaniante_Pa") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Parentezco">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_it_Parentezco" runat="server" Text='<%# Bind("Parentezco_Pa") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParentezco" runat="server" Text='<%# Bind("Parentezco_Pa") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha Entrevista">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_it_FechaEntrevista" runat="server" Text='<%# Bind("FechaEntrevista_Pa") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaEntrevista" runat="server" Text='<%# Bind("FechaEntrevista_Pa") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CUD">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chBox_it_CUD" runat="server" Checked='<%# Bind("CUD_Pa") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chBoxCUD" runat="server" Checked='<%# Bind("CUD_Pa") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha Vencimiento">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_it_FechaVencimiento" runat="server" Text='<%# Bind("VencimientoCUD_Pa") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVencimiento" runat="server" Text='<%# Bind("VencimientoCUD_Pa") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Motivo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_it_MotivoConsulta" runat="server" Text='<%# Bind("MotivoConsulta_Pa") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMotivoConsulta" runat="server" Text='<%# Bind("MotivoConsulta_Pa") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Codigo Situacion Laboral">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlSituacionLaboral" runat="server" AutoPostBack="True">
                                                        <asp:ListItem Value="CodSL1">En relación de dependencia</asp:ListItem>
                                                        <asp:ListItem Value="CodSL2">Independiente / Autónomo </asp:ListItem>
                                                        <asp:ListItem Value="CodSL3">Sin trabajo </asp:ListItem>
                                                        <asp:ListItem Value="CodSL4">A cargo de Familiar</asp:ListItem>
                                                        <asp:ListItem Value="CodSL5">Pensionado</asp:ListItem>
                                                        <asp:ListItem Value="CodSL6">Iubilado</asp:ListItem>
                                                        <asp:ListItem Value="CodSL7">Monotributista</asp:ListItem>
                                                        <asp:ListItem Value="CodSL8">otro</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodSit" runat="server" Text='<%# Bind("Descripcion_SL") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Codigo acercamiento">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlAcercamiento" runat="server" AutoPostBack="True">
                                                        <asp:ListItem Value="CodAcer1">Instagram/Facebook Página web</asp:ListItem>
                                                        <asp:ListItem Value="CodAcer2">Revista</asp:ListItem>
                                                        <asp:ListItem Value="CodAcer3">0tros</asp:ListItem>
                                                        <asp:ListItem Value="CodAcer4">Médico</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodigoAcercamiento" runat="server" Text='<%# Bind("Descripcion_A") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="lblErrorPaciente" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TIF_PROG3ConnectionString2 %>" SelectCommand="SELECT * FROM [ObservacionesGenerales]"></asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TIF_PROG3ConnectionString2 %>" SelectCommand="SELECT * FROM [Tratamiento]"></asp:SqlDataSource>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </table>
        </div>
             </div>
    </form>
</body>
</html>
