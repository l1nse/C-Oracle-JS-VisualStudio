using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class modificarProductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 2)
                {
                    txtRut.Text = _usuario.RUTUSUARIO;
                    txtNombre.Text = _usuario.NOMBREUSUARIO;
                    txtApellidoP.Text = _usuario.APELLIDOPATERNOUSUARIO;
                    txtApellidoM.Text = _usuario.APELLIDOMATERNOUSUARIO;
                    //txtCorreo.Text = _usuario.CORREOUSUARIO;
                    //txtNumero.Text = _usuario.TELEFONOUSUARIO.ToString();
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelProductor.aspx");
        }

        protected void btnCorreo_Click(object sender, EventArgs e)
        {
            if (!txtCorreo.Text.Equals(""))
            {
                Label1.Text = "";
                PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
                USUARIO _usuario = (USUARIO)Session["Usuario"];

                bdd.CUENTACORREO(_usuario.IDUSUARIO, txtCorreo.Text);
                try
                {
                    bdd.SubmitChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }

                bdd.CUENTACORREO(_usuario.IDUSUARIO, txtCorreo.Text);
                _usuario.CORREOUSUARIO = txtCorreo.Text;
                Label1.Text = "Correo Acutalizado : " + txtCorreo.Text;
            }
            else
                Label1.Text = "Campo correo obligatorio";
        }

        protected void btnFono_Click(object sender, EventArgs e)
        {
            if (!txtNumero.Text.Equals(""))
            {
                Label1.Text = "";
                PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

                USUARIO _usuario = (USUARIO)Session["Usuario"];

                bdd.CUENTAFONO(_usuario.IDUSUARIO, Convert.ToInt32(txtNumero.Text));

                try
                {
                    bdd.SubmitChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
                _usuario.TELEFONOUSUARIO = Convert.ToInt32(txtNumero.Text);
                Label1.Text = "Telefono Acutalizado" + txtNumero.Text;
            }
            else
            {
                Label1.Text = "Campo telefono obligatorio";         
            }
        }
    }
}