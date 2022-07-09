<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Error    </h1>
    <asp:Label Text="text" ID="lblMensaje" runat="server" />
    <%      if (Session["usuario"] == null)
        {
    %>
    <br />
    <a runat="server" class="btn btn-primary" href="~/default.aspx">Log In</a>
    <%
        } %>
</asp:Content>
