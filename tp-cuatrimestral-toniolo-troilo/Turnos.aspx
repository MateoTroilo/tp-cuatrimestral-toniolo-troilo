<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web17"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <% if (((tp_cuatrimestral_toniolo_troilo.Usuarios)Session["usuario"]).TipoUsuario != tp_cuatrimestral_toniolo_troilo.TipoUsuario.MEDICO)
        { %>
        <asp:Button Text="Nuevo Turno" CssClass="btn btn-primary" ID="btnNuevo" OnClick="btnNuevo_Click" runat="server" />
    <% } %>--%>

    <asp:GridView ID="dgvTurnos" CssClass="table table-striped table-bordered table-condensed" runat="server">

        <Columns>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" ButtonType="Button" Text="Edit" OnClick="btnEditar_Click" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" runat="server" ButtonType="Button" Text="Delete" OnClientClick="return confirm('Cancelar turno?');" OnClick="btnEliminar_Click" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>
