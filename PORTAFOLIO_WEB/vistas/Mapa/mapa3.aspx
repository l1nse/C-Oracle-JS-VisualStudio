<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mapa3.aspx.cs" Inherits="PORTAFOLIO_WEB.vistas.Mapa.mapa3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <title>Marker animations </title>
        <script 
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDEpp5jKu_9YXkMDzqtjEsSpMn9hw2Fi6c"></script>

    <script type="text/javascript">
        function initialize() {
        }
    </script>
</head>
<body onload="initialize()">

    
    <asp:Literal id="Literal" runat="server" />
    <div id="map" style="width: 795px; height: 455px;"></div>

</body>
</html>
