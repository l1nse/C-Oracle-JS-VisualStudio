using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class verProductosProdAdmin : System.Web.UI.Page
    {
        PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 3)
                    {
                        GridView1.DataSource = bdd.SELECTPRODUCTOSADM();
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

        protected void btnVolverF_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelAdministrador.aspx");
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!txtFiltrar.Text.Equals(""))
            {
                Filtrar();
            }else
            {
                GridView1.DataSource = bdd.SELECTPRODUCTOSADM();
                GridView1.DataBind();
            }
        }

        private void Filtrar()
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            string _producto = txtFiltrar.Text;

            if (bdd.SELECTPRODUCTOSADMNOMBRE(_producto).Count() > 0)
            {
                Label1.Text = "";
                GridView1.DataSource = bdd.SELECTPRODUCTOSADMNOMBRE(_producto);
                GridView1.DataBind();
            }
            else
            {
                Label1.Text = "El producto no existe";
            }
        }

        protected void Seleccionar(object sender, GridViewSelectEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            bdd.PRODUCTOACTIVAR(Convert.ToInt32( codproducto));
            bdd.SubmitChanges();
            Response.Redirect("verProductosProdAdmin.aspx");
        }

        protected void Bloquear(object sender, GridViewDeleteEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codproducto = GridView1.DataKeys[e.RowIndex].Value.ToString();
            bdd.PRODUCTOBLOQUEAR(Convert.ToInt32(codproducto));
            bdd.SubmitChanges();
            Response.Redirect("verProductosProdAdmin.aspx");
        }

        protected void Editar(object sender, GridViewEditEventArgs e)
        {
            string codproducto = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect(string.Format("editarProductoAdmin.aspx?codproducto={0}", codproducto));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregarProductoAdmin.aspx");
        }
    }
}