<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="misProductos.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.misProductos" %>

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
 //   function validarProducto()
   // {
     //   if (document.getElementById("txtBuscar").value == "")
       // {
         //   alert("Ingresa el producto a buscar.");
          //  return false;
        //}
    //}
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
    <form class="vistaTablas" id="form1" runat="server">
    
        <h1 class="tablas-heading">Mis Productos</h1>
        <div class="row">
            <div class="col-lg-3">
        <asp:Label CssClass="txtLabel" Text="Buscar por nombre: " ID="Label1" runat="server" />
</div>
            <div class="col-lg-6">
        <asp:TextBox CssClass="form-control txtBusqueda" ID="txtBuscar" runat="server" onkeypress='return event.charCode == 45 || event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57) || (event.charCode >=64 & event.charCode <= 90) || event.charCode == 95 || (event.charCode >=97 && event.charCode <= 122)' ></asp:TextBox>
        </div>
            
            <div class="col-lg-3">
        <asp:Button CssClass="btn btn-lg  btn-info" ID="Button3" runat="server" Text="Filtrar" OnClick="Button3_Click1"  />
        
            
        <asp:Button CssClass="btn btn-lg  btn-default" ID="btnVolverP" runat="server" Text="Volver" OnClick="Button2_Click" />
                </div>
        </div>
        <br />
        <br />
        <br />
        <div style="width: 100%; overflow: auto;">
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="CodStock" OnRowDeleting="Restar" OnRowEditing="Sumar" OnSelectedIndexChanging="Eliminar" CssClass="table table-bordered"  cellspacing="0" width="100%">
            <Columns>
                <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-danger" ButtonType="Button" SelectText="Eliminar" ShowSelectButton="True" />
                <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-success" ButtonType="Button" EditText="Sumar" ShowEditButton="True" />
                <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-warning" ButtonType="Button" DeleteText="Restar" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
            </div>

        <br />
    &nbsp;        
    
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
