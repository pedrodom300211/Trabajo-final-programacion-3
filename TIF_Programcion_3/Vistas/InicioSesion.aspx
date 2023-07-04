<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Vistas.MenuInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Log In</title>
    <link href="Style.css" rel="stylesheet" />
   
    <style type="text/css">
        .auto-style1 {
            width: 914px;
           /* margin-left: 243px;*/
            height: 402px;
            margin-right: 0px;
        }
        .auto-style2 {
            background-color:#FD512C;
            width: 40%;
            height: 215px;
            float:inline-start;
            margin-top: 0px;
        }
        .auto-style3 {
           
            width: 100%;
            height: 23px;
        }
        .auto-style5 {
            width: 572px;
            font-size:x-large;
        }
        .auto-style6 {
            width: 100%;
            height: 32px;
        }
        .auto-style7 {
            width: 439px;
            font-size:x-large;
            height: 32px;
        }
        .auto-style8 {
            width: 349px;
            height: 32px;
        }
        .auto-style10 {
            height: 32px;
        }
        .auto-style11 {
            width: 5px;
        }
        .auto-style12 {
            width: 11px;
        }
        .auto-style13 {
            width: 100%;
        }
        .auto-style14 {
            width: 151px;
        }
        .auto-style15 {
            width: 108%;
        }
    </style>
    </head>
     
<body>
    <form id="form1" runat="server" class="auto-style1">
        <section>
        <br />
        <br />
        <br />
        <br />
       
        <div style="border:5px double #000" class="auto-style2">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style5">Bienvenido a ESCLEROSIS MÚLTIPLE ARGENTINA </td>
                    <td class="auto-style11">&nbsp;</td>
                </tr>
            </table>
            <table class="auto-style6">
                <tr>
                    <td class="auto-style8" ></td>
                    <td class="auto-style7">(E.M.A)</td>
                    <td class="auto-style10"></td>
                </tr>
            </table>
            <table class="auto-style13">
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td>Por favor, inicie sesión</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table class="auto-style15">
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style14">DNI de usuario: </td>
                    <td>
                        <asp:TextBox ID="txtDniDeUsuario" runat="server" Width="176px" TextMode="Number"></asp:TextBox>
                        <asp:Label ID="lblUsuarioInexistente" runat="server" Text="*DNI de usuario Incorrecto!" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="auto-style13">
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style14">Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtContraseña" runat="server" Width="177px" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="lblContraseñaIncorrecta" runat="server" Visible="False">*Constraseña incorrecta!</asp:Label>
                    </td>
                </tr>
            </table>
            <table class="auto-style13">
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnIniciarSesion" runat="server" Text="iniciar sesión" OnClick="btnIniciarSesion_Click"/>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
            </section>
        </form>
</body>
</html>
