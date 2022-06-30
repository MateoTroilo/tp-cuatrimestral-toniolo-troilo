using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_toniolo_troilo
{
    public partial class Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();
            dgvPacientes.DataSource = negocio.listar();
            dgvPacientes.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Nuevo-Paciente.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Nuevo-Paciente.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Nuevo-Paciente.aspx", false);
        }
    }

   

}