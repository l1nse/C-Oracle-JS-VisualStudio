<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upGraderAdmin.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.upGraderAdmin" %>

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
    function verificarUsuario()
    {
        if (document.getElementById("txtIngresar13").value == "")
        {
            alert ("Ingresar NOMBRE UBICACIÓN");
            return false;
        }
        if (document.getElementById("txtIngresar11").value == "")
        {
            alert ("Ingresar DESCRIPCIÓN UBICACIÓN");
            return false;
        }
        if (document.getElementById("DropDownList2").value == "Seleccione una region")
        {
            alert("Seleccione una region");
            return false;
        }
        if (document.getElementById("DropDownList3").value == "Seleccione una provincia")
        {
            alert("Seleccione una provincia");
            return false;
        }
        if (document.getElementById("txtIngresar9").value == "")
        {
            alert ("Ingresar LATITUD");
            return false;
        }
        if (document.getElementById("txtIngresar10").value == "")
        {
            alert ("Ingresar LONGITUD");
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
    <form id="form1" class="registro" runat="server">
        <h1 style="height: 5px" class="login-heading">&nbsp;Upgrade de Cuenta</h1>
    
    
        <div class="row">
                <div class="col-lg-12">

                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <br />
        <asp:Label ID="Label2" CssClass="txtLabel" runat="server" Text="Id: " />
        <asp:TextBox ID="txtIngresar0" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
    
        <asp:Label ID="Label3" CssClass="txtLabel" runat="server" Text="Rut: " />
        <asp:TextBox ID="txtIngresar1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
    
        
        <asp:Label ID="Label4" CssClass="txtLabel" runat="server" Text="Nombre: " />
        <asp:TextBox ID="txtIngresar2" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
    
        
        <asp:Label ID="Label5" CssClass="txtLabel" runat="server" Text="Apellido Paterno: " />
        <asp:TextBox ID="txtIngresar3" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
    
        <asp:Label ID="Label6" CssClass="txtLabel" runat="server" Text="Apellido Materno: " />
        <asp:TextBox ID="txtIngresar4" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
            
        <asp:Label ID="Label7" CssClass="txtLabel" runat="server" Text="Tipo Usuario: " />
        <asp:TextBox ID="txtIngresar5" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
    
            </div>
            <div class="col-md-12 col-sm-12">

        <asp:Label ID="Label8" CssClass="txtLabel" runat="server" Text="Nombre Ubicación: " />
        <asp:TextBox ID="txtIngresar13" runat="server" CssClass="form-control"  ></asp:TextBox>
    
        
        <asp:Label ID="Label9" CssClass="txtLabel" runat="server" Text="Descripción Ubicación: " />
        <asp:TextBox ID="txtIngresar11" runat="server" CssClass="form-control"  ></asp:TextBox>
    
        <asp:Label ID="Label10" CssClass="txtLabel" runat="server" Text="Dirección: " />       
        <asp:TextBox ID="txtIngresar12" runat="server" CssClass="form-control" ></asp:TextBox>
    
        <asp:Label ID="Label11" CssClass="txtLabel" runat="server" Text="Región: " />
        <asp:DropDownList  CssClass="form-control" ID="DropDownList1" runat="server"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"   >
            <asp:ListItem Value="Seleccione una region">Seleccione una region</asp:ListItem>
        </asp:DropDownList>
    
        <asp:Label ID="Label12" CssClass="txtLabel" runat="server" Text="Provincia: " />        
        <asp:DropDownList  CssClass="form-control" ID="DropDownList2" runat="server"   OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>Seleccione una provincia</asp:ListItem>
        </asp:DropDownList>
    
        <asp:Label ID="Label13" CssClass="txtLabel" runat="server" Text="Comuna: " />
        <asp:DropDownList  CssClass="form-control" ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  AutoPostBack="True">
            <asp:ListItem>Seleccione una comuna</asp:ListItem>
        </asp:DropDownList>
    
        <asp:Label ID="Label14" CssClass="txtLabel" runat="server" Text="Latitud: " />        
        <asp:TextBox ID="txtIngresar9" CssClass="form-control" runat="server" onkeypress='return event.charCode == 45 || event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57) || (event.charCode >=64 & event.charCode <= 90) || event.charCode == 95 || (event.charCode >=97 && event.charCode <= 122) '></asp:TextBox>
    
        <asp:Label ID="Label15" CssClass="txtLabel" runat="server" Text="Longitud: " />
        <asp:TextBox ID="txtIngresar10" CssClass="form-control" runat="server" onkeypress='return event.charCode == 45 || event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57) || (event.charCode >=64 & event.charCode <= 90) || event.charCode == 95 || (event.charCode >=97 && event.charCode <= 122) '></asp:TextBox>
    
        </div>
                    </div>

                </div>
            </div>
    
        <br />
        <asp:Label ID="Label1" CssClass="txtLabel" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" CssClass="btn btn-lg btn-primary" runat="server" Text="Upgrade" OnClick="Button1_Click" OnClientClick="return verificarUsuario()" />
    
    &nbsp;
        <asp:Button ID="Button2" CssClass="btn btn-lg btn-default" runat="server" Text="Volver" OnClick="Button2_Click" />
    
    
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
