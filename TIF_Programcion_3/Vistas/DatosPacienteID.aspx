<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatosPacienteID.aspx.cs" Inherits="Vistas.DatosPacienteID" %>

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
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar-paciente">
            <div>Bienvenido: <asp:Label ID="lblUsuario" runat="server" CssClass="auto-style1"></asp:Label></div>
            <asp:HyperLink ID="hplkbtnMenuUsuario" runat="server" NavigateUrl="~/MenuBienvenida.aspx">Menu Usuario</asp:HyperLink>
             <asp:HyperLink ID="hyplnkbtnVerMisDatos" runat="server" NavigateUrl="~/DatosPacienteID.aspx">Ver mis Datos</asp:HyperLink>
            &nbsp;<asp:HyperLink ID="hyplnkbtnReportes" runat="server" NavigateUrl="~/Reportes.aspx">Reportes</asp:HyperLink>
            <div>Salir: <asp:LinkButton ID="lbtnCerrarSesionPaciente" runat="server" OnClick="lbtnCerrarSesionPaciente_Click">Cerrar Sesion</asp:LinkButton></div>
        </div>
        <div class="navbar-paciente-panelIzquerdoMin"><h1></h1></div>
        <div class="navbar-paciente-panelCentralTabla"><h1>Paciente</h1></div>        
        <div class="navbar-paciente-panelIzquerdoMax"></div>
        <div class="navbar-paciente-panelCentralDatos">
            <asp:GridView class="GridViewDatosPacienteID" ID="grdPaciente" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="DNI">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_DNI" runat="server" Text='<%# Bind("DNIPac_Pa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Nombre" runat="server" Text='<%# Bind("NombreApellido_PA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edad">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Edad" runat="server" Text='<%# Bind("Edad_PA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre Acompañante">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_NombreAcompañante" runat="server" Text='<%# Bind("NomAcompaniante_Pa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Parentezco">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Parentezco" runat="server" Text='<%# Bind("Parentezco_Pa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de la Entrevista">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_FechaEntrevista" runat="server" Text='<%# Bind("FechaEntrevista_Pa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CUD">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_CUD" runat="server" Text='<%# Bind("CUD_Pa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vencimiento del CUD">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_VencimientoCUD" runat="server" Text='<%# Bind("VencimientoCUD_Pa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Motivo de la consulta">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Motivo" runat="server" Text='<%# Bind("MotivoConsulta_Pa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Situacion Laboral">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_SL" runat="server" Text='<%# Bind("Descripcion_SL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acercamiento">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Acercamiento" runat="server" Text='<%# Bind("Descripcion_A") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="navbar-paciente-panelIzquerdoMin"><h1></h1></div>
        <div class="navbar-paciente-panelCentralTabla"><h1>Observaciones Generales</h1></div>        
        <div class="navbar-paciente-panelIzquerdoMax"></div>
        <div class="navbar-paciente-panelCentralDatos">
            <asp:GridView class="GridViewDatosPacienteID" ID="grdObsGeneral" runat="server" AutoGenerateColumns="False">
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
        </div>
        <div class="navbar-paciente-panelIzquerdoMin"><h1></h1></div>
        <div class="navbar-paciente-panelCentralTabla"><h1>Tratamiento</h1></div>        
        <div class="navbar-paciente-panelIzquerdoMax"></div>
        <div class="navbar-paciente-panelCentralDatos">
            <asp:GridView class="GridViewDatosPacienteID" ID="grdvTratamiento" runat="server" AutoGenerateColumns="False" DataKeyNames="NumTram_Tr,DNIPac_Tr">
                <Columns>
                    <asp:TemplateField HeaderText="Numero de tratamiento">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_NumTram_Tr" runat="server" Text='<%# Eval("NumTram_Tr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI Paciente">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_DNIPaciente" runat="server" Text='<%# Eval("DNIPac_Tr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Droga">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Droga" runat="server" Text='<%# Eval("Droga_Tr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Marca">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Marca" runat="server" Text='<%# Eval("Marca_Tr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Psicoterapia">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Psicoterapia" runat="server" Text='<%# Eval("Psicoterapia_Tr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rehabilitacion">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Rehabilitacion" runat="server" Text='<%# Eval("Rehabilitacion_Tr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TO">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_TO" runat="server" Text='<%# Eval("TO_Tr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Otras">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_Otras" runat="server" Text='<%# Eval("Otras_Tr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="navbar-paciente-panelIzquerdoMin"><h1></h1></div>
        <div class="navbar-paciente-panelCentralTabla"><h1>Composicion Familiar</h1></div>        
        <div class="navbar-paciente-panelIzquerdoMax"></div>
        <div class="navbar-paciente-panelCentralDatos">
            <asp:GridView class="GridViewDatosPacienteID" ID="grdvComposicionFamiliar" runat="server" AutoGenerateColumns="False" DataKeyNames="DNIFam_CF,DNIPac_CF">
                <Columns>
                    <asp:TemplateField HeaderText="DNI Familiar">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_DNIFamiliar" runat="server" Text='<%# Eval("DNIFam_CF") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI Paciente">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_DNIPaciente" runat="server" Text='<%# Eval("DNIPac_CF") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre Familiar">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_NombreFamiliar" runat="server" Text='<%# Eval("NombreFamiliar_CF") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edad Familiar">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_EdadFamiliar" runat="server" Text='<%# Eval("EdadFamiliar_CF") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ocupacion Familiar">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_OcupacionFamiliar" runat="server" Text='<%# Eval("OcupacionFamiliar_CF") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Convive con Familiar">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_ConviveFamiliar" runat="server" Text='<%# Eval("ConviveFamiliar_CF") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefono Familiar">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_TelefonoFamiliar" runat="server" Text='<%# Eval("TelefonoFamiliar_CF") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Parentesco">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IT_ParentescoFamiliar" runat="server" Text='<%# Eval("ParentescoFamiliar_CF") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
