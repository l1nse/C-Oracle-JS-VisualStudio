<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmarCierreCuenta.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.confirmarCierreCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE-edge"/>
<meta name="viewport" content="width=device-width. initial-scale=1" />
    <link href="content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/Style.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Noto+Serif" rel="stylesheet" />
    <title>Frutos Frescos</title>
    <script src ="js/validarDatos.js" type="text/javascript"></script>
</head>
<body>
    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="panelUsuario.aspx">Frutos Frescos</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav">
            <li><a href="panelUsuario.aspx">Inicio</a></li>
            <li><a href="editarCuenta.aspx">Editar Cuenta</a></li>
            <li><a href="historialCompras.aspx">Historial de Compras</a></li>
            <li><a href="verProductos.aspx">Productos</a></li>
            <li><a href="verProductores.aspx">Productores</a></li>
            <li><a href="carritoCompra.aspx">Carrito de Compra</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>
    <div class="container">
        <form id="form1"  class="login" runat="server">
        <div>
    
            <h1 class="login-heading">Confirmar Cierre de Cuenta</h1>
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" CssClass="txtLabel" Text="Ingrese su Contraseña para Confirmar:" runat="server" /> 
            <asp:TextBox ID="txtIngrese" CssClass="form-control txtTextbox" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label CssClass="txtLabel" ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnAceptar"  CssClass="btn btn-lg btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            &nbsp;
            <asp:Button ID="btnVolverC"  CssClass="btn btn-lg btn-default" runat="server" Text="Volver" OnClick="Button3_Click" />
    
        </div>
        </form>
    </div>
     <hr />
    <footer class="container ">
        <span class="text-muted footer" >
            Portafolio 2016, Proyectos FrutosFrescos
            <br />
            DuocUc - Plaza Oeste
        </span>
    </footer>
    <script src="content/jquery-3.1.1.min.js"></script>
    <script src="content/js/bootstrap.min.js"></script>
</body>
</html>
