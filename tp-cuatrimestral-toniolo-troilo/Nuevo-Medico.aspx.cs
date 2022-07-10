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