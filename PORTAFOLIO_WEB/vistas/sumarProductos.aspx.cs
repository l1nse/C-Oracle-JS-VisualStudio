using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    
    public partial class sumarProductos : System.Web.UI.Page
    {
        string stock = "";
        int cantidadActual = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codPedido = Context.Request.Params["codPedido"];

            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 1)
                {
                    string rutProductor = "";
                    var q = bdd.BUSCARRUTPORCODPEDIDO(Convert.ToInt32(codPedido));
                    foreach (var cadaConsulta in q)
                    {
                        rutProductor = cadaConsulta.RUTUSUARIO;
                    }

                    string idProductor = "";
                    var w = bdd.IDUSUARIOPORRUT(rutProductor);
                    foreach (var cadaConsulta in w)
                    {
                        idProductor = cadaConsulta.IDUSUARIO.ToString();
                    }

                    string idProducto = "";
                    var c = bdd.BUSCARIDPRODPORCODDETALLE(Convert.ToInt32(codPedido));
                    foreach (var cadaConsulta in c)
                    {
                        idProducto = cadaConsulta.PRODUCTOIDPRODUCTO.ToString();
                    }

                    
                    var x = bdd.BUSCARSTOCK(Convert.ToInt32(idProductor), Convert.ToInt32(idProducto));
                    foreach (var cadaConsulta in x)
                    {
                        stock = cadaConsulta.STOCKPRODUCTOPRODUCTOR.ToString();
                    }

                    var t = bdd.SELECTSUMAR(Convert.ToInt32(codPedido));
                    foreach (var cadaConsulta in t)
                    {
                        Label1.Text = cadaConsulta.NOMBREPRODUCTO;
                        Label2.Text = cadaConsulta.VALORPRODDETALLEDOC.ToString();
                        Label3.Text = rutProductor;
                        Label4.Text = stock;
                        Label5.Text = cadaConsulta.CANTIDADPEDIDODETALLEDOC.ToString();
                        cantidadActual = Convert.ToInt32(cadaConsulta.CANTIDADPEDIDODETALLEDOC);
                    }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codPedido = Context.Request.Params["codPedido"];
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int cantidadFinal = cantidadActual + cantidad;
            if (cantidadFinal <= Convert.ToInt32(stock)) 
            { 
                bdd.CARRITOSUMAR(Convert.ToInt32(codPedido), cantidad);
                bdd.SubmitChanges();
                Response.Redirect("carritoCompra.aspx");
            }else
            {
                Label6.Text = "El stock del productor no es suficiente";
            }
        }
        
    }
}