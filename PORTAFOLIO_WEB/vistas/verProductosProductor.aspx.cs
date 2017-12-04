using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class verProductosProductor : System.Web.UI.Page
    {
        PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 2)
                    {
                        var q = bdd.SELECTPRODUCTO2();

                        GridView1.DataSource = q;
                        GridView1.DataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelProductor.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!txtFiltarN.Text.Equals(""))
            {
                if (bdd.SELECTPRODUCTOSNOMBRE(txtFiltarN.Text).Count() > 0)
                {
                    var q = bdd.SELECTPRODUCTOSNOMBRE(txtFiltarN.Text);
                    GridView1.DataSource = q;
                    GridView1.DataBind();
                    Label1.Text = "";

                }
                else
                {
                    Label1.Text = "Producto no encontrado";
                }
            }
            else
            {
                Label1.Text = "";
            }
        }

        protected void grSeleccionar(object sender, GridViewSelectEventArgs e)
        {

            string codproducto = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect(string.Format("agregarAMisProductos.aspx?codproducto={0}", codproducto));

        }
    }
}