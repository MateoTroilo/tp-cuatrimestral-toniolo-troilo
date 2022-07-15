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

            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes estar logueado para ingresar a esta pantalla.");
                Response.Redirect("error.aspx", false);
                return;
            }

            if (((Usuarios)Session["usuario"]).TipoUsuario == TipoUsuario.MEDICO)
            {
                Session.Add("error", "No tienes permisos para ingresar a esta pantalla.");
                Response.Redirect("error.aspx", false);
                return;
            }


            if (Request.QueryString["ID"] != null)
            { 
                int ID = Int32.Parse(Request.QueryString["ID"]);

                PacienteNegocio negocio = new PacienteNegocio();
                Paciente paciente = negocio.Buscar(ID);

                txtNombre.Text = paciente.Nombre;
                txtApellido.Text = paciente.Apellido;
                txtDNI.Text = paciente.DNI.ToString();
                txtEmail.Text = paciente.Email;
                txtObraSocial.Text = paciente.ObraSocial;
                //       dD/mM/aaaa

                string aux = paciente.FechaNacimiento.ToString().Substring(paciente.FechaNacimiento.ToString().LastIndexOf("/")).TrimStart('/');
                string aaaa = aux.Substring(0, aux.LastIndexOf(" ") + 1).TrimEnd(' ');

                string aux1 = paciente.FechaNacimiento.ToString().Substring(0, paciente.FechaNacimiento.ToString().LastIndexOf("/") + 1);
                string mm = aux1.Substring(aux1.IndexOf("/")).TrimEnd('/').TrimStart('/');
                if (mm.Length == 1) { mm = "0" + mm; }

                string dd = paciente.FechaNacimiento.ToString().Substring(0, paciente.FechaNacimiento.ToString().IndexOf("/") + 1).TrimEnd('/'); 
                if(dd.Length == 1) { dd = "0" + dd; }

                FechaNacimineto.Text = aaaa + '-' + mm + '-' + dd;

                switch (paciente.Sexo)
                {
                    case "Female":
                        femenino.Checked = true;
                        break;
                    case "Male":
                        masculino.Checked = true;
                        break;
                    default:
                        break;
                }
            }
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
            else if (masculino.Checked)
            {
                sex = "Masculino";
            }
            else if (otro.Checked)
            {
                sex = "Otro";
            }

            try
            {
                if(Request.QueryString["ID"] != null)
                {
                    paciente = new Paciente(txtNombre.Text, txtApellido.Text, sex, DateTime.Parse(FechaNacimineto.Text), int.Parse(txtDNI.Text), txtEmail.Text, txtObraSocial.Text);
                    negocio.Modificar(paciente);
                }
                else
                {
                    paciente = new Paciente(txtNombre.Text, txtApellido.Text, sex, DateTime.Parse(FechaNacimineto.Text), int.Parse(txtDNI.Text), txtEmail.Text, txtObraSocial.Text);
                    negocio.Agregar(paciente);
                }
                
            }
            catch (Exception ex)
            {
                    throw ex;

            }
        }
    }
}