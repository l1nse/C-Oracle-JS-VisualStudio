using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class verUsuarioAdmin : System.Web.UI.Page
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
                        GridView1.DataSource = bdd.SELECTUSUARIOSADM();
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
            Filtrarr();
        }

        private void Filtrarr()
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();


            string _respuesta = txtBuscar.Text;

            if (RadioButton1.Checked == true)
            {
                if (txtBuscar.Text != "")
                {
                    if (bdd.SELECTUSUARIOSADMRUT(_respuesta).Count() != 0)
                    {
                        Label1.Text = "";
                        GridView1.DataSource = bdd.SELECTUSUARIOSADMRUT(_respuesta);
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "Usuario no existe";
                    }
                }
                else
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTUSUARIOSADM();
                    GridView1.DataBind();
                }
                
                
            }
            else if (RadioButton2.Checked == true)
            {
                if (txtBuscar.Text != "")
                {
                    if (bdd.SELECTUSUARIOSADMNOMBRE(_respuesta).Count() != 0)
                    {
                        Label1.Text = "";
                        GridView1.DataSource = bdd.SELECTUSUARIOSADMNOMBRE(_respuesta);
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "Usuario no existe";
                    }
                }
                else
                {
                    Label1.Text = "";
                    GridView1.DataSource = bdd.SELECTUSUARIOSADM();
                    GridView1.DataBind();
                }
                    
            }
            else
            {
                Label1.Text = "Seleccione un filtro";
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
            Response.Redirect("verUsuarioAdmin.aspx");
        }

        protected void upGrade(object sender, GridViewEditEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string rut = GridView1.DataKeys[e.NewEditIndex].Value.ToString();            
            Response.Redirect(string.Format("upGraderAdmin.aspx?rut={0}", rut));
        }

        protected void Activar(object sender, GridViewDeleteEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string rut = GridView1.DataKeys[e.RowIndex].Value.ToString();
            bdd.CUENTAACTIVAR(rut);
            bdd.SubmitChanges();
            Response.Redirect("verUsuarioAdmin.aspx");
        }
    }
}