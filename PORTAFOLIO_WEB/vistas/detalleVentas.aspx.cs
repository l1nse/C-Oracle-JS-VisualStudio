using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class detalleVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codboleta = Context.Request.Params["codboleta"];

            if (!IsPostBack)
            {
                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 2)
                    {
                        var q = bdd.SELECTDETALLEBOLETA2(Convert.ToInt32(codboleta));
                        foreach (var cadaConsulta in q)
                        {
                            Label1.Text = cadaConsulta.IDDOCUMENTO.ToString();
                            Label2.Text = cadaConsulta.FECHADOCUMENTO.ToShortDateString();
                            Label3.Text = cadaConsulta.RUTUSUARIO;
                            Label4.Text = cadaConsulta.VALORTOTALDOCUMENTO.ToString();
                        }

                        var w = bdd.SELECTDETBOLPROD(Convert.ToInt32(codboleta));
                        GridView1.DataSource = w;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("historialVentas.aspx");
        }
    }
}