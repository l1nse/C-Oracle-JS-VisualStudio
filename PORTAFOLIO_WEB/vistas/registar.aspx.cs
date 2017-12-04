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
    public partial class registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string _respuesta = string.Empty;
            _respuesta = Guardar();
            if (valida.ValidaRut(TextBox1.Text))
            {
                Limpiar();
                lblRespuesta.Text = _respuesta;
            }
            else
            {
                lblRespuesta.Text = _respuesta;
            }
            
        }

        private void Limpiar()
        {
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.TextBox6.Text = "";
            this.TextBox7.Text = "";

        }

        private string Guardar()
        {
            string r = string.Empty;
            string _respuesta = lblRespuesta.Text;
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            USUARIO _registrar = new USUARIO();

            if (valida.ValidaRut(TextBox1.Text))
            {
                int p = bdd.SELECTUSUARIOSADMRUT(TextBox1.Text).Count();
                if ((p == 0))
                {
                    _registrar.RUTUSUARIO = TextBox1.Text;
                    _registrar.NOMBREUSUARIO = TextBox2.Text;
                    _registrar.APELLIDOPATERNOUSUARIO = TextBox3.Text;
                    _registrar.APELLIDOMATERNOUSUARIO = TextBox4.Text;
                    _registrar.CORREOUSUARIO = TextBox5.Text;

                    if (TextBox6.Text.Equals(""))
                    {
                        _registrar.TELEFONOUSUARIO = 0;
                    }
                    else
                    {
                        _registrar.TELEFONOUSUARIO = Convert.ToInt32(TextBox6.Text);
                    }
                    _registrar.CLAVEUSUARIO = TextBox7.Text;


                    bdd.INSERTUSUARIO(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, Convert.ToInt32(TextBox6.Text), TextBox7.Text, 1, "1");
                    try
                    {
                        bdd.SubmitChanges();
                        _respuesta = "Usuario Registrado";
                        r = _respuesta;
                    }
                    catch (Exception)
                    {

                        _respuesta = "Error al Registrar Usuario";
                        r = _respuesta;
                    }
                }
                else
                {
                    _respuesta = "Lo sentimos este rut ya esta registrado";
                    r = _respuesta; 
                }
            }
            else
            {
                this.lblRespuesta.Text = "Debe ingresar un rut chileno";
                r = "Debe ingresar un rut chileno";
            }

            return r;
            
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
            Response.Redirect("login.aspx");
        }


    }
}