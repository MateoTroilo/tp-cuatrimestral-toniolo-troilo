<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web17" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>

    <div class="row">
        <div class="col">

            <asp:GridView ID="dgvTurnos" CssClass="table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="false">

                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" ButtonType="Button" Text="Editar" OnClick="btnEditar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" ButtonType="Button" Text="Cancelar" OnClientClick="return confirm('Cancelar turno?');" OnClick="btnEliminar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                    <asp:BoundField HeaderText="Estado" DataField="Estado" />
                    <asp:BoundField HeaderText="Paciente" DataField="Paciente" />
                    <asp:BoundField HeaderText="Medico" DataField="Medico" />
                    <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" />
                    <asp:BoundField HeaderText="Observaciones" DataField="Observacion" />
                </Columns>

            </asp:GridView>
            <% if (Session["usuario"] != null)
                { %>
            <% if (((tp_cuatrimestral_toniolo_troilo.Usuarios)Session["usuario"]).TipoUsuario != tp_cuatrimestral_toniolo_troilo.TipoUsuario.MEDICO)
                { %>
            <asp:Button Text="Nuevo Turno" CssClass="btn btn-primary" ID="btnNuevo" OnClick="btnNuevo_Click" runat="server" />
            <% } %>
            <% } %>
        </div>
    </div>

</asp:Content>
