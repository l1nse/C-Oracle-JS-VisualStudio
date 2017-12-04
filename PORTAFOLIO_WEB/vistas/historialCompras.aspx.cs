using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class historialCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 1)
                    {
                        var q = bdd.HISTORIALDECOMPRA(_usuario.IDUSUARIO);

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
            Response.Redirect("panelUsuario.aspx");
        }

        

        

        protected void Seleccionar(object sender, GridViewSelectEventArgs e)
        {
            string codboleta = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect(string.Format("detalleBoleta.aspx?codboleta={0}", codboleta));
        }

        protected void rbtFiltrarF_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            USUARIO _usuario = (USUARIO)Session["Usuario"];

            string _respuesta = txtBoleta.Text;


            if (!IsPostBack)
            {
                if (rbtFiltrarF.Checked == true)
                {
                    DateTime f1 = Convert.ToDateTime(inputf1.Value);
                    DateTime f2 = Convert.ToDateTime(inputf2.Value);

                    GridView1.DataSource = bdd.HISTORIALDECOMPRAFECHA(f1, f2, _usuario.IDUSUARIO);
                    GridView1.DataBind();
                }
                else if (RadioButton2.Checked == true)
                {

                    GridView1.DataSource = bdd.HISTORIALDECOMPRAPORID(Convert.ToInt32(txtBoleta.Text), _usuario.IDUSUARIO);
                    GridView1.DataBind();
                }
            }


        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            USUARIO _usuario = (USUARIO)Session["Usuario"];
            var q = bdd.HISTORIALDECOMPRA(_usuario.IDUSUARIO);
            Label1.Text = "";
            GridView1.DataSource = q;
            GridView1.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            USUARIO _usuario = (USUARIO)Session["Usuario"];

            string _respuesta = txtBoleta.Text;



            if (rbtFiltrarF.Checked == true)
            {
                if (inputf1.Value != "" && inputf2.Value != "") 
                {
                    
                    DateTime f1 = Convert.ToDateTime(inputf1.Value);
                    DateTime f2 = Convert.ToDateTime(inputf2.Value);
                    if (bdd.HISTORIALDECOMPRAFECHA(f1, f2, _usuario.IDUSUARIO).Count() > 0)
                    {

                        Label1.Text = "";
                        GridView1.DataSource = bdd.HISTORIALDECOMPRAFECHA(f1, f2, _usuario.IDUSUARIO);
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "No se encontraron boletas en ese rango de fechas";
                       
                    }
                }
                else
                {
                    Label1.Text = "Ambas fechas son obligatorias";
                    var q = bdd.HISTORIALDECOMPRA(_usuario.IDUSUARIO);

                    GridView1.DataSource = q;
                    GridView1.DataBind();
                }
            }
            else if (RadioButton2.Checked == true)
            {
                if (txtBoleta.Text != "")
                { 

                    if (bdd.HISTORIALDECOMPRAPORID(Convert.ToInt32(txtBoleta.Text), _usuario.IDUSUARIO).Count() > 0)
                    {
                        Label1.Text = "";
                        GridView1.DataSource = bdd.HISTORIALDECOMPRAPORID(Convert.ToInt32(txtBoleta.Text), _usuario.IDUSUARIO);
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "No se encontro una boleta con ese codigo";
                    }
                }
                else
                {
                    Label1.Text = "Ingrese un codigo boleta";
                    var q = bdd.HISTORIALDECOMPRA(_usuario.IDUSUARIO);

                    GridView1.DataSource = q;
                    GridView1.DataBind();
                }
            }
                
        }
    }
}