<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambiarContrasenia.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.cambiarContrasenia" %>

<!DOCTYPE html>
<script type="text/javascript">
    function cambioClave()
    {
        if (document.getElementById("txtCActual").value == "")
        {
            alert("No puedes dejar campos vacíos.")
         //   return false;
        }
        if (document.getElementById("txtCNueva").value == "") {
            alert("No puedes dejar campos vacíos.")
         //   return false;
        }
        if (document.getElementById("txtConfirmarCNueva").value == "") {
            alert("No puedes dejar campos vacíos.")
         //   return false;
        }
        if (document.getElementById("txtCNueva").value.length <= 6) {
            alert("La contraseña debe tener un mínimo de 6 caracteres.");
         //   return false;
        }
        if (document.getElementById("txtConfirmarCNueva").value.length <= 6) {
            alert("La contraseña debe tener un mínimo de 6 caracteres.");
         //   return false;
        }
        if (document.getElementById("txtCNueva").value == document.getElementById("txtActual").value)
        {
            alert("La contraseña nueva no puede ser igual a la antigua. ")
         //   return false;
        }
        if (document.getElementById("txtConfirmarCNueva").value != document.getElementById("txtCNueva").value)
        {
            alert("No has confirmado la contraseña correctamente");
         //   return false;
        }
    }
</script>

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
        <form class="login" id="form1" runat="server">
        <div>
    
            <h1 class="login-heading">Modificar Contraseña</h1>
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Contraseña Actual: " runat="server" /> 
            <asp:TextBox CssClass="form-control" ID="txtCActual" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Nueva Contraseña: " runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtCNueva" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label CssClass="txtLabel" Text="Confirmar Nueva Contraseña: " runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtConfirmarCNueva" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label CssClass="txtLabel" ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button CssClass="btn btn-lg btn-primary" ID="Button1" runat="server" OnClick="Button1_Click" OnClientText="return cambiarClave()" Text="ACEPTAR" />
            <asp:Button CssClass="btn btn-lg btn-default" ID="Button2" runat="server" OnClick="Button2_Click" Text="CANCELAR" />
    
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
