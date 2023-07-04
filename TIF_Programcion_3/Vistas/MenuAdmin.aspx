<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="Vistas.MenuAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Style.css" rel="stylesheet" />
    </head>
<body >
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
       
        <p>
            Bienvenido:
            <asp:Label ID="lblUsuario2" runat="server"></asp:Label>
            Al menu Principal
        </p>
       
    </form>
</body>
</html>
