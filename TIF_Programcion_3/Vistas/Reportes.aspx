<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Vistas.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 23px;

        }
        .auto-style2 {
            height: 22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
            
                <div class="navbar-paciente">
            <div>Bienvenido: <asp:Label ID="lblUsuarioNavBar" runat="server" CssClass="auto-style1"></asp:Label></div>
            <asp:HyperLink ID="hplkbtnMenuUsuario" runat="server" NavigateUrl="~/MenuBienvenida.aspx">Menu Usuario</asp:HyperLink>
             <asp:HyperLink ID="hyplnkbtnVerMisDatos" runat="server" NavigateUrl="~/DatosPacienteID.aspx">Ver mis Datos</asp:HyperLink>
            <asp:HyperLink ID="hyplnkbtnReportes" runat="server" NavigateUrl="~/Reportes.aspx">Reportes</asp:HyperLink>
            <div>Salir: <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtnCerrarSesionPaciente_Click">Cerrar Sesion</asp:LinkButton></div>
        
        </div>
        <table class="FormReportes">
             <tr>   
               
                
            </tr>
            <tr>
                
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    <h2>Bienvenido: <asp:Label ID="lblUsuario" runat="server" CssClass="auto-style1"></asp:Label>
                    </h2>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Seleccione el area a buscar:
                    <asp:DropDownList ID="ddlAreas" runat="server">
                        <asp:ListItem Value="Area Legal">Area Legal</asp:ListItem>
                        <asp:ListItem Value="Area Social">Area Social</asp:ListItem>
                        <asp:ListItem Value="Area Salud Mental">Area Salud Mental</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
            <asp:GridView ID="grdObsGenerales" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Numero De Observacion">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_NumObs" runat="server" Text='<%# Bind("NumObser_OG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI Paciente">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_DNI" runat="server" Text='<%# Bind("DNIPac_OG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion ">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_DESC" runat="server" Text='<%# Bind("Descripcion_OG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_AREA" runat="server" Text='<%# Bind("Descripcion_A") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                    <br />
                    <asp:Label ID="lblVacio" runat="server"></asp:Label>
                    <br />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Seleccione la droga a buscar:
                    <asp:TextBox ID="txtDroga" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscarDroga" runat="server" OnClick="btnBuscarDroga_Click" Text="Buscar" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
            <asp:GridView ID="grdvTratamientos" runat="server" AutoGenerateColumns="False" DataKeyNames="NumTram_Tr,DNIPac_Tr">
                <Columns>
                    <asp:BoundField DataField="NumTram_Tr" HeaderText="NumTram_Tr" InsertVisible="False" ReadOnly="True" SortExpression="NumTram_Tr" />
                    <asp:BoundField DataField="DNIPac_Tr" HeaderText="DNIPac_Tr" ReadOnly="True" SortExpression="DNIPac_Tr" />
                    <asp:BoundField DataField="Droga_Tr" HeaderText="Droga_Tr" SortExpression="Droga_Tr" />
                    <asp:BoundField DataField="Marca_Tr" HeaderText="Marca_Tr" SortExpression="Marca_Tr" />
                    <asp:CheckBoxField DataField="Psicoterapia_Tr" HeaderText="Psicoterapia_Tr" SortExpression="Psicoterapia_Tr" />
                    <asp:CheckBoxField DataField="Rehabilitacion_Tr" HeaderText="Rehabilitacion_Tr" SortExpression="Rehabilitacion_Tr" />
                    <asp:CheckBoxField DataField="TO_Tr" HeaderText="TO_Tr" SortExpression="TO_Tr" />
                    <asp:CheckBoxField DataField="Otras_Tr" HeaderText="Otras_Tr" SortExpression="Otras_Tr" />
                </Columns>
            </asp:GridView>
                    
                    <br/>
                    <asp:Label ID="lblVacioDroga" runat="server"></asp:Label>
                </td>
                </tr>
               
                
        </table>
       
        <div>
        </div>
        
    </form>
</body>
</html>
