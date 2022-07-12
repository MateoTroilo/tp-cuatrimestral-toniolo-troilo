﻿using System;
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
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Medico medico;
            MedicoNegocio negocio = new MedicoNegocio();

            List<Especialidad> medicoEspecialidades = new List<Especialidad>();
            medicoEspecialidades = (List<Especialidad>)Session["listaEspecialidades"];

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
            else if (inlineCheckbox2.Checked)
            {
                listaDias.Add(Dias.Martes);
            }
            else if (inlineCheckbox3.Checked)
            {
                listaDias.Add(Dias.Miercoles);
            }
            else if (inlineCheckbox4.Checked)
            {
                listaDias.Add(Dias.Jueves);
            }
            else if (inlineCheckbox5.Checked)
            {
                listaDias.Add(Dias.Viernes);
            }
            else if (inlineCheckbox6.Checked)
            {
                listaDias.Add(Dias.Sabado);
            }


            try
            {
                int HoraInicio = int.Parse(HorarioInicio.Text.ToString().Substring(0, HorarioInicio.Text.ToString().IndexOf(":") + 1).TrimEnd(':')) * 100;
                int HoraFin = int.Parse(HorarioFin.Text.ToString().Substring(0, HorarioFin.Text.ToString().IndexOf(":") + 1).TrimEnd(':')) * 100;

                medico = new Medico(txtNombre.Text, txtApellido.Text, sex, DateTime.Parse(Fecha.Text), int.Parse(txtDNI.Text), txtEmail.Text, HoraInicio, HoraFin, listaDias, medicoEspecialidades);
                negocio.Agregar(medico);
        }
            catch (Exception ex)
            {
                throw ex;

            }
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
    }
}