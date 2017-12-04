<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrar.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.registrar" %>

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
    function validarRegistro(elemento, clave) {
        var Rut = document.getElementById("TextBox1").value;
        var rexp = new RegExp(/^([0-9])+\-([kK0-9])+$/);

        if (Rut.match(rexp))
        {
        }
        else
        {
            alert("Formato incorrecto. El formato correcto es 12345678-9");
            return false;
        }

        if (document.getElementById("TextBox1").value == "")
        {
            alert("llene los valores de RUT");
            return false;
        }

        if (document.getElementById("TextBox2").value == "") {
            alert("llene los valores de NOMBRE");
            return false;
        }

        if (document.getElementById("TextBox3").value == "") {
            alert("llene los valores de APELLIDO PATERNO");
            return false;
        }

        if (document.getElementById("TextBox4").value == "") {
            alert("llene los valores de APELLIDO MATERNO");
            return false;
        }

        if (document.getElementById("TextBox5").value == "") {
            alert("llene los valores de CORREO");
            return false;
        }

        if (document.getElementById("TextBox6").value == "") {
            alert("llene los valores de NUMERO CONTACTO");
            return false;
        }

        if (document.getElementById("TextBox7").value.length <= 6) {
            alert("La contraseña debe tener un mínimo de 6 caracteres.");
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
            
        <form class="registro" id="form1" runat="server">
            <h1 class="login-heading">Formulario de Registro</h1>
            <div class="row">
                <div class="col-lg-12">

                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <asp:Label CssClass="txtLabelRegistro" Text="Rut: " runat="server" />
                            <asp:TextBox CssClass="form-control txtTextbox" ID="TextBox1" runat="server" />
                            <br />
                            <br />
                            <asp:Label CssClass="txtLabelRegistro" Text="Nombre: " runat="server" />
                            <asp:TextBox CssClass="form-control txtTextbox" ID="TextBox2" runat="server" onkeypress='return event.charCode == 32 || (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122)' />
                            <br />
                            <br />
                            <asp:Label CssClass="txtLabelRegistro" Text="Apellido Paterno: " runat="server" />
                            <asp:TextBox CssClass="form-control txtTextbox" ID="TextBox3" runat="server" onkeypress='return event.charCode == 32 || (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122)' />
                            <br />
                            <br />
                            <asp:Label CssClass="txtLabelRegistro" Text="Apellido Materno: "  runat="server" />
                            <asp:TextBox CssClass="form-control txtTextbox" ID="TextBox4" runat="server" onkeypress='return event.charCode == 32 || (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122)' />
                            <br />
                            <br />
                        </div>
                        
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <asp:Label CssClass="txtLabelRegistro" Text="Email: " runat="server" />
                            <asp:TextBox CssClass="form-control txtTextbox" ID="TextBox5" runat="server" onkeypress='return event.charCode == 45 || event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57) || (event.charCode >=64 & event.charCode <= 90) || event.charCode == 95 || (event.charCode >=97 && event.charCode <= 122) ' />
                            <br />
                            <br />
                            <asp:Label CssClass="txtLabelRegistro" Text="Telefono de Contacto: " runat="server" />
                            <asp:TextBox CssClass="form-control txtTextbox" ID="TextBox6" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57' />
                            <br />
                            <br />
                            <asp:Label CssClass="txtLabelRegistro" Text="Contraseña: " runat="server" />
                            <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" TextMode="Password" />
                        </div>
                    </div>

                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-lg-12">
                    <asp:Button CssClass="btn btn-lg btn-block btn-success btnRegistro" ID="Button1" OnClientClick="return validarRegistro('TextBox1','TextBox7')" runat="server" Text="Registrarse" OnClick="Button1_Click" />
                    <asp:Button CssClass="btn btn-lg btn-block btn-default btnRegistro" ID="Button2" runat="server" Text="Volver" OnClick="Button2_Click" />
                </div>
            </div>
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
