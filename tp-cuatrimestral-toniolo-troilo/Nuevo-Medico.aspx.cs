using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_toniolo_troilo
{
    public partial class Nuevo_Medico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
        protected void btnSumarEsp_Click(object sender, EventArgs e)
        {
            string especialidades = ltsEspecialidades.Text.ToString();
            lblEspecialidades.Text = lblEspecialidades.Text + especialidades;
        }
        

    }
}