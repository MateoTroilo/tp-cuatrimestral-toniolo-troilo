<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Medico-Turno.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvTurnos" runat="server"></asp:GridView>


    <%--<asp:Table runat="server" CssClass="table">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell># Turno</asp:TableHeaderCell>
            <asp:TableHeaderCell>Dia</asp:TableHeaderCell>
            <asp:TableHeaderCell>Horario</asp:TableHeaderCell>
            <asp:TableHeaderCell>Paciente</asp:TableHeaderCell>
            <asp:TableHeaderCell>Estado</asp:TableHeaderCell>
            <asp:TableHeaderCell>Observaciones</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>1</asp:TableCell>
            <asp:TableCell>27/06</asp:TableCell>
            <asp:TableCell>10:00 hs</asp:TableCell>
            <asp:TableCell>Paciente 1</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList id="ltsEstado"
                    AutoPostBack="True"
                    runat="server">
                  <asp:ListItem Selected="True" Value="Cerrado"> Cerrado </asp:ListItem>
                  <asp:ListItem Value="etc"> etc </asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>Observaciones 1</asp:TableCell>
        </asp:TableRow>
    </asp:Table>--%>
</asp:Content>
