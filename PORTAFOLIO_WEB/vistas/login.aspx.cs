using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;
using System.Text.RegularExpressions;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string error = Context.Request.Params["error"];
            if (error != null)
            {
                Label1.Text = error.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Ingresar();
        }

        private void Ingresar()
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            USUARIO _usuario = new USUARIO();

            string rut = TextBox1.Text;
            string clave = TextBox2.Text;

            bdd.LOGIN(rut, clave);
            var q = from a in bdd.USUARIOs
                    where a.RUTUSUARIO == rut
                    select a;

            foreach (var consultaUsuario in q)
            {
                string a = consultaUsuario.RUTUSUARIO;
                string b = consultaUsuario.CLAVEUSUARIO;

                if (rut == a )
                {
                    if (clave == b)
                    {
                        if (valida.ValidaRut(TextBox1.Text))
                        {
                            _usuario.IDUSUARIO = consultaUsuario.IDUSUARIO;
                            _usuario.NOMBREUSUARIO = consultaUsuario.NOMBREUSUARIO;
                            _usuario.RUTUSUARIO = consultaUsuario.RUTUSUARIO;
                            _usuario.APELLIDOMATERNOUSUARIO = consultaUsuario.APELLIDOMATERNOUSUARIO;
                            _usuario.APELLIDOPATERNOUSUARIO = consultaUsuario.APELLIDOPATERNOUSUARIO;
                            _usuario.CORREOUSUARIO = consultaUsuario.CORREOUSUARIO;
                            _usuario.TELEFONOUSUARIO = consultaUsuario.TELEFONOUSUARIO;
                            _usuario.DESCRIPCIONUSUARIO = consultaUsuario.DESCRIPCIONUSUARIO;
                            _usuario.CLAVEUSUARIO = consultaUsuario.CLAVEUSUARIO;
                            _usuario.TIPOUSUARIO = consultaUsuario.TIPOUSUARIO;
                            _usuario.ESTADOUSUARIO = consultaUsuario.ESTADOUSUARIO;
                            _usuario.FOTOUSUARIO = consultaUsuario.FOTOUSUARIO;

                            Session["Usuario"] = _usuario;

                            int c = Convert.ToInt32(consultaUsuario.TIPOUSUARIO);
                            if (c == 1)
                            {
                                Response.Redirect("panelUsuario.aspx");
                            }
                            else if (c == 2)
                            {
                                Response.Redirect("panelProductor.aspx");
                            }
                            else if (c == 3)
                            {
                                Response.Redirect("panelAdministrador.aspx");
                            }
                        }
                        else
                        {
                            Label1.Text = "Debe ingresar un rut chileno";
                        }
                    }
                    else
                    {
                        Label1.Text = "Error De Contraseña";
                    }
                }
                else
                {
                    Label1.Text = "Error de Rut";
                }
            }

        }

        private class valida
        {
            public static bool ValidaRut(string rut)
            {
                rut = rut.Replace(".", "").ToUpper();
                Regex expresion = new Regex("^([0-9]+-[0-9K])$");
                string dv = rut.Substring(rut.Length - 1, 1);
                if (!expresion.IsMatch(rut))
                {
                    return false;
                }
                char[] charCorte = { '-' };
                string[] rutTemp = rut.Split(charCorte);
                if (dv != Digito(int.Parse(rutTemp[0])))
                {
                    return false;
                }
                return true;
            }

            public static string Digito(int rut)
            {
                int suma = 0;
                int multiplicador = 1;
                while (rut != 0)
                {
                    multiplicador++;
                    if (multiplicador == 8)
                        multiplicador = 2;
                    suma += (rut % 10) * multiplicador;
                    rut = rut / 10;
                }
                suma = 11 - (suma % 11);
                if (suma == 11)
                {
                    return "0";
                }
                else if (suma == 10)
                {
                    return "K";
                }
                else
                {
                    return suma.ToString();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("registar.aspx");
        }
    }
}