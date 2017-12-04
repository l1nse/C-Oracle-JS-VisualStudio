using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas.Mapa
{
    public partial class mapa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 1)
                {
                    string rut = Context.Request.Params["rut"];

                    PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
                    var q = bdd.GEOLOCPORRUT(rut);

                    string lat = "";
                    string lon = "";

                    foreach (var cadaConsulta in q)
                    {
                        lat = cadaConsulta.LATITUDGEOLOC;
                        lon = cadaConsulta.LONGITUDGEOLOC;
                    }

                    //var q = bdd.GEOLOCPORRUT();
                    //aca recibir latitud y longitud para recibir por get 
                    string latitudAcentrar = lat;
                    string LongitudACentrar = lon;
                    string LatitudCliente = lat;
                    string LongitudCliente = lon;

                    string markers = GetMarkers(LatitudCliente, LongitudCliente);
                    Literal1.Text = @"
                    <script type='text/javascript'>
                    function initialize() {

                    var mapOptions = {
                        center: new google.maps.LatLng(" + latitudAcentrar + ",'" + LongitudACentrar + @"'),
                        zoom: 12,
                        mapTypeId: google.maps.MapTypeId.HYBRID
                    };

                    var myMap = new google.maps.Map(document.getElementById('mapArea'),
                        mapOptions);" + markers +
                                                @"
                    }
                    </script>";
                }
                else
                {
                    string error = "Usted no tiene permiso para ingresar a esta vista";
                    Response.Redirect(string.Format("ERROR.aspx?error={0}", error));
                }
            }
            else
            {
                string error = "Debe Inciar Sesión";
                Response.Redirect(string.Format("login.aspx?error={0}", error));
            }            
        }

        protected string GetMarkers(string Lat, string Lon)
        {
            string markers = "";

            float latitude = float.Parse(Lat);
            float longitude = float.Parse(Lon);
            string NombreProveedor = "NOMBRE ";

            for (var i = 0; i < 10; i++)
            {
                i++;
                markers +=
                @"var marker = new google.maps.Marker({
        position: new google.maps.LatLng(" + Lat + ", " +
                Lon+ ")," +
                @"map: myMap,
        title:'" + NombreProveedor + "'});";
            }

            return markers;
        }
    }
}