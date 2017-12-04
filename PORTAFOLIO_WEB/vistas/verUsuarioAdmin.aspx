<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verUsuarioAdmin.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.verUsuarioAdmin" %>

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
    function validarbuscar()
    {
        if (document.getElementById("txtBuscar").value == "") {
            alert("Ingrese el usuario que desea buscar.");
            return false;
        }

        if (document.getElementById("RadioButton1").click)
        {
            var rexp = new RegExp(/^([0-9])+\-([kK0-9])+$/);
            if (document.getElementById("txtBuscar").value.match(rexp))
            {

            }
            else
            {
                alert("Ingrese números (0-9) o letra 'K' / 'k'");
            }
        }
        else
        {
            var rexp = new RegExp(/^[a-zA-Z\s]+$/);
            if (document.getElementById("txtBuscar").value.match(rexp))
            {
                
            }
            else {
                alert ("Ingrese solo letras (minúsculas o mayúsculas)");
            }
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
    <form id="form1" class="vistaTablas" runat="server">
    
    
        <h1 class="tablas-heading">Ver usuarios</h1> <br />
        <div class="row">
            <div class="col-lg-4">
        <asp:Label ID="Label2" CssClass="txtLabel" runat="server" Text="Buscar: " />
                </div>
            <div class="col-lg-8">
        <asp:TextBox ID="txtBuscar" CssClass="form-control" runat="server" ></asp:TextBox>
                </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
        <asp:Label ID="Label3" CssClass="txtLabel" runat="server" Text="Filtrar por: " />
                </div>
            <div class="col-lg-8">
        <asp:RadioButton ID="RadioButton1" CssClass="chkLabel" runat="server" Text="Rut" GroupName="grRadio" ToolTip="nombre" Checked="True" />
        <asp:RadioButton ID="RadioButton2" CssClass="chkLabel" runat="server" Text="Nombre" GroupName="grRadio" ToolTip="nombre" />
                </div>
        </div>
        <asp:Button ID="btnFiltrar" CssClass="btn btn-sm btn-info" runat="server" OnClientClick="return validarBuscar()" Text="Filtrar" OnClick="btnFiltrar_Click" />
        <asp:Button ID="btnVolverP" CssClass="btn btn-sm  btn-default" runat="server" Text="Volver" OnClick="btnVolverP_Click" />
        
        <br />
        <br />
        <asp:Label ID="Label1" CssClass="txtLabel" runat="server"></asp:Label>
        
        <br />
        <br />
        <div style="width: 100%; overflow: auto;">
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="rut" OnRowEditing="upGrade" OnSelectedIndexChanging="Bloquear" OnRowDeleting="Activar" CssClass="table table-bordered"  cellspacing="0" width="100%">
            <Columns>
                <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-danger" ButtonType="Button" SelectText="Bloquear" ShowSelectButton="True" />
                <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-warning" ButtonType="Button" EditText="UpGrade" ShowEditButton="True" />
                <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-primary" ButtonType="Button" DeleteText="Activar" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
            </div>
        <br />
        <br />
        
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
