<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE-edge"/>
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/Style.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Noto+Serif" rel="stylesheet" />
    <title>Frutos Frescos</title>
    <script src ="js/validarDatos.js" type="text/javascript"></script>
    <script type="text/javascript">

        function validarAlCarrito(elemento, clave)
        {

            var Rut = document.getElementById(elemento).value;
            var rexp = new RegExp(/^([0-9])+\-([kK0-9])+$/);
            if (Rut == "")
            {
                alert("Ingrese un valor en campo RUT");
                return false;
            }
            var Clave = document.getElementById(clave).value;
            if (Clave == "") {
                alert("Debe insertar un valor en el campo clave.");
                return false;
            }

            if (Rut.match(rexp))
            {}
            else
            {
                alert("Formato incorrecto. El formato correcto es 12345678-9");
                return false;
            }
        }
    </script>
</head>
<body>
   <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <%--<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>--%>
          <a class="navbar-brand" href="#">Frutos Frescos</a>
        </div>
        <%--<div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav">
            <li class="active"><a href="#">Home</a></li>
            <li><a href="#about">About</a></li>
            <li><a href="#contact">Contact</a></li>
          </ul>
        </div><!--/.nav-collapse -->--%>
      </div>
    </nav>
    <div class="container">
        
            <form class="login" id="form1" runat="server" method="get">
               
                    <h1 class="login-heading">Ingrese a Su Cuenta</h1>
                                       
                    <asp:Label CssClass="txtLabel" Text="Rut: " runat="server" />
                    <asp:TextBox CssClass="form-control txtTextbox" ID="TextBox1" runat="server" MaxLength="10" TextMode="SingleLine" onkeypress='return event.charCode == 45 || event.charCode == 75 || event.charCode == 107 || (event.charCode >= 48 && event.charCode <= 57)'></asp:TextBox>  
                     
                    <br />         
                    <asp:Label CssClass="txtLabel" Text="Clave: " runat="server" />
                    <asp:TextBox CssClass="form-control txtTextbox" ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                               
                            <asp:Button CssClass="btn btn-lg btn-block btn-primary" ID="Button1" runat="server" Text="Ingresar" OnClientClick="return validarAlCarrito('TextBox1','TextBox2')" OnClick="Button1_Click"/>
                           
                            <asp:Button CssClass="btn btn-lg btn-block btn-default" ID="Button2" runat="server" Text="Registrarse" OnClick="Button2_Click" />
                   
                    <br />
                    <br />
                    <br />
                    <asp:Label CssClass="txtLabel" ID="Label1" runat="server"></asp:Label>
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
    <script src="content/js/jquery-3.1.1.min.js"></script>
    <script src="content/js/bootstrap.min.js"></script>
</body>
</html>
