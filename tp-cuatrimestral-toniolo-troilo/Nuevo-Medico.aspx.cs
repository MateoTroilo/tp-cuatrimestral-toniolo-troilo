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
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            List<Especialidad> medicoEspecialidades = new List<Especialidad>();
            try
            {
                if (!IsPostBack)
                {
                    Session["medicoEspecialidades"] = medicoEspecialidades;
                    repEspecialidades.DataSource = medicoEspecialidades;
                    repEspecialidades.DataBind();
                    List<Especialidad> listaEspecialidades = negocio.listar();
                    Session["listaEspecialidades"] = listaEspecialidades;
                    ltsEspecialidades.DataSource = listaEspecialidades;
                    ltsEspecialidades.DataTextField = "Nombre";
                    ltsEspecialidades.DataValueField = "ID";
                    ltsEspecialidades.DataBind();

                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
            }


            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);

                MedicoNegocio MedNegocio = new MedicoNegocio();
                Medico medico = MedNegocio.Buscar(ID);

                txtNombre.Text = medico.Nombre;
                txtApellido.Text = medico.Apellido;
                txtDNI.Text = medico.DNI.ToString();
                txtEmail.Text = medico.Email;
                //       dD/mM/aaaa

                string aux = medico.FechaNacimiento.ToString().Substring(medico.FechaNacimiento.ToString().LastIndexOf("/")).TrimStart('/');
                string aaaa = aux.Substring(0, aux.LastIndexOf(" ") + 1).TrimEnd(' ');

                string aux1 = medico.FechaNacimiento.ToString().Substring(0, medico.FechaNacimiento.ToString().LastIndexOf("/") + 1);
                string mm = aux1.Substring(aux1.IndexOf("/")).TrimEnd('/').TrimStart('/');
                if (mm.Length == 1) { mm = "0" + mm; }

                string dd = medico.FechaNacimiento.ToString().Substring(0, medico.FechaNacimiento.ToString().IndexOf("/") + 1).TrimEnd('/');
                if (dd.Length == 1) { dd = "0" + dd; }

                Fecha.Text = aaaa + '-' + mm + '-' + dd;

                switch (medico.Sexo)
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
            Page.Validate();
            if(!Page.IsValid) return;

            Medico medico;
            MedicoNegocio negocio = new MedicoNegocio();

            List<Especialidad> medicoEspecialidades = new List<Especialidad>();
            medicoEspecialidades = (List<Especialidad>)Session["medicoEspecialidades"];


            string sex = null;
            List<Dias> listaDias = new List<Dias>();


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

            if (inlineCheckbox1.Checked)
            {
                listaDias.Add(Dias.Lunes);
            }
            if (inlineCheckbox2.Checked)
            {
                listaDias.Add(Dias.Martes);
            }
            if (inlineCheckbox3.Checked)
            {
                listaDias.Add(Dias.Miercoles);
            }
            if (inlineCheckbox4.Checked)
            {
                listaDias.Add(Dias.Jueves);
            }
            if (inlineCheckbox5.Checked)
            {
                listaDias.Add(Dias.Viernes);
            }
            if (inlineCheckbox6.Checked)
            {
                listaDias.Add(Dias.Sabado);
            }

            //for (int i = 0; i < listaDias.Count; i++)
            //{
            //    Response.Write(@"<script language='javascript'>alert('" + listaDias[i] + "')</script>");
            //}

            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    int HoraInicio = int.Parse(HorarioInicio.Text.ToString().Substring(0, HorarioInicio.Text.ToString().IndexOf(":") + 1).TrimEnd(':'));
                    int HoraFin = int.Parse(HorarioFin.Text.ToString().Substring(0, HorarioFin.Text.ToString().IndexOf(":") + 1).TrimEnd(':'));

                    medico = new Medico(txtNombre.Text, txtApellido.Text, sex, DateTime.Parse(Fecha.Text), int.Parse(txtDNI.Text), txtEmail.Text, HoraInicio, HoraFin, listaDias, medicoEspecialidades);
                    negocio.Modificar(medico);
                }

                else
                {
                    int HoraInicio = int.Parse(HorarioInicio.Text.ToString().Substring(0, HorarioInicio.Text.ToString().IndexOf(":") + 1).TrimEnd(':'));
                    int HoraFin = int.Parse(HorarioFin.Text.ToString().Substring(0, HorarioFin.Text.ToString().IndexOf(":") + 1).TrimEnd(':'));

                    medico = new Medico(txtNombre.Text, txtApellido.Text, sex, DateTime.Parse(Fecha.Text), int.Parse(txtDNI.Text), txtEmail.Text, HoraInicio, HoraFin, listaDias, medicoEspecialidades);
                    negocio.Agregar(medico);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;

            }

            Response.Write(@"<script language='javascript'>alert(' Agregado Correctamente ')</script>");

            Response.Redirect("Nuevo-Medico.aspx", false);
        }

        protected void btnSumarEsp_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ltsEspecialidades.SelectedItem.Value);
            if(((List<Especialidad>)Session["medicoEspecialidades"]).Find(x => x.ID == id) == null)
                ((List<Especialidad>)Session["medicoEspecialidades"]).Add(((List<Especialidad>)Session["listaEspecialidades"]).Find(x => x.ID == id));
            repEspecialidades.DataSource = (List<Especialidad>)Session["medicoEspecialidades"];
            repEspecialidades.DataBind();
        }

        protected void RestarEspecialidad_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            ((List<Especialidad>)Session["medicoEspecialidades"]).Remove(((List<Especialidad>)Session["listaEspecialidades"]).Find(x => x.ID == id));
            repEspecialidades.DataSource = (List<Especialidad>)Session["medicoEspecialidades"];
            repEspecialidades.DataBind();
        }
        protected void HorarioFin_OnTextChanged(object sender, EventArgs e)
        {
            int HoraInicio = int.Parse(HorarioInicio.Text.ToString().Substring(0, HorarioInicio.Text.ToString().IndexOf(":") + 1).TrimEnd(':'));
            int HoraFin = int.Parse(HorarioFin.Text.ToString().Substring(0, HorarioFin.Text.ToString().IndexOf(":") + 1).TrimEnd(':'));

            

            if (HoraInicio > HoraFin || HoraInicio == HoraFin) 
            {
                HorarioCheck.InnerText = "El horario seleccionado termina al dia siguiente!";
            }
            else
            {
                HorarioCheck.InnerText = " ";
            }
            
        }
    }
}