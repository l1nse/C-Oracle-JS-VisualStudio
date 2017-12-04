<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambiarCuentaAVendedor.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.cambiarCuentaAVendedor" %>

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
        function validarDatos()
        {
            if (document.getElementById("DropDownList2").value == "Seleccione una región")
            {
                alert("Seleccione una región");
                return false;
            }

            if (document.getElementById("DropDownList3").value == "Seleccione una provincia")
            {
                alert("Seleccione una provincia");
                return false;
            }
        
            if (document.getElementById("txtDireccion").value == "")
            {
                alert("Ingrese un valor a DIRECCIÓN");
                return false;
            }
            if (document.getElementById("txtLongitud").value == "")
            {
                alert("Ingrese un valor a LONGITUD");
                return false;
            }
            if (document.getElementById("txtLatitud").value == "")
            {
                alert("Ingrese un valor a LATITUD");
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
    <form id="form1" runat="server" method="POST">
        <h1 class="login-heading">Enviar Correo Para Cambiar De Perfil</h1>
        <div class="row">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:Label CssClass="txtLabel" Text="Asunto: " runat="server" /> 
                        <asp:TextBox CssClass="form-control" ID="txtAsuntoC" runat="server" Enabled="false"/>
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Nombre: " runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtNombreC" runat="server" Enabled="false"/>
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Apellido Paterno: " runat="server" /> 
                        <asp:TextBox CssClass="form-control" ID="txtAPaterno" runat="server" Enabled="false"/>
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Apellido Materno: " runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtAMaterno" runat="server" Enabled="false"/>
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Fono: " runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtFono" runat="server" Enabled="false"/>
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Correo: " runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtCorreoC" runat="server" Enabled="false"/>
                        <br />
                        <br />
                    </div>
                    
                    <div class="col-sm-12 col-md-12">
                        <asp:Label CssClass="txtLabel" Text="Region: " runat="server" />
                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                            <asp:ListItem>Seleccione una región</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Provincia: " runat="server" />
                        <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" >
                            <asp:ListItem>Seleccione una región</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Comuna: " runat="server" />
                        <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" AutoPostBack="True" >
                            <asp:ListItem>Seleccione una provincia</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Direccion: " runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtDireccion" runat="server"  Enabled="true"/>
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Latitud: " runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtLatitud" runat="server" Enabled="true" onkeypress='return (event.charCode >= 44 && event.charCode <= 46) || (event.charCode >= 48 && event.charCode <= 57)' />
                        <br />
                        <br />
                        <asp:Label CssClass="txtLabel" Text="Longitud: " runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtLongitud" runat="server"  Enabled="true" onkeypress='return (event.charCode >= 44 && event.charCode <= 46) || (event.charCode >= 48 && event.charCode <= 57)' />
                    </div>
                </div>
            </div>          
        </div>
        <br />
        <br />
        <asp:Button CssClass="btn btn-lg btn-primary" ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click" OnClientClick="return validarDatos()"/>
        <asp:Button CssClass="btn btn-lg btn-default" ID="Button2" runat="server" Text="Volver" OnClick="Button2_Click" />
        <br />
        <br />
        <asp:Label CssClass="txtLabel" ID="lblRespuesta" runat="server"></asp:Label>
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
