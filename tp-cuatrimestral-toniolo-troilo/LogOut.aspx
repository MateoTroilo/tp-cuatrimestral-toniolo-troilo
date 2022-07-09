<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>¿Deseas cerrar sesión?</h1>
    <asp:Button ID="btnLogOut" runat="server" Text="Log Out" CssClass="btn btn-primary" OnClick="btnLogOut_Click" />

</asp:Content>
