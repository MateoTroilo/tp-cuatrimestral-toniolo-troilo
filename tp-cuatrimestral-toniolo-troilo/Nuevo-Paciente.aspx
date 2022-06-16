<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Nuevo-Paciente.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web13" %>

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

            <div class="row mb-3">
                <label for="txtApellido" class="col-sm-2 col-form-label">Apellido</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" type="text" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="rdoSexo" class="col-sm-2 col-form-label">Sexo</label>
                <div class="col-sm-10">
                    <asp:RadioButton runat="server" Text="Femenino" ID="femenino" GroupName="rdoSexo" />
                    <asp:RadioButton runat="server" Text="Masculino" ID="masculino" GroupName="rdoSexo" />
                    <asp:RadioButton runat="server" Text="Otro" ID="otro" GroupName="rdoSexo" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtDNI" class="col-sm-2 col-form-label">DNI</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDNI" type="number" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtEmail" class="col-sm-2 col-form-label">Email</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" type="email" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtObraSocial" class="col-sm-2 col-form-label">Obra Social</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtObraSocial" type="text" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtPlan" class="col-sm-2 col-form-label">Plan</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPlan" type="text" />
                </div>
            </div>

            <asp:Button Text="Registrar" CssClass="btn btn-primary" ID="btnRegistrar" OnClick="btnRegistrar_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
