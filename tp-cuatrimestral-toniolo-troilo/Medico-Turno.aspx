<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Medico-Turno.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web14" %>
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

    <asp:GridView ID="dgvTurnos" CssClass="table table-striped table-bordered table-condensed" runat="server"></asp:GridView>

</asp:Content>
