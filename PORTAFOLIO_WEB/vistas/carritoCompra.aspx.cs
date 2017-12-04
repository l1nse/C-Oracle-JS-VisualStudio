using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;
using System.Collections;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class carritoCompra : System.Web.UI.Page
    {
        int cod_boleta = 0;
        PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
        protected void Page_Load(object sender, EventArgs e)

        {

            if (!IsPostBack)
            {
                if ((USUARIO)Session["Usuario"] != null)
                {
                    USUARIO _usuario = (USUARIO)Session["Usuario"];
                    if (_usuario.TIPOUSUARIO == 1)
                    {
                        string _respuesta = Context.Request.Params["_respuesta"];
                        int id = Convert.ToInt32(_usuario.IDUSUARIO);


                        var q = bdd.IDCODBOLETACARRITODECOMPRA(id);

                        if (q.Count() != 0)
                        {
                            var w = bdd.IDCODBOLETACARRITODECOMPRA(id);
                            foreach (var consulta in w)
                            {
                                cod_boleta = Convert.ToInt32(consulta.IDDOCUMENTO);
                            }

                            if (bdd.CARRITODECOMPRA(cod_boleta).Count() != 0)
                            {



                                if (bdd.DETALLESENCERO(cod_boleta).Count() != 0)
                                {
                                    var a = bdd.DETALLESENCERO(cod_boleta);
                                    foreach (var cadaconsulta in a)
                                    {
                                        bdd.CARRITOELIMINAR(cadaconsulta.IDDETALLEDOC);
                                    }
                                    Response.Redirect("carritoCompra.aspx");
                                }

                                GridView1.DataSource = bdd.CARRITODECOMPRA(cod_boleta);
                                GridView1.DataBind();
                            }
                            else
                            {
                                Label1.Text = "Carrito vacio";
                            }
                        }
                        else if (_respuesta != null)
                        {
                            Label1.Text = _respuesta;
                        }
                        else
                        {
                            Label1.Text = "Carrito vacio";
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

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("panelUsuario.aspx");
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            USUARIO _usuario = (USUARIO)Session["Usuario"];
            var w = bdd.IDCODBOLETACARRITODECOMPRA(_usuario.IDUSUARIO);
            foreach (var consulta in w)
            {
                cod_boleta = Convert.ToInt32(consulta.IDDOCUMENTO);
            }

            if (bdd.CARRITODECOMPRA(cod_boleta).Count() != 0)
            {
                Comprar();
            }else
            {
                Label1.Text = "Carrito Vacio";

            }
        }

        private void Comprar()
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            USUARIO _usuario = (USUARIO)Session["Usuario"];
            int codboleta = 0;
            int sePuede = 1;


            
            var w = bdd.IDCODBOLETACARRITODECOMPRA(_usuario.IDUSUARIO);
            foreach (var cadaConsulta in w)
            {
                codboleta = Convert.ToInt32(cadaConsulta.IDDOCUMENTO);
            }


            var a = bdd.QUIENESNOPUEDEN(codboleta);
            if (a.Count() > 0)
            {
                sePuede = 0;
            }

            var q = bdd.SELECTCOMPRAR(codboleta);
            if (sePuede == 1)
            {
                foreach (var cadaConsulta in q)
                {
                    bdd.COMPRARRESTARSTOCK(cadaConsulta.CANTIDADPEDIDODETALLEDOC, cadaConsulta.PRODUCTOIDPRODUCTO, cadaConsulta.USUARIOIDUSUARIO);
                    try
                    {
                        bdd.SubmitChanges();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                }
                bdd.COMPRARBOLETA(codboleta);
                try
                {

                    bdd.SubmitChanges();
                    string _respuesta = "Compra Exitosa";
                    Response.Redirect(string.Format("carritoCompra.aspx?_respuesta={0}", _respuesta));
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                GridView2.DataSource = bdd.QUIENESNOPUEDEN(codboleta);
                GridView2.DataBind();
                Label1.Text = "Un productor no tiene suficiente stock";
            }
        }

        protected void Eliminar(object sender, GridViewSelectEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string cod = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            bdd.CARRITOELIMINAR(Convert.ToInt32(cod));
            bdd.SubmitChanges();
            Response.Redirect("carritoCompra.aspx");
        }

        protected void Sumar(object sender, GridViewEditEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codPedido = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect(string.Format("sumarProductos.aspx?codPedido={0}", codPedido));
        }

        protected void Restar(object sender, GridViewDeleteEventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string codPedido = GridView1.DataKeys[e.RowIndex].Value.ToString();
            Response.Redirect(string.Format("restarProducto.aspx?codPedido={0}", codPedido));

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            USUARIO _usuario = (USUARIO)Session["Usuario"];
            string nombre = txtCCarrito.Text;
            var w = bdd.IDCODBOLETACARRITODECOMPRA(_usuario.IDUSUARIO);
            foreach (var consulta in w)
            {
                cod_boleta = Convert.ToInt32(consulta.IDDOCUMENTO);
            }

            if (bdd.CARRITODECOMPRA(cod_boleta).Count() != 0)
            {

                if (bdd.CARRITODECOMPRANOMBRE(cod_boleta, nombre).Count() != 0)
                {
                    if (nombre.Equals(""))
                    {
                        Label1.Text = "";
                        GridView1.DataSource = bdd.CARRITODECOMPRA(cod_boleta);
                        GridView1.DataBind();
                        Label1.Text = "Ingrese un nombre de un producto en el campo";

                    }
                    else
                    {
                        Label1.Text = "";
                        GridView1.DataSource = bdd.CARRITODECOMPRANOMBRE(cod_boleta, nombre);
                        GridView1.DataBind();
                    }
                }
                else
                {
                    GridView1.DataSource = bdd.CARRITODECOMPRA(cod_boleta);
                    GridView1.DataBind();
                    Label1.Text = "No se econtraron productos";
                }
            }
            else
            {
                Label1.Text = "Carrito vacio";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}