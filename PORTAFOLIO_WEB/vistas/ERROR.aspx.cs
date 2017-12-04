using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class ERROR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 1 || _usuario.TIPOUSUARIO == 2 || _usuario.TIPOUSUARIO == 3)
                {
                    string error = Context.Request.Params["error"];
                    Label1.Text = error.ToString();
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