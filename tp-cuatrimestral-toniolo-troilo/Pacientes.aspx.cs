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
            PacienteNegocio negocio = new PacienteNegocio();
            dgvPacientes.DataSource = negocio.listar();
            dgvPacientes.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Nuevo-Paciente.aspx", false);
        }

        protected void EditBtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;

            dgvPacientes.SelectRow(rowindex);
            GridViewRow row = dgvPacientes.SelectedRow;

            int ID = Int32.Parse(row.Cells[3].Text);

            Response.Redirect("Nuevo-Paciente.aspx?ID=" + ID, false);
        }

        protected void DeleteBtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;

            dgvPacientes.SelectRow(rowindex);
            GridViewRow row = dgvPacientes.SelectedRow;

            int ID = Int32.Parse(row.Cells[3].Text);

            PacienteNegocio negocio = new PacienteNegocio();
            negocio.Eliminar(ID);

            Response.Redirect(Request.RawUrl);
            //string msg = "<script>alert(" + row.Cells[3].Text + ");</script>";
            //Response.Write(msg);


        }
    }

   

}