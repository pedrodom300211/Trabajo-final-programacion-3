<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuInicio.aspx.cs" Inherits="Vistas.MenuInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu inicio</title>
    <link href="Style.css" rel="stylesheet" />
    
</head>
    <link href="Imagenes/My project-1.png" rel="shortcut icon" />
    
<body>
    <form id="form1" runat="server">
        <section>
            <div>                
                <asp:ImageButton ID="imgBtnEMAWeb" runat="server" ImageUrl="~/Imagenes/EMAweb-1.png" OnClick="imgBtnEMAWeb_Click"/>
                <div class="Inicio">                               
                    <asp:Button ID="BtnIrAIniciarSesion" runat="server" Text="Iniciar Sesion" ForeColor="Black" OnClick="BtnIniciarSesion_Click"/>                               
                </div>
            </div>
        </section>
    </form>
</body>
</html>
