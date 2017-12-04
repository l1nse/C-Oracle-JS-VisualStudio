using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;
using Google.Maps;
using Google.Maps.StaticMaps;
using System.Net.Http;
using System.Xml.Linq;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class verProductores : System.Web.UI.Page
    {

        PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 1)
                    {
                        GridView1.DataSource = bdd.SELECTPRODUCTORE2();
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

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!txtBuscar.Text.Equals(""))
            {
                Buscarr();
            }
            else
            {
                Label1.Text = "";
                GridView1.DataSource = bdd.SELECTPRODUCTORE2();
                GridView1.DataBind();

            }
        }

        private void Buscarr()
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();


            string _respuesta = txtBuscar.Text;

            if (RadioButton1.Checked == true)
            {
                if (bdd.SELECTPRODUCTORESNOMBRE(_respuesta).Count() > 0)
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTPRODUCTORESNOMBRE(_respuesta);
                    GridView1.DataBind();
                }
                else
                {
                    Label1.Text = "No se encontraron productores con ese nombre";
                    GridView1.DataSource = bdd.SELECTPRODUCTORE2();
                    GridView1.DataBind();
                }
            }
            else if (RadioButton2.Checked == true)
            {
                if (bdd.SELECTPRODUCTORESCOMUNA(_respuesta).Count() > 0)
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTPRODUCTORESCOMUNA(_respuesta);
                    GridView1.DataBind();
                }
                else
                {
                    Label1.Text = "No se encontraron productores con esa comuna";
                    GridView1.DataSource = bdd.SELECTPRODUCTORE2();
                    GridView1.DataBind();
                }
            }
            else if (RadioButton3.Checked == true)
            {
                if (bdd.SELECTPRODUCTORESPROVINCIA(_respuesta).Count() > 0)
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTPRODUCTORESPROVINCIA(_respuesta);
                    GridView1.DataBind();
                }else
                {
                    Label1.Text = "No se encontraron productores con esa provincia";
                    GridView1.DataSource = bdd.SELECTPRODUCTORE2();
                    GridView1.DataBind();
                }
            }
            else if (RadioButton4.Checked == true)
            {
                if (bdd.SELECTPRODUCTORESREGION(_respuesta).Count() > 0)
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTPRODUCTORESREGION(_respuesta);
                    GridView1.DataBind();
                }else
                {
                    Label1.Text = "No se encontraron productores con esa region";
                    GridView1.DataSource = bdd.SELECTPRODUCTORE2();
                    GridView1.DataBind();
                }
            }
            else
            {
                Label1.Text = "Productor no existe.";
            }
        }

        protected void btnVolverP_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelUsuario.aspx");
        }

        protected void gr_Seleccionar(object sender, GridViewSelectEventArgs e)
        {
            string rut = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect(string.Format("informacionProductorProductos.aspx?rut={0}", rut));
        }

        protected void Mapa(object sender, GridViewDeleteEventArgs e)
         {
            string rut = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string vtn = string.Format( "window.open('Mapa/mapa.aspx?rut={0}','Dates','scrollbars=yes,resizable=yes','height=500px', 'width=500px')",rut);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}