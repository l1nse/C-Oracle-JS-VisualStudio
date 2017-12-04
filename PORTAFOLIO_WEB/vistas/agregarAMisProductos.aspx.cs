using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class agregarAMisProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = Context.Request.Params["codproducto"];

            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 2)
                {
                    var q = bdd.SELECPRODUCTOPORID(Convert.ToInt32(codproducto));
                    foreach (var cadaConsulta in q)
                    {
                        Label1.Text = cadaConsulta.NOMBREPRODUCTO;
                        Label2.Text = cadaConsulta.VALORPRODUCTO.ToString();
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
            Response.Redirect("verProductosProductor.aspx");
        }

        protected void ButtonCarrito_Click(object sender, EventArgs e)
        {
            string text = txtCarrito.Text;

            if (!txtCarrito.Text.Equals(""))
            {
                

                if (!txtCarrito.Text.Equals("0"))
                {
                    PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
                    string codproducto = Context.Request.Params["codproducto"];
                    USUARIO _usuario = (USUARIO)Session["Usuario"];

                    if (bdd.ESTAENELSTOCK(Convert.ToInt32(codproducto), _usuario.IDUSUARIO).Count() == 0)
                    {
                        bdd.INSERTPRODUCTOPRODUCTOR(Convert.ToInt32(txtCarrito.Text), _usuario.IDUSUARIO, Convert.ToInt32(codproducto));
                        try
                        {
                            bdd.SubmitChanges();
                            Response.Redirect("misProductos.aspx");
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                    }
                    else
                    {
                        Label7.Text = "Este producto ya esta en sus productos";
                    }
                }
                else
                {
                    Label7.Text = "Debe ingresar una cantidad mayor a 0";
                }
            }
            else
            {
                Label7.Text = "campo cantidad obligatorio";
            }

        }
    }
}