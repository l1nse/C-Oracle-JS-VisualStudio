using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class modificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 1)
                {
                    txtNombre.Text = _usuario.NOMBREUSUARIO;
                    txtRut.Text = _usuario.RUTUSUARIO;
                    txtApellidoP.Text = _usuario.APELLIDOPATERNOUSUARIO;
                    txtApellidoM.Text = _usuario.APELLIDOMATERNOUSUARIO;
                   // txtCorreo.Text = _usuario.CORREOUSUARIO;
                   // txtNumero.Text = _usuario.TELEFONOUSUARIO.ToString();

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
            Response.Redirect("panelUsuario.aspx");
        }

        protected void btnCorreo_Click(object sender, EventArgs e)
        {

            if (!txtCorreo.Text.Equals(""))
            {
                PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

                USUARIO _usuario = (USUARIO)Session["Usuario"];
                _usuario.CORREOUSUARIO = txtCorreo.Text;
                bdd.CUENTACORREO(_usuario.IDUSUARIO, txtCorreo.Text);
                
                try
                {
                    
                    bdd.SubmitChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }


                Label1.Text = "Correo Acutalizado";
            }
            else
            {
                Label1.Text = "Ingrese un correo para actualizar";
            }
        }

        protected void btnFono_Click(object sender, EventArgs e)
        {
            if (!txtNumero.Text.Equals(""))
            {
                PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

                USUARIO _usuario = (USUARIO)Session["Usuario"];
                _usuario.TELEFONOUSUARIO = Convert.ToInt32(txtNumero.Text);
                bdd.CUENTAFONO(_usuario.IDUSUARIO, Convert.ToInt32(txtNumero.Text));
                try
                {

                    bdd.SubmitChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }

                Label1.Text = "Telefono Acutalizado";
            }
            else
            {
                Label1.Text = "Ingrese un numero para actualizar";
            }
        }
    }
}