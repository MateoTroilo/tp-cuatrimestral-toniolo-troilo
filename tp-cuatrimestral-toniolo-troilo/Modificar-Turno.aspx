<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Modificar-Turno.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Modificar_Turno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="row mb-3">
                <label for="Fecha" class="col-sm-2 col-form-label">Fecha</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="Fecha" type="Date" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="Horario" class="col-sm-2 col-form-label">Horario</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="Horario" type="Time" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtMedico" class="col-sm-2 col-form-label">Médico</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtMedico" type="text" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtPaciente" class="col-sm-2 col-form-label">Paciente</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPaciente" type="text" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtObservaciones" class="col-sm-2 col-form-label">Observaciones</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtObservaciones" type="text" />
                </div>
            </div>

            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnAgendar" OnClick="btnGuardar_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
