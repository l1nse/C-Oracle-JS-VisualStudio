<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detalleVentas.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.detalleVentas" %>

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
        <form id="form1" class="vistaTablas" runat="server">
        <div>
             
            <h1 class="tablas-heading">Detalle Ventas</h1>
            <div class="row" >
                 <div class="col-lg-3">
            <asp:Label Text="N° de Boleta: " CssClass="txtLabel" runat="server" />
            <asp:Label ID="Label1" CssClass="txtLabel" runat="server"></asp:Label>
                </div>
                <div class="col-lg-3">
            <asp:Label Text="Fecha de Emisión: " CssClass="txtLabel" runat="server" />
            <asp:Label ID="Label2" CssClass="txtLabel" runat="server" ></asp:Label>
                </div>
                <div class="col-lg-3">
            <asp:Label Text="Rut Cliente: " CssClass="txtLabel" runat="server" />
            <asp:Label ID="Label3" CssClass="txtLabel" runat="server" ></asp:Label>
                </div>
                <div class="col-lg-3">
            <asp:Label Text="Valor Total: " CssClass="txtLabel" runat="server" />
            <asp:Label ID="Label4" runat="server" CssClass="txtLabel" ></asp:Label>
                </div>
                </div>
            <br />
            <br />
            <asp:Button ID="btnVolverD" CssClass="btn btn-sm btn-block btn-default" runat="server" OnClick="Button1_Click" Text="Volver" />
            <br />
            <br />
            <div style="width: 100%; overflow: auto;">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered"  cellspacing="0" width="100%">
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

