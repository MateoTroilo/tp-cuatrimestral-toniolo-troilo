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
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" MaxLength="20" type="text" />
                    <asp:RegularExpressionValidator ID="vldNombre" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="No puede ingresar numeros" ValidationExpression="^[A-Za-z]*$" Runat="server"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtNombre" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{3,20}$" runat="server" ErrorMessage="Entre 3 y 20 caracteres"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtApellido" class="col-sm-2 col-form-label">Apellido</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" MaxLength="20"  type="text" />
                    <asp:RegularExpressionValidator ID="vldApellido" ControlToValidate="txtApellido" Display="Dynamic" ErrorMessage="No puede ingresar numeros" ValidationExpression="^[A-Za-z]*$" Runat="server"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtApellido" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{3,20}$" runat="server" ErrorMessage="Entre 3 y 20 caracteres"></asp:RegularExpressionValidator>
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
                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtDNI" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{8,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed."></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtEmail" class="col-sm-2 col-form-label">Email</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" type="email" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="FechaNacimiento" class="col-sm-2 col-form-label">Fecha de Nacimiento</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="FechaNacimineto" type="Date" />
                </div>
            </div>

            <%--<div class="row mb-3">
                <label for="txtObraSocial" class="col-sm-2 col-form-label">Plan</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtObraSocial" type="text" />
                </div>
            </div>--%>
            
            
            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnRegistrar" OnClick="btnRegistrar_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
