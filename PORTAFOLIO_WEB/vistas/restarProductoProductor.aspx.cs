using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class restarProductoProductor : System.Web.UI.Page
    {
        int stock = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = Context.Request.Params["codproducto"];

            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 2)
                {
                    var q = bdd.SELECTSUMARSTOCK(Convert.ToInt32(codproducto));
                    foreach (var cadaConsulta in q)
                    {
                        Label1.Text = cadaConsulta.NOMBREPRODUCTO;
                        Label2.Text = cadaConsulta.VALORPRODUCTO.ToString();
                        Label3.Text = cadaConsulta.STOCKPRODUCTOPRODUCTOR.ToString();
                        stock = Convert.ToInt32( cadaConsulta.STOCKPRODUCTOPRODUCTOR);

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
            if (txtCantidad.Text != "")
            {
                
                    PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
                    string codproducto = Context.Request.Params["codproducto"];
                    bdd.STOCKRESTAR(Convert.ToInt32(codproducto), Convert.ToInt32(txtCantidad.Text));
                    bdd.SubmitChanges();
                    Response.Redirect("misProductos.aspx");
                
            }
            else
            {
                Label10.Text = "Ingrese una cantidad";
            }
        }
    }
}