using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_toniolo_troilo
{
    public partial class Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes estar logueado para ingresar a esta pantalla.");
                Response.Redirect("error.aspx", false);
                return;
            }
            MedicoNegocio negocio = new MedicoNegocio();
            dgvMedicos.DataSource = negocio.Listar();
            dgvMedicos.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Nuevo-Medico.aspx", false);
        }

        protected void EditBtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;

            dgvMedicos.SelectRow(rowindex);
            GridViewRow row = dgvMedicos.SelectedRow;

            int ID = Int32.Parse(row.Cells[2].Text);

            Response.Redirect("Nuevo-Medico.aspx?ID=" + ID, false);
        }

        protected void DeleteBtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;

            dgvMedicos.SelectRow(rowindex);
            GridViewRow row = dgvMedicos.SelectedRow;

            int ID = Int32.Parse(row.Cells[2].Text);

            MedicoNegocio negocio = new MedicoNegocio();
            negocio.Eliminar(ID);

            Response.Redirect(Request.RawUrl);
            //string msg = "<script>alert(" + row.Cells[3].Text + ");</script>";
            //Response.Write(msg);


        }
    }
}
