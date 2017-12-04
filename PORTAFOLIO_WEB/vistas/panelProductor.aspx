<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="panelProductor.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.panelProductor" %>

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
          <a class="navbar-brand" href="panelProductor.aspx">Frutos Frescos</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav">
            <li><a href="panelProductor.aspx">Inicio</a></li>
            <li><a href="editarCuentaProductor.aspx">Editar Cuenta</a></li>
            <li><a href="verProductosProductor.aspx">Productos</a></li>
            <li><a href="misProductos.aspx">Mis Productos</a></li>
            <li><a href="historialVentas.aspx">Historial de Ventas</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>

    <div class="container">
        <form class="panelUsuario" id="form1" runat="server">
    
            <h1 class="panelUsuario-heading">Panel Productor</h1>
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Bienvenido, " runat="server" ID="Label1" />
            <asp:Label CssClass="txtLabel" Text="" runat="server" ID="Label2" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-lg-3">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button1" ID="btnEditarCuenta" runat="server" OnClick="Button1_Click" Text="Editar Cuenta" />
                </div>
                <div class="col-lg-3">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button3" ID="btnProductos" runat="server" Text="Productos" OnClick="Button3_Click" />
                </div>
                <div class="col-lg-3">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button3" ID="btnMisProductos" runat="server" Text="Mis Productos" OnClick="Button4_Click" />
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-lg-3">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button4" ID="btnHistorial" runat="server" Text="Historial de Ventas" OnClick="Button5_Click" />
                </div>
                <div class="col-lg-3">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button5" ID="btnCerrar" runat="server" Text="Cerrar Sesion" OnClick="Button6_Click" />
                </div>
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
