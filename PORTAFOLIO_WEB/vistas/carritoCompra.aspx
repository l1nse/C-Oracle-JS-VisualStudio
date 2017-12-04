<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carritoCompra.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.carritoCompra" %>

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
   // function validarCarrito()
   // {
       // if (document.getElementById("txtCCarrito").value == "")
       // {
       //     alert("Ingrese la ID del carrito que desea buscar.");
       //     return false;
   //     }
  //  }
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
        <form class="vistaTablas" id="form1" runat="server">
            <div>
                <h1 class="tablas-heading">Carrito de Compras</h1>
                <div class="row">
                    <div class="col-lg-2">
                        <asp:Label CssClass="txtLabel" Text="Filtrar por nombre: " runat="server" />
                    </div>

                    <div class="col-lg-6">
                        <asp:TextBox CssClass="form-control" ID="txtCCarrito" runat="server" onkeypress='return event.charCode == 32 || (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122)'/>
                    </div>
                </div>
                
                
                <div class="col-lg-4">
                    <asp:Button CssClass="btn btn-lg btn-success" ID="btnComprar" runat="server" Text="Comprar" OnClick="btnComprar_Click" />
                    &nbsp;
                    <asp:Button CssClass="btn btn-lg btn-primary" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" OnClientClick="return validarCarrito()" />
                    &nbsp;
                    <asp:Button CssClass="btn btn-lg btn-default" ID="btnVolverCC" runat="server" OnClick="Button2_Click" Text="VOLVER" />
                </div>
                
                
                <br />
                <asp:Label CssClass="txtLabel" ID="Label1" runat="server"></asp:Label>
                <br />
                <br />
                <br />
                <div style="width:100%; overflow:auto;" >
                    <asp:GridView CssClass="table-bordered" CellSpacing="0" Width="100%" ID="GridView2" runat="server"></asp:GridView>
                
                </div>
                <br />
                <div style="width:100%; overflow:auto;" >
                <asp:GridView CssClass="table-bordered" CellSpacing="0" Width="100%" ID="GridView1" runat="server" DataKeyNames="codpedido" OnSelectedIndexChanging="Eliminar"
                    OnRowDeleting="Restar" OnRowEditing="Sumar" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-danger" ButtonType="Button" SelectText="Eliminar" ShowSelectButton="True" />
                        <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-success" ButtonType="Button" EditText="Sumar" ShowEditButton="True" />
                        <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-warning" ButtonType="Button" EditText="restar" ShowDeleteButton="True" DeleteText="Restar" />
                    </Columns>
                </asp:GridView>
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
