using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class confirmarCierreCuenta : System.Web.UI.Page
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("cerrarCuenta.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            if (!txtIngrese.Text.Equals(""))
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.CLAVEUSUARIO.Equals(txtIngrese.Text))
                {
                    bdd.CUENTABLOQUEAR(_usuario.RUTUSUARIO);
                    try
                    {
                        Session.Remove("Usuario");


                        bdd.SubmitChanges();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                    Label2.Text = "Cuenta cerrada";
                    _usuario = null;

                }
                else
                {
                    Label2.Text = "Contraseña incorrecta";
                }

            }
            else
            {
                Label2.Text = "Ingrese contraseña";
            }
        }
        
    }
}