﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class editarCuentaProductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 2)
                {
                    Label1.Text = _usuario.RUTUSUARIO;
                    Label2.Text = _usuario.NOMBREUSUARIO;
                    Label3.Text = _usuario.APELLIDOPATERNOUSUARIO;
                    Label4.Text = _usuario.APELLIDOMATERNOUSUARIO;
                    Label5.Text = _usuario.CORREOUSUARIO;
                    Label6.Text = _usuario.TELEFONOUSUARIO.ToString();
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("cerrarCuentaProductor.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelProductor.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("cambiarContraseniaProductor.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("modificarProductor.aspx");
        }
    }
}