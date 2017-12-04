using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class panelUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            if ((USUARIO)Session["Usuario"] != null)
            {                
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 1 || _usuario.ESTADOUSUARIO == "1")
                {
                    Label1.Text = _usuario.NOMBREUSUARIO;
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
            Response.Redirect("editarCuenta.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("verProductores.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("verProductos.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("carritoCompra.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("historialCompras.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Response.Redirect("login.aspx");
        }

        protected void btnMapa_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('Mapa/mapa3.aspx','Dates','scrollbars=yes,resizable=yes','height=100', 'width=100')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }
    }
}