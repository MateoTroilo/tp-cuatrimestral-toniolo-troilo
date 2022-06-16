<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Recepcionista-Default.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="row mb-3">
                <label for="txtFiltro" class="col-sm-2 col-form-label">Filtro</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFiltro" type="text" />
                </div>
            </div>
        </div>
        <div class="col-2"></div>
    </div>

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
