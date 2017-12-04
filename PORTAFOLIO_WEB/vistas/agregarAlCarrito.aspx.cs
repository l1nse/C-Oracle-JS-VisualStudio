using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class agregarAlCarro : System.Web.UI.Page
    {
        int stock = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            string rut = Context.Request.Params["rut"];
            string codproducto = Context.Request.Params["codproducto"];

            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 1)
                {

                    var q = bdd.SELECTAGREGARALCARRO(rut, Convert.ToInt32(codproducto));

                    foreach (var cadaConsulta in q)
                    {
                        Label1.Text = cadaConsulta.NOMBRE;
                        Label2.Text = cadaConsulta.VALOR.ToString();
                        Label3.Text = cadaConsulta.RUT;
                        stock = Convert.ToInt32(cadaConsulta.STOCK);
                        Label5.Text = cadaConsulta.STOCK.ToString();
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

        protected void ButtonCarrito_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(txtCarrito.Text) > 0)
            {
                PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
                USUARIO _usuario = (USUARIO)Session["Usuario"];

                DETALLEDOC _detalle = new DETALLEDOC();

                string rut = Context.Request.Params["rut"];
                string codproducto = Context.Request.Params["codproducto"];




                int _cantidad = Convert.ToInt32(txtCarrito.Text);
                int _idBoleta = 0;
                int _valorProd = 0;
                int _codigoProd = Convert.ToInt32(codproducto);
                int _idProductor = 0;

                var q = bdd.BUSCARVALORPRODUCTO(_codigoProd);
                foreach (var cadaConsulta in q)
                {
                    _valorProd = Convert.ToInt32(cadaConsulta.VALORPRODUCTO);
                }

                var w = bdd.BUSCARIDCARRITO(_usuario.IDUSUARIO.ToString());
                foreach (var cadaConsulta in w)
                {
                    _idBoleta = Convert.ToInt32(cadaConsulta.IDDOCUMENTO);
                }

                var p = bdd.BUSCARIDPRODUCTORPORRUT(rut);
                foreach (var cadaConsulta in p)
                {
                    _idProductor = Convert.ToInt32(cadaConsulta.IDUSUARIO);
                }


                if (txtCarrito.Text != "")
                {

                    if (bdd.IDCODBOLETACARRITODECOMPRA(_usuario.IDUSUARIO).Count() != 0)
                    {
                        if (stock < Convert.ToInt32(txtCarrito.Text))
                        {
                            Label6.Text = "El Provedor tiene menos stock que la cantidad solicitada";

                        }
                        else
                        {
                            if (bdd.ESTAENELCARRO(_idBoleta, Convert.ToInt32(codproducto), _idProductor).Count() == 0)
                            {
                                _detalle.CANTIDADPEDIDODETALLEDOC = _cantidad;
                                _detalle.VALORPRODDETALLEDOC = Convert.ToInt32(_valorProd);
                                _detalle.SUBTOTALPRODUCTODETALLEDOC = Convert.ToInt32(_valorProd * _cantidad);
                                _detalle.DOCUMENTOIDDOCUMENTO = Convert.ToInt32(_idBoleta);
                                _detalle.PRODUCTOIDPRODUCTO = Convert.ToInt32(_idProductor);
                                _detalle.USUARIOIDUSUARIO = _usuario.IDUSUARIO;
                                bdd.AGREGARALCARRO(_cantidad, _valorProd, _idBoleta, _codigoProd, _idProductor);
                                try
                                {
                                    bdd.SubmitChanges();
                                    Response.Redirect("carritoCompra.aspx");
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }

                            else
                            {
                                Label6.Text = "Este producto ya esta en el carrito";
                            }
                        }
                    }


                    else
                    {
                        bdd.CREARCARRITO(_usuario.IDUSUARIO);
                        var t = bdd.BUSCARIDCARRITO(_usuario.IDUSUARIO.ToString());
                        foreach (var cadaConsulta in t)
                        {
                            _idBoleta = Convert.ToInt32(cadaConsulta.IDDOCUMENTO);
                        }

                        _detalle.CANTIDADPEDIDODETALLEDOC = _cantidad;
                        _detalle.VALORPRODDETALLEDOC = Convert.ToInt32(_valorProd);
                        _detalle.SUBTOTALPRODUCTODETALLEDOC = Convert.ToInt32(_valorProd * _cantidad);
                        _detalle.DOCUMENTOIDDOCUMENTO = Convert.ToInt32(_idBoleta);
                        _detalle.PRODUCTOIDPRODUCTO = Convert.ToInt32(_idProductor);
                        _detalle.USUARIOIDUSUARIO = _usuario.IDUSUARIO;
                        if (stock < Convert.ToInt32(txtCarrito.Text))
                        {
                            Label6.Text = "El Provedor tiene menos stock que la cantidad solicitada";
                        }
                        else
                        {
                            bdd.AGREGARALCARRO(_cantidad, _valorProd, _idBoleta, _codigoProd, _idProductor);
                            try
                            {
                                bdd.SubmitChanges();

                                Response.Redirect("carritoCompra.aspx");
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }

                    }


                }
                else
                {
                    Label6.Text = "Ingrese una cantidad mayor a 0 al campo";
                }
            }
            else
            {
                Label6.Text = "Ingrese un numero mayor a 0";
            }
        }
    }
}          
 