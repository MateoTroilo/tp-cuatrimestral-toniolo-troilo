<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Button Text="Nuevo Paciente" CssClass="btn btn-primary" ID="btnNuevo" OnClick="btnNuevo_Click" runat="server" />

    <asp:GridView ID="dgvPacientes" CssClass="table table-striped table-bordered table-condensed" runat="server">

        <columns>

            <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="Editar"/>
            <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar" />
            <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" HeaderText="Eliminar" />

        </columns>

    </asp:GridView>

</asp:Content>
