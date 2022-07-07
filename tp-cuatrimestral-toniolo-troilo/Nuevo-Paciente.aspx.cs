using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_toniolo_troilo
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string sex = null;
            Paciente paciente;
            PacienteNegocio negocio = new PacienteNegocio();
            if (femenino.Checked)
            {
                sex = "Femenino";
            }
            else if(masculino.Checked)
            {
                sex = "Masculino";
            }
            else if(otro.Checked)
            {
                sex = "Otro";
            }

            try
            {
                paciente = new Paciente(txtNombre.Text, txtApellido.Text, sex, DateTime.Parse(FechaNacimineto.Text), int.Parse(txtDNI.Text), txtEmail.Text, txtObraSocial.Text);
                negocio.Agregar(paciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}