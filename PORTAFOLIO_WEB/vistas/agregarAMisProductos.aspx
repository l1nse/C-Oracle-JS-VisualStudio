<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarAMisProductos.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.agregarAMisProductos" %>

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
<script type="text/javascript">
  /*  function validarProducto()
    {
        if (document.getElementById("txtCarrito").value == "")
        {
            alert("Ingresa un valor");
            return false;
        }
        if (document.getElementById("txtCarrito").value = "0")
        {
            alert("Ingresa un valor mayor a 0.");
            return false;
        }
    }*/
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
        <h1 class="login-heading">Agregar Producto a Mis Productos</h1>
        <form class="login" id="form1" runat="server">
            <asp:Label CssClass="txtLabel" Text="Nombre: " runat="server" />
            <asp:Label CssClass="txtLabel" Text="" ID="Label1" runat="server" />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Valor: " runat="server" />
            <asp:Label CssClass="txtLabel" Text="" ID="Label2" runat="server" />
            <br />
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label CssClass="txtLabel" Text="Ingrese Cantidad Desea: " runat="server" />
                </div>
                <div class="col-lg-8">
                    <asp:TextBox CssClass="form-control" ID="txtCarrito" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57' />
                </div>
            </div>
            <br />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" ID="Label7" runat="server"></asp:Label>
            <br />
            <asp:Button CssClass="btn btn-lg btn-primary" ID="ButtonCarrito" Text="Agregar" runat="server" OnClick="ButtonCarrito_Click" OnClientClick="return validarProducto()" />
            <asp:Button CssClass="btn btn-lg btn-default" ID="Button1" runat="server" Text="Volver" OnClick="Button1_Click" />
            
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
