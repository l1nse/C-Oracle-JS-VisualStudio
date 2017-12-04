<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarCuenta.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.editarCuenta" %>

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
    <script type="text/javascript">
    </script>
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
        <form class="panelUsuario" id="form1" runat="server">
    
            <h1 class="panelUsuario-heading">Editar Cuenta</h1>
            <br />
            <asp:Label CssClass="txtLabel" Text="Rut: " runat="server" />
            <asp:Label CssClass="txtLabel" Text="" runat="server" ID="Label1"/>
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Nombre: " runat="server" />
            <asp:Label CssClass="txtLabel" Text="" runat="server" ID="Label2"/>
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Apellido Paterno: " runat="server" />
            <asp:Label CssClass="txtLabel" Text="" runat="server" ID="Label3"/>
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Apellido Materno: " runat="server" />
            <asp:Label CssClass="txtLabel" Text="" runat="server" ID="Label4"/>
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Email: " runat="server" />
            <asp:Label CssClass="txtLabel" Text="" runat="server" ID="Label5"/>
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Teléfono de Contacto: " runat="server" />
            <asp:Label CssClass="txtLabel" Text="" runat="server" ID="Label6"/>
            <br />
            <br />
            <br />
            <br />
            <br />
            
            <div class="row">
                <div class="col-lg-4">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button8" ID="btnCambiarCuenta" runat="server" OnClick="Button2_Click" Text="Cambiar Cuenta a Vendedor" />
                </div>
                <div class="col-lg-4">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button9" ID="btnCerrarCuenta" runat="server" Text="Cerrar Cuenta" OnClick="Button3_Click" />
                </div>
                <div class="col-lg-4">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button10" ID="btnPanelPrincipal" runat="server" OnClick="Button4_Click" Text="Panel Principal" />
                </div>
            </div>

            <br />
            <br />

            <div class="row">
                <div class="col-lg-4">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button11" ID="btnModificarContrasenia" runat="server" Text="Modificar Contraseña" OnClick="Button5_Click" />
                </div>
                <div class="col-lg-4">
                    <asp:Button CssClass="btn btn-block btn-lg btn-default button11" ID="btnModificarDatos" runat="server" OnClick="Button6_Click" Text="Modificar Datos Personales"/>
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
