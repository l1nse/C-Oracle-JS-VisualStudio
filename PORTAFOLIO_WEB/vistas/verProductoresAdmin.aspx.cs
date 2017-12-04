using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class verProductoresAdmin : System.Web.UI.Page
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
                    if (_usuario.TIPOUSUARIO == 3)
                    {
                        GridView1.DataSource = bdd.SELECTPRODUCTORESADM();
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
                Filtrar();
            }else
            {
                GridView1.DataSource = bdd.SELECTPRODUCTORESADM();
                GridView1.DataBind();
            }
            
        }

        private void Filtrar()
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();


            string _respuesta = txtBuscar.Text;

            if (RadioButton1.Checked == true)
            {
                if (bdd.SELECTPRODUCTORESADMRUT(_respuesta).Count() > 0)
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTPRODUCTORESADMRUT(_respuesta);
                    GridView1.DataBind();
                }
                else
                {
                    Label1.Text = "No se encontro un productor con ese rut";
                }
            }
            else if (RadioButton2.Checked == true)
            {
                if (bdd.SELECTPRODUCTORESADMCOMUNA(_respuesta).Count() > 0)
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTPRODUCTORESADMCOMUNA(_respuesta);
                    GridView1.DataBind();
                }
                else
                {
                    Label1.Text = "No se encontraron productores con esa comuna";
                }
            }
            else if (RadioButton3.Checked == true)
            {
                if (bdd.SELECTPRODUCTORESADMPROVINCIA(_respuesta).Count() > 0)
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTPRODUCTORESADMPROVINCIA(_respuesta);
                    GridView1.DataBind();
                }else
                {
                    Label1.Text = "No se encontraron productores con esa Provincia";
                }
            }
        
            else if (RadioButton4.Checked == true)
            {
                if (bdd.SELECTPRODUCTORESADMREGION(_respuesta).Count() > 0)
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTPRODUCTORESADMREGION(_respuesta);
                    GridView1.DataBind();
                }else
                {
                    Label1.Text = "No se encontraron productores con esa Region";
                }

            }
        }

        protected void btnVolverP_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelAdministrador.aspx");
        }

        protected void Bloquear(object sender, GridViewSelectEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string rut = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            bdd.CUENTABLOQUEAR(rut);
            bdd.SubmitChanges();
            Response.Redirect("verProductoresAdmin.aspx");
        }

        protected void Activar(object sender, GridViewEditEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string rut = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            bdd.CUENTAACTIVAR(rut);
            bdd.SubmitChanges();
            Response.Redirect("verProductoresAdmin.aspx");
        }

        protected void DownGrade(object sender, GridViewDeleteEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string rut = GridView1.DataKeys[e.RowIndex].Value.ToString();
            bdd.CUENTADOWNGRADE(rut);
            bdd.SubmitChanges();
            Response.Redirect("verUsuarioAdmin.aspx");
        }
    }
}