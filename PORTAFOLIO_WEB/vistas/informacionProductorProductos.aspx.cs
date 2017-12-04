using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class informacionProductorProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
                string rut = Context.Request.Params["rut"];

                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];

                    if (!IsPostBack)
                    {
                        if (_usuario.TIPOUSUARIO == 1)
                        {
                            var q = bdd.SELECTUSUARIOBYRUT(rut);

                            foreach (var cadaConsulta in q)
                            {

                                Label1.Text = cadaConsulta.RUT;
                                Label2.Text = cadaConsulta.NOMBRE;
                                Label3.Text = cadaConsulta.APATERNO;
                                Label4.Text = cadaConsulta.AMATERNO;
                                Label5.Text = cadaConsulta.CORREO;
                                Label6.Text = cadaConsulta.FONO.ToString();
                                Label7.Text = cadaConsulta.COMUNA;
                                Label8.Text = cadaConsulta.PROVINCIA;
                                Label9.Text = cadaConsulta.REGION;
                            }
                            if (bdd.MISPRODUCTOSUSUARIO(rut).Count() > 0)
                            {
                                var w = bdd.MISPRODUCTOSUSUARIO(rut);

                                GridView1.DataSource = w;
                                GridView1.DataBind();
                            }
                            else
                                Label20.Text = "Actualmente este productor no tiene Stock disponible";
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
            
        }

        protected void grAgregar(object sender, GridViewSelectEventArgs e)
        {
            string rut = Context.Request.Params["rut"];
            string codProducto = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect(string.Format("agregarAlCarrito.aspx?codProducto={0}&rut={1}", codProducto, rut)); 
        }
    }
}