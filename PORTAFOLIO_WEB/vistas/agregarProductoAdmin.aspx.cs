using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class agregarProductoAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 3)
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            PRODUCTO _producto = new PRODUCTO();

            if ((!TextBox1.Text.Equals("")) && (!TextBox3.Text.Equals("")))
            {
                if (!TextBox3.Text.Equals("0"))
                {
                    _producto.NOMBREPRODUCTO = TextBox1.Text;
                    _producto.VALORPRODUCTO = Convert.ToInt32(TextBox3.Text);

                    bdd.INSERTARPRODUCTO(_producto.NOMBREPRODUCTO, "mentira", _producto.VALORPRODUCTO);
                    Label1.Text = "Producto agregado";
                    try
                    {
                        bdd.SubmitChanges();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }else
                {
                    Label1.Text = "el valor debe ser mayor a 0";
                }
            }
            else
            {
                Label1.Text = "Todos los campos son obligatorios";
            }
        }
    }
}