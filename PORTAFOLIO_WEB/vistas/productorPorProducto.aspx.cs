using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class productorPorProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = Context.Request.Params["id"];

            if (!IsPostBack)
            {
                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 1)
                    {
                        var w = bdd.SELECTPRODUCTOPORID(Convert.ToInt32(codproducto));
                        foreach (var cadaConsulta in w)
                        {
                            Label1.Text = cadaConsulta.NOMBREPRODUCTO;
                            Label2.Text = cadaConsulta.VALORPRODUCTO.ToString();
                        }

                        if (bdd.SELECTPRODUCTORPORPRODUCTO2(Convert.ToInt32(codproducto)).Count() > 0)
                        {
                            var q = bdd.SELECTPRODUCTORPORPRODUCTO2(Convert.ToInt32(codproducto));
                            GridView1.DataSource = q;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Label5.Text = "No hay productores que ofrescan este producto";
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
        }

        protected void Seleccionar(object sender, GridViewSelectEventArgs e)
        {
            string codproducto = Context.Request.Params["id"];
            string rut = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect(string.Format("agregarAlCarrito.aspx?rut={0}&codproducto={1}", rut, codproducto));
        }
    }
}