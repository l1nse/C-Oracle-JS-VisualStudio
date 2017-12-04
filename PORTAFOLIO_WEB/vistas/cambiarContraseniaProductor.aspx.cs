using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class cambiarContraseniaProductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 2)
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
            USUARIO _usuario = (USUARIO)Session["Usuario"];
            if (txtCActual.Text != "" && txtCNueva.Text != "" && txtConfirmarCNueva.Text != "")
            {
                if (_usuario.CLAVEUSUARIO == txtCActual.Text)
                {
                    if (txtCNueva.Text == txtConfirmarCNueva.Text)
                    {
                        bdd.CUENTACLAVE(_usuario.IDUSUARIO, txtCNueva.Text);
                        try
                        {
                            _usuario.CLAVEUSUARIO = txtCNueva.Text;
                            bdd.SubmitChanges();
                            Label1.Text = "Contraseña Actualizada";
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                    }
                }
                else
                {
                    Label1.Text = "Contraseña actual incorrecta";
                }
            }else
            {
                Label1.Text = "Todos los campos son obligatorios";

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelProductor.aspx");
        }
    }
}