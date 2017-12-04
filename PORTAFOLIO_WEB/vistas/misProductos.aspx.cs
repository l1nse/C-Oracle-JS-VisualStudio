using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class misProductos : System.Web.UI.Page
    {
        PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            if (!IsPostBack)
            {
                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 2)
                    {
                        var q = bdd.MISPRODUCTO(_usuario.RUTUSUARIO);
                        foreach(var cadaconsulta in q)
                        {
                            if (cadaconsulta.Stock <= 0)
                            {

                                bdd.STOCKELIMINAR(cadaconsulta.CodStock);
                            }

                        }
                        var z = bdd.MISPRODUCTO(_usuario.RUTUSUARIO);
                        GridView1.DataSource = z;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelProductor.aspx");
        }

     

     

        protected void Eliminar(object sender, GridViewSelectEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            bdd.STOCKELIMINAR(Convert.ToInt32(codproducto));
            bdd.SubmitChanges();
            Response.Redirect("misProductos.aspx");
        }

        protected void Sumar(object sender, GridViewEditEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect(string.Format("sumarProductosProductor.aspx?codproducto={0}", codproducto));
        }

        protected void Restar(object sender, GridViewDeleteEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = GridView1.DataKeys[e.RowIndex].Value.ToString();
            Response.Redirect(string.Format("restarProductoProductor.aspx?codproducto={0}", codproducto));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            USUARIO _usuario = (USUARIO)Session["Usuario"];
            if (!txtBuscar.Text.Equals(""))
            {
                if (bdd.MISPRODUCTOSNOMBRE(txtBuscar.Text, _usuario.IDUSUARIO).Count() > 0)
                {
                    var q = bdd.MISPRODUCTOSNOMBRE(txtBuscar.Text, _usuario.IDUSUARIO);
                    GridView1.DataSource = q;
                    GridView1.DataBind();
                }
                else
                {
                    Label1.Text = "Producto no encontrado";
                    var q = bdd.MISPRODUCTO(_usuario.RUTUSUARIO);

                    GridView1.DataSource = q;
                    GridView1.DataBind();
                }

            }
            else
            {
                Label1.Text = "";
                var q = bdd.MISPRODUCTO(_usuario.RUTUSUARIO);

                GridView1.DataSource = q;
                GridView1.DataBind();
            }
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            USUARIO _usuario = (USUARIO)Session["Usuario"];
            if (txtBuscar.Text != "")
            {
                if (bdd.MISPRODUCTOSNOMBRE(txtBuscar.Text, _usuario.IDUSUARIO).Count() > 0)
                {
                    var q = bdd.MISPRODUCTOSNOMBRE(txtBuscar.Text, _usuario.IDUSUARIO);
                    GridView1.DataSource = q;
                    GridView1.DataBind();
                }else
                {
                    Label1.Text = "No se encontro ningun producto con ese nombre";
                    var q = bdd.MISPRODUCTO(_usuario.RUTUSUARIO);

                    GridView1.DataSource = q;
                    GridView1.DataBind();
                }
            }
            else
            {
                Label1.Text = "";
                var q = bdd.MISPRODUCTO(_usuario.RUTUSUARIO);

                GridView1.DataSource = q;
                GridView1.DataBind();
            }
            
        }
    }
}