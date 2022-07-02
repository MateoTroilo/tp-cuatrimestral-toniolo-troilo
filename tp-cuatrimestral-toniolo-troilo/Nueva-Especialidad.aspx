<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Nueva-Especialidad.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="row mb-3">
                <label for="txtNombre" class="col-sm-2 col-form-label">Nombre</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" type="text" />
                </div>
            </div>

            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
