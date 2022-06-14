<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Recepcionista-Default.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" CssClass="table">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell># Turno</asp:TableHeaderCell>
            <asp:TableHeaderCell>Horario</asp:TableHeaderCell>
            <asp:TableHeaderCell>Médico</asp:TableHeaderCell>
            <asp:TableHeaderCell>Paciente</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>1</asp:TableCell>
            <asp:TableCell>10:00 hs</asp:TableCell>
            <asp:TableCell>Doctor 1</asp:TableCell>
            <asp:TableCell>Paciente 1</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
