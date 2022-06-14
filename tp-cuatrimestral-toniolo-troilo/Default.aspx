<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="row mb-3">
                <label for="txtEmail" class="col-sm-2 col-form-label">Email</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" type="email" />
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtPassword" class="col-sm-2 col-form-label">Password</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" type="password" />
                </div>
            </div>
            <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="btnLogIn" OnClick="btnLogIn_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
