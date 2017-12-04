using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;
using Newtonsoft.Json;

namespace PORTAFOLIO_WEB.vistas.Mapa
{
    public partial class mapa3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Geo> geo = new List<Geo>();
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            var q = bdd.GEOLOCSELECT();

            foreach (var cadaConsulta in q)
            {
                Geo g = new Geo();

                g.lat = Convert.ToString(cadaConsulta.LATITUDGEOLOC).Replace(',', '.');
                g.lng = Convert.ToString(cadaConsulta.LONGITUDGEOLOC).Replace(',', '.'); ;
                geo.Add(g);
            }
            string JSONE = JsonConvert.SerializeObject(geo);

            string final = JSONE.Replace('"', ' ');

            string finaldeverdad = final.Trim();

            Literal.Text = @"<script>
                       var neighborhoods = " + finaldeverdad + @";

                    var markers = [];
                    var map;

                    function initialize() {
                      map = new google.maps.Map(document.getElementById('map'), 
                      {
                        zoom: 12,
                        center: {lat: 52.520, lng: 13.410}
                      });
                      drop();
                    }
                    if (navigator.geolocation) {
                         navigator.geolocation.getCurrentPosition(function (position) {
                             initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                             map.setCenter(initialLocation);
                         });
                     }
                    function drop() {
                      clearMarkers();
                      for (var i = 0; i < neighborhoods.length; i++) {
                        addMarkerWithTimeout(neighborhoods[i], i * 200);
                      }
                    }

                    function addMarkerWithTimeout(position, timeout) {
                      window.setTimeout(function() {
                        markers.push(new google.maps.Marker({
                          position: position,
                          map: map,
                          animation: google.maps.Animation.DROP
                        }));
                      }, timeout);
                    }

                    function clearMarkers() {
                      for (var i = 0; i < markers.length; i++) {
                        markers[i].setMap(null);
                      }
                      markers = [];
                    }

                        </script>";
        }
    }
}

[Serializable]
public class Geo
{
    public string lat { get; set; }
    public string lng { get; set; }
}