using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    
    public partial class verProductos : System.Web.UI.Page
    {
        PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

                if (!IsPostBack)
                {
                    if ((USUARIO)Session["Usuario"] != null)
                    {
                        USUARIO _usuario = (USUARIO)Session["Usuario"];
                        if (_usuario.TIPOUSUARIO == 1)
                        {
                            GridView1.DataSource = bdd.SELECTPRODUCTO2();
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
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelUsuario.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!txtFiltarN.Text.Equals(""))
            {
                if (bdd.SELECTPRODUCTOSNOMBRE(txtFiltarN.Text).Count() > 0)
                {
                    Label1.Text = "";
                    Buscar();
                }
                else
                {
                    Label1.Text = "No se encontraron productos";
                    GridView1.DataSource = bdd.SELECTPRODUCTO2();
                    GridView1.DataBind();
                }
            }else
            {
                Label1.Text = "";
                GridView1.DataSource = bdd.SELECTPRODUCTO2();
                GridView1.DataBind();
            }
        }

        private void Buscar()
        {

            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            string _respuesta = txtFiltarN.Text;

            if (txtFiltarN.Text != null)
            {
                GridView1.DataSource = bdd.SELECTPRODUCTOSNOMBRE(_respuesta);
                GridView1.DataBind();
            }
            else
            {
                Label1.Text = "El producto no existe";
            }

        }

        protected void grSeleccionar(object sender, GridViewSelectEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect(string.Format("productorPorProducto.aspx?id={0}", id));
        }
    }
}