<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarProductoAdmin.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.agregarProductoAdmin" %>

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
   /* function validarProducto()
    {
        if (document.getElementById("TextBox1").value == "")
        {
            alert("Ingresa un nombre");
            return false;
        }
        if (document.getElementById("TextBox3").value == "")
        {
            alert("Ingresa un valor");
            return false;
        }
        if (document.getElementById("TextBox3").value == "0")
        {
            alert("Ingresa un valor mayor a 0");
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
          <a class="navbar-brand" href="panelAdministrador.aspx">Frutos Frescos</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav">
            <li><a href="panelAdministrador.aspx">Inicio</a></li>
            <li><a href="verUsuarioAdmin.aspx">Ver Usuario</a></li>
            <li><a href="verProductoresAdmin.aspx">Ver Productores</a></li>
            <li><a href="verProductosProdAdmin.aspx">Productos</a></li>
            <li><a href="verVentas.aspx">Ver Ventas</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>
    <div class="container">
        <h1 class="login-heading">Agregar Producto</h1>
        <form class="login" id="form1" runat="server">
        
            <asp:Label CssClass="txtLabel" Text="Nombre: " runat="server" />
            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" onkeypress='return event.charCode == 32 || (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122)' />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Valor: " runat="server" />
            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57' />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="btnAgregar" Text="AGREGAR PRODUCTO" runat="server" OnClick="btnAgregar_Click" OnClientClick="return validarProducto()" />
    
        
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
