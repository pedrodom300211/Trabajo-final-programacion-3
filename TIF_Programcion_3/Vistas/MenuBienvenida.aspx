<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuBienvenida.aspx.cs" Inherits="Vistas.MenuBienvenida" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="navbar-paciente">
            <div>Bienvenido: <asp:Label ID="lblUsuario" runat="server" CssClass="auto-style1"></asp:Label></div>
            <asp:HyperLink ID="hplkbtnMenuUsuario" runat="server" NavigateUrl="~/MenuBienvenida.aspx">Menu Usuario</asp:HyperLink>
             <asp:HyperLink ID="hyplnkbtnVerMisDatos" runat="server" NavigateUrl="~/DatosPacienteID.aspx">Ver mis Datos</asp:HyperLink>
            <asp:HyperLink ID="hyplnkbtnReportes" runat="server" NavigateUrl="~/Reportes.aspx">Reportes</asp:HyperLink>
            <div>Salir: <asp:LinkButton ID="lbtnCerrarSesionPaciente" runat="server" OnClick="lbtnCerrarSesionPaciente_Click">Cerrar Sesion</asp:LinkButton></div>
        
        </div>
       
    </form>
</body>
</html>
