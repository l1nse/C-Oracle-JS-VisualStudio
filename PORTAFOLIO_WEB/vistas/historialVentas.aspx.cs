using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class historialVentas : System.Web.UI.Page
    {
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
                        var q = bdd.SELECHISTORIALDEVENTA(_usuario.IDUSUARIO);

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
                    if (bdd.SELECHISTORIALDEVENTAFECHA(f1, f2, _usuario.IDUSUARIO).Count() > 0)
                    {
                        Label1.Text = "";
                        GridView1.DataSource = bdd.SELECHISTORIALDEVENTAFECHA(f1, f2, _usuario.IDUSUARIO);
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "No se encuentran boletas en ese rango de fecha";
                        var q = bdd.SELECHISTORIALDEVENTA(_usuario.IDUSUARIO);

                        GridView1.DataSource = q;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    Label1.Text = "Ambas Fechas son obligatorias";
                }
            }
            else if (RadioButton2.Checked == true)
            {
                if (txtBoleta.Text != "")
                {
                    String _respuesta = txtBoleta.Text;
                    if (bdd.SELECHISTORIALDEVENTAPORID(Convert.ToInt32(_respuesta), _usuario.IDUSUARIO).Count() > 0)
                    {
                        Label1.Text = "";
                        GridView1.DataSource = bdd.SELECHISTORIALDEVENTAPORID(Convert.ToInt32(_respuesta), _usuario.IDUSUARIO);
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "No se encuentra una boleta con ese id";
                        var q = bdd.SELECHISTORIALDEVENTA(_usuario.IDUSUARIO);

                        GridView1.DataSource = q;
                        GridView1.DataBind();
                    }
                }
            }else
            {
                Label1.Text = "Ingrese un id para la busqueda";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelProductor.aspx");
        }

        protected void Seleccionar(object sender, GridViewSelectEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codboleta = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect(string.Format("detalleVentas.aspx?codboleta={0}", codboleta));
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Buscar();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            USUARIO _usuario = (USUARIO)Session["Usuario"];
            var q = bdd.SELECHISTORIALDEVENTA(_usuario.IDUSUARIO);

            GridView1.DataSource = q;
            GridView1.DataBind();
        }
    }
}