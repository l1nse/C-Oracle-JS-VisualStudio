using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PORTAFOLIOContext;

namespace PORTAFOLIO_WEB.vistas
{
    public partial class upGraderAdmin : System.Web.UI.Page
    {
        int idProd = 0;
        string RUTPROD = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();
            if ((USUARIO)Session["Usuario"] != null)
            {
                USUARIO _usuario = (USUARIO)Session["Usuario"];
                if (_usuario.TIPOUSUARIO == 3)
                {
                    string rut = Context.Request.Params["rut"];
                    var q = bdd.MOSTRARUSUARIORUT(rut);
                    foreach (var cadaConsulta in q)
                    {
                        idProd = Convert.ToInt32(cadaConsulta.ID);
                        txtIngresar0.Text = cadaConsulta.ID.ToString();
                        RUTPROD = cadaConsulta.RUT;
                        txtIngresar1.Text = cadaConsulta.RUT;
                        txtIngresar2.Text = cadaConsulta.NOMBRE;
                        txtIngresar3.Text = cadaConsulta.APATERNO;
                        txtIngresar4.Text = cadaConsulta.AMATERNO;
                        txtIngresar5.Text = cadaConsulta.TipoUsuario.ToString();

                        if (!IsPostBack)
                        {
                            
                            DropDownList1.DataSource = bdd.MOSTRARREGIONE();
                            DropDownList1.DataValueField = "IDREGION";
                            DropDownList1.DataTextField = "NOMBREREGION";
                            DropDownList1.DataBind();
                        }


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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("panelAdministrador.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            int idComuna = Convert.ToInt32(DropDownList3.SelectedValue);

            bdd.UBICACIONINSERT(idProd, txtIngresar13.Text, txtIngresar11.Text, txtIngresar12.Text, idComuna);
            
            int idubicacion = 0;
            var q = bdd.IDUBICACIONPORIDUSUA(idProd);

            foreach (var cadaConsulta in q)
            {
                idubicacion = Convert.ToInt32(cadaConsulta.IDUBICACION);
            }

            bdd.GEOLOCINSERT(txtIngresar9.Text, txtIngresar10.Text, idubicacion, idProd);

            bdd.CUENTAUPGRADE(RUTPROD);
            try
            {
                bdd.SubmitChanges();
                Label1.Text = "Cuenta Modificada";
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {


            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            

                string region = DropDownList1.SelectedValue;

                DropDownList2.DataSource = bdd.MOSTRARPROVINCIA(Convert.ToInt32(region));
                DropDownList2.DataValueField = "IDPROVINCIA";
                DropDownList2.DataTextField = "NOMBREPROVINCIA";
                DropDownList2.DataBind();
            


        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PORTAFOLIODataContext bdd = new PORTAFOLIODataContext();

            
                string provincia = DropDownList2.SelectedValue;

                DropDownList3.DataSource = bdd.MOSTRARCOMUNA(Convert.ToInt32(provincia));
                DropDownList3.DataValueField = "IDCOMUNA";
                DropDownList3.DataTextField = "NOMBRECOMUNA";
                DropDownList3.DataBind();
            
        }
    }
}