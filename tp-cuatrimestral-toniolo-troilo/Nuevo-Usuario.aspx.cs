using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_toniolo_troilo
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes estar logueado para ingresar a esta pantalla.");
                Response.Redirect("error.aspx", false);
                return;
            }

            if (((Usuarios)Session["usuario"]).TipoUsuario != TipoUsuario.ADMIN)
            {
                Session.Add("error", "No tienes permisos para ingresar a esta pantalla.");
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}