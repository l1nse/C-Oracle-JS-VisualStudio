<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verVentas.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.verVentas" %>

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
    function validarFiltro()
    {
        if (document.getElementById("rbtFiltrarF").checked)
        {
            if (document.getElementById("inputf1").valueAsDate == null)
            {
                alert("Ingrese una fecha de inicio");
                return false;
            }
            if (document.getElementById("inputf2").valueAsDate == null)
            {
                alert("Ingrese una fecha de término");
                return false;
            }
        }

        if (document.getElementById("RadioButton2").checked)
        {
            if (document.getElementById("txtBoleta").value == "")
            {
                alert ("Ingrese el número de boleta");
                return false;
            }
        }
        return false;
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
    
            <h1 class="tablas-heading">VER VENTAS</h1> 
             <div class="row">
                <div class="col-lg-4">
            <asp:RadioButton ID="rbtFiltrarF" CssClass="txtLabel" runat="server" Text="Filtrar por Fecha: " GroupName="grRadio" ToolTip="Fecha" Checked="True" />
             </div>
                <div class="col-lg-8">
            <label class="txtLabel" for="meeting">Fecha inicio : </label><input class="form-control" id="inputf1" type="date" runat="server"/>
            <label class="txtLabel" for="meeting">Fecha termino : </label><input class="form-control" id="inputf2" type="date" runat="server" />
            
            </div>
            <div class="row">
            <div class="col-lg-4">
            <asp:RadioButton class="txtLabel" ID="RadioButton2" runat="server" Text="Filtrar por N° Boleta: " GroupName="grRadio" ToolTip="Boleta" />
            </div>
                <div class="col-lg-8">
            <asp:TextBox ID="txtBoleta" CssClass="form-control" runat="server" ></asp:TextBox>
             </div>
                </div>
            <asp:Button ID="Button1" CssClass="btn btn-lg btn-primary" runat="server" Text="Buscar" OnClick="Button1_Click1" />
            &nbsp;
            <asp:Button ID="btnVolverH" CssClass="btn btn-lg btn-default" runat="server" OnClick="Button1_Click" Text="VOLVER" />
            &nbsp;
            <asp:Button ID="Button2" CssClass="btn btn-lg btn-info" runat="server" OnClick="Button2_Click" Text="Mostrar Todo" />
            <br />
            <asp:Label ID="Label1" CssClass="txtLabel" runat="server"></asp:Label>
            <br />
                 <div style="width: 100%; overflow: auto;">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="codboleta" OnSelectedIndexChanging="Seleccionar" CssClass="table table-bordered"  cellspacing="0" width="100%">
                <Columns>
                    <asp:CommandField ControlStyle-CssClass="btn btn-lg btn-primary" ButtonType="Button" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
                     </div>
    
        </div>
        </form>

    </div>
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

