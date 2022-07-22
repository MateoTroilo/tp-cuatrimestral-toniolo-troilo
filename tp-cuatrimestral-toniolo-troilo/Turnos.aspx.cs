using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_toniolo_troilo
{
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["usuario"] == null)
            //{
            //    Session.Add("error", "Debes estar logueado para ingresar a esta pantalla.");
            //    Response.Redirect("error.aspx", false);
            //    return;
            //}

            if (Session["usuario"] == null || ((Usuarios)Session["usuario"]).TipoUsuario == TipoUsuario.MEDICO)
            {
                TurnosNegocio negocio = new TurnosNegocio();
                dgvTurnos.DataSource = negocio.listarPlanilla();
                dgvTurnos.DataBind();
            }
            else
            {
                TurnosNegocio negocio = new TurnosNegocio();
                dgvTurnos.DataSource = negocio.listarPlanilla();
                dgvTurnos.DataBind();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;

            dgvTurnos.SelectRow(rowindex);
            GridViewRow row = dgvTurnos.SelectedRow;

            int ID = Int32.Parse(row.Cells[1].Text);

            Response.Redirect("Nuevo-Turno.aspx?ID=" + ID, false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;

            dgvTurnos.SelectRow(rowindex);
            GridViewRow row = dgvTurnos.SelectedRow;

            int ID = Int32.Parse(row.Cells[2].Text);

            TurnosNegocio negocio = new TurnosNegocio();
            negocio.Eliminar(ID);

            Response.Redirect(Request.RawUrl);
        }
    }
}