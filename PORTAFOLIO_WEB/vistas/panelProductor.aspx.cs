using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class panelProductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 2 || _usuario.ESTADOUSUARIO == "1")
                {
                    Label2.Text = _usuario.NOMBREUSUARIO;
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
            Response.Redirect("editarCuentaProductor.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("verProductosProductor.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("historialVentas.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Response.Redirect("login.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("misProductos.aspx");
        }
    }
}