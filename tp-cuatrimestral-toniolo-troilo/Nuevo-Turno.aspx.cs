using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace tp_cuatrimestral_toniolo_troilo
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio negocioEspecialidad = new EspecialidadNegocio();
            try
            {
                if (!IsPostBack)
                {
                    List<Especialidad> listaEspecialidades = negocioEspecialidad.listar();
                    ddlEspecialidad.DataSource = listaEspecialidades;
                    ddlEspecialidad.DataTextField = "Nombre";
                    ddlEspecialidad.DataValueField = "ID";
                    ddlEspecialidad.DataBind();

                    int id = int.Parse(ddlEspecialidad.SelectedItem.Value);
                    MedicoNegocio negocio = new MedicoNegocio();
                    List<Medico> medicos = negocio.ListarXEspecialidad(id);
                    var MedicoQuery = medicos.Select(medico => new { medicoId = medico.Id, medicoNombreCompleto = medico.Nombre + " " + medico.Apellido });
                    ddlMedico.DataSource = MedicoQuery;
                    ddlMedico.DataTextField = "medicoNombreCompleto";
                    ddlMedico.DataValueField = "medicoId";
                    ddlMedico.DataBind();

                    
                    llenarProximosTurnos();
                    Session.Add("flagTurnos", false);
                }
                if (Request.QueryString["ID"] != null)
                {
                    int ID = Int32.Parse(Request.QueryString["ID"]);

                    TurnosNegocio negocioTurnos = new TurnosNegocio();
                    Turno turno = negocioTurnos.Buscar(ID);
                    Session.Add("turno", turno);
                    PacienteNegocio negocioPaciente = new PacienteNegocio();
                    Paciente paciente = negocioPaciente.Buscar(int.Parse(turno.Paciente));
                    txtPaciente.Text = paciente.DNI.ToString();
                    txtPaciente_TextChanged(sender, e);
                    ddlEspecialidad.SelectedValue = turno.Especialidad;
                    string medicoID = turno.Medico;
                    int idEspecialidad = int.Parse(ddlEspecialidad.SelectedItem.Value);
                    MedicoNegocio negocio = new MedicoNegocio();
                    List<Medico> medicos = negocio.ListarXEspecialidad(idEspecialidad);
                    var MedicoQuery = medicos.Select(medico => new { medicoId = medico.Id, medicoNombreCompleto = medico.Nombre + " " + medico.Apellido });
                    ddlMedico.DataSource = MedicoQuery;
                    ddlMedico.DataTextField = "medicoNombreCompleto";
                    ddlMedico.DataValueField = "medicoId";
                    ddlMedico.DataBind();
                    ddlMedico.SelectedValue = medicoID;
                    Fecha.Text = turno.Fecha.ToString("yyyy-MM-dd");
                    string asd = turno.Fecha.ToString();
                    asd = turno.Fecha.Hour.ToString();
                    setearHoras();
                    ddlHorarios.SelectedValue = turno.Fecha.Hour.ToString();
                    txtObservaciones.Text = turno.Observacion;
                    //setearEstados();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void txtPaciente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dni = Int32.Parse(txtPaciente.Text);
                PacienteNegocio negocio = new PacienteNegocio();
                Paciente paciente = negocio.BuscarDNI(dni);
                if (paciente.Nombre == null)
                {
                    lblNombre.Text = "Paciente no encontrado.";
                    Session.Remove("paciente");
                }
                else
                {
                    Session.Add("paciente", paciente);
                    lblNombre.Text = paciente.Nombre + ' ' + paciente.Apellido;
                }
            }
            catch
            {
                Session.Remove("paciente");
                lblNombre.Text = "Ingrese un DNI válido.";
            }
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMedicoAnterior = int.Parse(ddlMedico.SelectedItem.Value);
            if (IsPostBack)
            {
                int id = int.Parse(ddlEspecialidad.SelectedItem.Value);
                MedicoNegocio negocio = new MedicoNegocio();
                List<Medico> medicos = negocio.ListarXEspecialidad(id);
                var MedicoQuery = medicos.Select(medico => new { medicoId = medico.Id, medicoNombreCompleto = medico.Nombre + " " + medico.Apellido });
                ddlMedico.DataSource = MedicoQuery;
                ddlMedico.DataTextField = "medicoNombreCompleto";
                ddlMedico.DataValueField = "medicoId";
                ddlMedico.DataBind();
                if(idMedicoAnterior != int.Parse(ddlMedico.SelectedItem.Value)) llenarProximosTurnos();
            }

        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarProximosTurnos();
        }

        protected void llenarProximosTurnos()
        {
            int id = int.Parse(ddlMedico.SelectedItem.Value);
            MedicoNegocio medicoNegocio = new MedicoNegocio();
            Medico medico = medicoNegocio.Buscar(id);
            Session.Add("medico", medico);
            List<int> dias = diasDeTrabajo();
            TurnosNegocio negocio = new TurnosNegocio();
            List<Turno> turnos = negocio.listar(id);
            List<DateTime> turnosProximos = new List<DateTime>();
            DateTime posibleTurno = DateTime.Now.Date;
            posibleTurno = posibleTurno.AddDays(1);
            TimeSpan ts = new TimeSpan(medico.Horario.Inicio, 0, 0);
            posibleTurno = posibleTurno.Date + ts;
            bool bandDia = true;
            while (bandDia)
            {
                bool bandHora = true;
                bool coincideDia = false;
                foreach (int dia in dias)
                {
                    if (dia == (int)posibleTurno.DayOfWeek)
                    {
                        coincideDia = true;
                        break;
                    }
                }
                if (!coincideDia) bandHora = false;
                while (bandHora)
                {
                    bool encontro = false;
                    foreach (Turno turno in turnos)
                    {
                        if (posibleTurno == turno.Fecha && turno.Estado != Estados.Cancelado)
                        {
                            encontro = true;
                            break;
                        }
                    }
                    if (!encontro && posibleTurno.Hour != 13)
                    {
                        turnosProximos.Add(posibleTurno);
                    }
                    posibleTurno = posibleTurno.AddHours(1);
                    if (medico.Horario.Fin <= posibleTurno.Hour || turnosProximos.Count >= 5) bandHora = false;
                }
                posibleTurno = posibleTurno.AddDays(1);
                if (turnosProximos.Count >= 5) bandDia = false;
            }
            string texto = "";
            foreach (DateTime turno in turnosProximos)
            {
                texto = texto + " | " + turno.ToString();
            }
            lblProximosTurnos.Text = texto;
            setearHoras();

        }

        protected List<int> diasDeTrabajo()
        {
            Medico medico = (Medico)Session["medico"];
            List<int> dias = new List<int>();
            foreach (Dias dia in medico.Horario.Dias)
            {
                if (dia == Dias.Lunes) dias.Add(1);
                if (dia == Dias.Martes) dias.Add(2);
                if (dia == Dias.Miercoles) dias.Add(3);
                if (dia == Dias.Jueves) dias.Add(4);
                if (dia == Dias.Viernes) dias.Add(5);
                if (dia == Dias.Sabado) dias.Add(6);
            }
            return dias;
        }

        protected List<int> horasDeTrabajo()
        {
            Medico medico = (Medico)Session["medico"];
            List<int> horas = new List<int>();
            
            for(int i = medico.Horario.Inicio; i < medico.Horario.Fin; i++)
            {
                if(i != 13) horas.Add(i);
            }
            return horas;
        }

        protected void setearHoras()
        {
            List<int> horas = horasDeTrabajo();
            var horasQuery = horas.Select(hora => new { horaId = hora, txtHora = hora.ToString() + ":00" });
            ddlHorarios.DataSource = horasQuery;
            ddlHorarios.DataTextField = "txtHora";
            ddlHorarios.DataValueField = "horaId";
            ddlHorarios.DataBind();
        }

        //protected void setearEstados()
        //{

            
        //    ddlEstado.DataSource = Estados;
        //    ddlMedico.DataTextField = "medicoNombreCompleto";
        //    ddlMedico.DataValueField = "medicoId";
        //    ddlMedico.DataBind();

        //}
        protected void btnConfirmarFecha_Click(object sender, EventArgs e)
        {
            if (Session["paciente"] == null)
            {
                lblConfirmarFecha.Text = "Revisar información del paciente!";
                Session["flagTurnos"] = false;
                return;
            }
            if (Fecha.Text == "")
            {
                lblConfirmarFecha.Text = "Completar fecha!";
                Session["flagTurnos"] = false;
                return;
            }
            DateTime fechaSeleccionada = Convert.ToDateTime(Fecha.Text);
            if (fechaSeleccionada < DateTime.Now.Date)
            {
                lblConfirmarFecha.Text = "Esa fecha ya pasó!";
                Session["flagTurnos"] = false;
                return;
            }
            if (fechaSeleccionada == DateTime.Now.Date)
            {
                lblConfirmarFecha.Text = "Solo se agendan turnos el día anterior a la cita!";
                Session["flagTurnos"] = false;
                return;
            }
            List<int> dias = diasDeTrabajo();
            bool coincideDia = false;
            Medico medico = (Medico)Session["medico"];
            Paciente paciente = (Paciente)Session["paciente"];
            foreach (int dia in dias)
            {
                if (dia == (int)fechaSeleccionada.DayOfWeek)
                {
                    coincideDia = true;
                    break;
                }
            }
            if (!coincideDia)
            {
                lblConfirmarFecha.Text = "El médico sólo trabaja ";

                foreach (Dias dia in medico.Horario.Dias)
                {
                    lblConfirmarFecha.Text += dia;
                }
                Session["flagTurnos"] = false;
                return;
            }
            lblConfirmarFecha.Text = "";
            TimeSpan ts = new TimeSpan(int.Parse(ddlHorarios.SelectedItem.Value), 0, 0);
            fechaSeleccionada = fechaSeleccionada.Date + ts;
            TurnosNegocio negocio = new TurnosNegocio();
            Turno turno = negocio.Buscar(medico.Id, paciente.Id, fechaSeleccionada);
            if (Session["turno"] != null)
            {
                Turno turnoUpdated = (Turno)Session["turno"];
                if(fechaSeleccionada == turnoUpdated.Fecha)
                {
                    Session["flagTurnos"] = true;
                    lblConfirmarFecha.Text = "Fecha y hora confirmadas!";
                    lblConfirmar.Text = "";
                    return;
                }
            }
            if (turno.Paciente == null)
            {
                Session["flagTurnos"] = true;
                lblConfirmarFecha.Text = "Fecha y hora confirmadas!";
                lblConfirmar.Text = "";
                return;
            }
            if (int.Parse(turno.Paciente) == paciente.Id && int.Parse(turno.Medico) == medico.Id) 
            {
                lblConfirmarFecha.Text = "Turno ocupado por paciente y médico";
                Session["flagTurnos"] = false;
                return;
            }
            if (int.Parse(turno.Paciente) == paciente.Id) lblConfirmarFecha.Text = "Turno ocupado por paciente";
            if (int.Parse(turno.Medico) == medico.Id) lblConfirmarFecha.Text = "Turno ocupado por médico";
        }

        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            if(lblConfirmarFecha.Text != "Fecha y hora confirmadas!")
            {
                lblConfirmar.Text = "Confirmar fecha y hora!";
                return;
            }
            if ((bool)Session["flagTurnos"])
            {
                DateTime fechaSeleccionada = Convert.ToDateTime(Fecha.Text);
                TimeSpan ts = new TimeSpan(int.Parse(ddlHorarios.SelectedItem.Value), 0, 0);
                fechaSeleccionada = fechaSeleccionada.Date + ts;
                Medico medico = (Medico)Session["medico"];
                Paciente paciente = (Paciente)Session["paciente"];
                try
                {
                    TurnosNegocio negocio = new TurnosNegocio();
                    Turno turno = new Turno(fechaSeleccionada, Estados.Nuevo, paciente.Id.ToString(), medico.Id.ToString(), ddlEspecialidad.SelectedItem.Value, txtObservaciones.Text);
                    if(Request.QueryString["ID"] != null) negocio.modificar(turno);
                    else negocio.agregar(turno);
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
            else lblConfirmar.Text = "Hay errores en el formulario";
        }
    }
}