<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Medicos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>


    <asp:GridView ID="dgvMedicos" CssClass="table table-striped table-bordered table-condensed" runat="server">

        <Columns>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" ButtonType="Button" Text="Edit" OnClick="EditBtnClick" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" ButtonType="Button" Text="Delete" OnClientClick="return confirm('Eliminar medico?');" OnClick="DeleteBtnClick" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Fecha de nacimiento" DataField="FechaNacimiento" />
            <asp:BoundField HeaderText="Sexo" DataField="Sexo" />
            <asp:BoundField HeaderText="DNI" DataField="DNI" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
        </Columns>

    </asp:GridView>
    <% if (Session["usuario"] != null)
        { %>
    <% if (((tp_cuatrimestral_toniolo_troilo.Usuarios)Session["usuario"]).TipoUsuario != tp_cuatrimestral_toniolo_troilo.TipoUsuario.MEDICO)
        { %>
    <asp:Button Text="Nuevo Medico" CssClass="btn btn-primary" ID="btnNuevo" OnClick="btnNuevo_Click" runat="server" />
    <% } %>
    <% } %>
</asp:Content>
