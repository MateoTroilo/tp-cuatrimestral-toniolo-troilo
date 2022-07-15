﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Medicos" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button Text="Nuevo Medico" CssClass="btn btn-primary" ID="btnNuevo" OnClick="btnNuevo_Click" runat="server" />

    <asp:GridView ID="dgvMedicos" CssClass="table table-striped table-bordered table-condensed" runat="server">

        <columns>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" ButtonType="Button" Text="Edit" OnClick="EditBtnClick" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" ButtonType="Button" Text="Delete" OnClientClick="return confirm('Eliminar medico?');" onclick="DeleteBtnClick" />
                </ItemTemplate>
            </asp:TemplateField>

        </columns>

    </asp:GridView>

</asp:Content>