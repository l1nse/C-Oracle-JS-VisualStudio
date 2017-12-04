<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modificarUsuario.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.modificarUsuario" %>

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
    <script  type="text/javascript">
        function validarCampos()
        {
            if (document.getElementById('txtCorreo').value == "")
            {
                alert("Ingrese un valor al campo CORREO");
                return false;
            }

            if (document.getElementById('txtNumero').value == "")
            {
                alert("Ingrese un valor al campo NUMERO");
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
        <form id="form1" class="login" runat="server">
        <div>
    
            <h1 class="login-heading">Datos Personales</h1>
            <div>
                <asp:Label ID="Label2" CssClass="txtLabel" runat="server" Text="Rut: " />
                <asp:TextBox ID="txtRut" CssClass="form-control txtTextbox" runat="server" Enabled="false"></asp:TextBox>            
            </div> 
            <div> 
               <asp:Label ID="Label3" CssClass="txtLabel" runat="server" Text="Nombre: " />
                <asp:TextBox ID="txtNombre" CssClass="form-control txtTextbox" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div> 
                <asp:Label ID="Label4" CssClass="txtLabel" runat="server" Text="Apellido Paterno: " />
                <asp:TextBox ID="txtApellidoP" CssClass="form-control txtTextbox" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label5" CssClass="txtLabel" runat="server" Text="Apellido Materno: " />
                <asp:TextBox ID="txtApellidoM" CssClass="form-control txtTextbox" runat="server" Enabled="false"></asp:TextBox>
            </div> 
                <div><asp:Label ID="Label6" CssClass="txtLabel" runat="server" Text="Email: " />
                <asp:TextBox ID="txtCorreo" CssClass="form-control txtTextbox" runat="server" onkeypress='return event.charCode == 45 || event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57) || (event.charCode >=64 & event.charCode <= 90) || event.charCode == 95 || (event.charCode >=97 && event.charCode <= 122) ' />
                    
                    <asp:Button ID="btnCorreo" CssClass="btn btn-block btn-lg btn-primary" runat="server" Text="Actualizar"  OnClick="btnCorreo_Click" OnClientClick="return validarCorreo()"/>
            </div>             

            <div> 
                <asp:Label ID="Label7" CssClass="txtLabel" runat="server" Text="Teléfono de Contacto: " />
                <asp:TextBox ID="txtNumero" CssClass="form-control txtTextbox" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57'></asp:TextBox>
                <asp:Button ID="btnFono" CssClass="btn btn-block btn-lg btn-primary" runat="server" Text="Actualizar" OnClick="btnFono_Click" OnClientClick="return validarNumero()"/>
            </div>
            <br />
            <asp:Label ID="Label1" CssClass="txtLabel" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnCancelar" CssClass="btn btn-lg btn-block btn-default" runat="server" Text="Volver" OnClick="Button2_Click"/>
    
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
