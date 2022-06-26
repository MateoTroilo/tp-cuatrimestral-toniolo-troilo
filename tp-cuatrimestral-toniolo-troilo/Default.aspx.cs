using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_toniolo_troilo
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Usuarios usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                usuario = new Usuarios(txtEmail.Text, txtPassword.Text, 1);
                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("LoginExitoso.aspx", false); //no entiendo por que no hace esto
                }
                else
                {
                    Session.Add("error", "usero o pass incorrectos");
                    Response.Redirect("LoginError.aspx", false);
                }
                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                
            }
        }
    }
}