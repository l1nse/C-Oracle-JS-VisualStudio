using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class verVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            if (!IsPostBack)
            {
                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 3)
                    {
                        var q = bdd.ADMHISTORIALVENTA();
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

        protected void Seleccionar(object sender, GridViewSelectEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codboleta = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect(string.Format("detalleBoletaAdmin.aspx?codboleta={0}", codboleta));
        }

        protected void txtBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();


            
            USUARIO _usuario = (USUARIO)Session["Usuario"];


            if (rbtFiltrarF.Checked == true)
            {
                if (inputf1.Value != "" && inputf2.Value != "")
                {


                    DateTime f1 = Convert.ToDateTime(inputf1.Value);
                    DateTime f2 = Convert.ToDateTime(inputf2.Value);
                    if (bdd.ADMHISTORIALVENTASFECHA(f1, f2).Count() > 0)
                    {
                        Label1.Text = "";
                        GridView1.DataSource = bdd.ADMHISTORIALVENTASFECHA(f1, f2);
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "No se encuentran boletas en ese rango de fecha";
                        var q = bdd.ADMHISTORIALVENTA();

                        GridView1.DataSource = q;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    Label1.Text = "Ambas fechas son obligatorias";
                }
            }
            else if (RadioButton2.Checked == true)
            {

                if (txtBoleta.Text != "")
                {
                    String _respuesta = txtBoleta.Text;
                    if (bdd.ADMHISTORIALVENTASPORID(Convert.ToInt32(_respuesta)).Count() > 0)
                    {
                        Label1.Text = "";
                        GridView1.DataSource = bdd.ADMHISTORIALVENTASPORID(Convert.ToInt32(_respuesta));
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "No se encuentra una boleta con ese id";
                        var q = bdd.ADMHISTORIALVENTA();

                        GridView1.DataSource = q;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    Label1.Text = "campo id obligatorio";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelAdministrador.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            var q = bdd.ADMHISTORIALVENTA();

            
            GridView1.DataSource = q;
            GridView1.DataBind();
        }
    }
}