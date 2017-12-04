using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class cancelarCierreCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 1)
                {
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            if (!TextBox1.Text.Equals(""))
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.CLAVEUSUARIO.Equals(TextBox1.Text))
                {
                    Response.Redirect("panelUsuario.aspx");
                }

            }
            else
            {
                Label1.Text = "Ingrese contraseña";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("cerrarCuenta.aspx");
        }
    }
}