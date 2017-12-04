using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class cambiarCuentaAVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 1)
                {
                    txtAsuntoC.Text = "Cambiar cuenta a vendedor";
                    txtNombreC.Text = _usuario.NOMBREUSUARIO;
                    txtAPaterno.Text = _usuario.APELLIDOPATERNOUSUARIO;
                    txtAMaterno.Text = _usuario.APELLIDOMATERNOUSUARIO;
                    txtFono.Text = _usuario.TELEFONOUSUARIO.ToString();
                    txtCorreoC.Text = _usuario.CORREOUSUARIO;

                    if (!IsPostBack)
                    {
                        DropDownList1.DataSource = bdd.MOSTRARREGIONE();
                        DropDownList1.DataValueField = "IDREGION";
                        DropDownList1.DataTextField = "NOMBREREGION";
                        DropDownList1.DataBind();
                    }
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
            EnvioCorreo();
        }

        private void EnvioCorreo()
        {
            try
            {
                SmtpClient clientSMTP = new SmtpClient("smtp.gmail.com", 587);
                clientSMTP.EnableSsl = true;
                clientSMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientSMTP.UseDefaultCredentials = false;
                clientSMTP.Credentials = new NetworkCredential("i.vasquezv7@gmail.com", "nashoactivao");
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress("i.vasquezv7@gmail.com");
                    message.Subject = this.txtAsuntoC.Text.ToString();
                    message.IsBodyHtml = true;
                    message.To.Add(this.txtCorreoC.Text.ToString());
                    message.Body = "Desea solicitado un cambio de perfil: \n\r" + "\n" +
                        "\r\n Nombre: " + this.txtNombreC.Text + "\n" +
                        "\n Apellido Paterno: " + this.txtAPaterno.Text + "\n" +
                        "\n Apellido Materno: " + this.txtAMaterno.Text + "\n" +
                        "\n Fono: " + this.txtFono.Text + "\n" +
                        "\n Correo: " + this.txtCorreoC.Text + "\n" +
                        "\n Dirección: " + this.txtDireccion.Text + "\n" +
                        "\n Latitud: " + this.txtLatitud.Text + "\n" +
                        "\n Longitud: " + this.txtLongitud.Text + "\n" +
                        "\n" +
                        "\n Saludos Atte: " + this.txtNombreC.Text;

                    clientSMTP.Send(message);
                }
            }
            catch (Exception)
            { }
            finally
            { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelUsuario.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();



            string region = DropDownList1.SelectedValue;

            DropDownList2.DataSource = bdd.MOSTRARPROVINCIA(Convert.ToInt32(region));
            DropDownList2.DataValueField = "IDPROVINCIA";
            DropDownList2.DataTextField = "NOMBREPROVINCIA";
            DropDownList2.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();


            string provincia = DropDownList2.SelectedValue;

            DropDownList3.DataSource = bdd.MOSTRARCOMUNA(Convert.ToInt32(provincia));
            DropDownList3.DataValueField = "IDCOMUNA";
            DropDownList3.DataTextField = "NOMBRECOMUNA";
            DropDownList3.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('Mapa/mapa2.aspx','Dates','scrollbars=yes,resizable=yes','height=100', 'width=100')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }
    }
}