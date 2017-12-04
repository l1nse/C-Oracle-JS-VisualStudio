<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarProductoAdmin.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.editarProductoAdmin" %>

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
<script>
    function validarValor()
    {
        if (document.getElementById('TextBox1').value == "")
        {
            alert("Ingresa un valor al stock");
            return false;
        }
        if (document.getElementById('TextBox1').value == 0)
        {
            alert("Ingrese un valor mayor a 0");
            return false;
        }
    }
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
        <h1 class="panelUsuario-heading">Editar Producto</h1>
        <form class="panelUsuario" id="form1" runat="server">
        <div>
            <asp:Label CssClass="txtLabel" Text="ID Producto:" runat="server" /> 
            <asp:Label CssClass="txtLabel" ID="Label1" Text="" runat="server" />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Nombre Producto:" runat="server" />  
            <asp:Label CssClass="txtLabel" ID="Label2" Text="" runat="server" />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Estado Producto: " runat="server" />
            <asp:Label CssClass="txtLabel" ID="Label5" Text="" runat="server" />
            <br />
            <br />
            <br />
            <asp:Label  CssClass="txtLabel" Text="Valor Producto:" runat="server" />  
            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57' />
            <asp:Button CssClass="btn btn-block btn-lg btn-primary" ID="btnAcualizar" Text="Actualizar Valor" runat="server" OnClick="btnAcualizar_Click" />
            <asp:Label CssClass="txtLabel" ID="Label6" Text="" runat="server" />
            <br />
            <br />
            <br />
            <br />
            
            <asp:Button CssClass="btn btn-block btn-lg btn-default" Text="Volver" runat="server" OnClick="Unnamed6_Click"  />
    
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
