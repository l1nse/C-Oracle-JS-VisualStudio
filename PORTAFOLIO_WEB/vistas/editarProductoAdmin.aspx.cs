using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class editarProductoAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
                string codproducto = Context.Request.Params["codproducto"];

                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 3)
                    {
                        var q = bdd.SELECTUPDATEPRODUCTO(Convert.ToInt32(codproducto));
                        foreach (var cadaConsulta in q)
                        {
                            Label1.Text = cadaConsulta.IDPRODUCTO.ToString();
                            Label2.Text = cadaConsulta.NOMBREPRODUCTO;
                            TextBox1.Text = cadaConsulta.VALORPRODUCTO.ToString();
                            Label5.Text = cadaConsulta.ESTADOPRODUCTO;
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
        }

        protected void btnAcualizar_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = Context.Request.Params["codproducto"];
            string valor = TextBox1.Text;

            bdd.PRODUCTOVALOR(Convert.ToInt32(codproducto), Convert.ToInt32(valor));
            bdd.SubmitChanges();
            Label6.Text = "Valor actualizado";
        }

        protected void btnAcualizar2_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = Context.Request.Params["codproducto"];
            string valor = TextBox1.Text;

            bdd.PRODUCTODESCRIPCION(Convert.ToInt32(codproducto), valor);
            bdd.SubmitChanges();
            Response.Redirect("verProductosProdAdmin.aspx");
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            Response.Redirect("verProductosProdAdmin.aspx");
        }
    }
}