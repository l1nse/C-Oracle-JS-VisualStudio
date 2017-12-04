<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarAlCarrito.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.agregarAlCarro" %>

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
<script type="text/javascript">
    function validarCarrito()
    {
        if (document.getElementById("txtCarrito").value == "")
        {
            alert("Ingrese el stock para agregar a carrito.")
            return false;
        }
    }
</script>
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
        <h1 class="login-heading">Agregar Producto al Carrito</h1>
        <form class="login" id="form1" runat="server" onsubmit="return validarAlCarrito()">
            <asp:Label CssClass="txtLabel" Text="Nombre: " runat="server" />  
            <asp:Label CssClass="txtLabel" Text="" ID="Label1" runat="server" />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Valor: " runat="server" />  
            <asp:Label CssClass="txtLabel" Text="" ID="Label2" runat="server" />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Productor: " runat="server" />  
            <asp:Label CssClass="txtLabel" Text="" ID="Label3" runat="server" />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Stock / Kg: " runat="server" />  
            <asp:Label CssClass="txtLabel" Text="" ID="Label5" runat="server" />
            <br />
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label CssClass="txtLabel" Text="Ingrese Cantidad Desea: " runat="server" />
                </div>
                <div class="col-lg-8">
                    <asp:TextBox CssClass="form-control" ID="txtCarrito" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>
                </div>
            </div>
            <br />
            <asp:Button CssClass="btn btn-lg btn-block btn-default" ID="ButtonCarrito" Text="Agregar" runat="server"  OnClick="ButtonCarrito_Click"  return="validarAlCarrito()" OnClientClick="return validarCarrito()" />
            
            <br />
            <br />
            <asp:Label CssClass="txtLabel" ID="Label6" runat="server"></asp:Label>
            
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
