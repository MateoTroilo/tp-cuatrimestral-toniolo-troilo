<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Nuevo-Medico.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Nuevo_Medico" %>
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
                <label for="CalendarFechaNac" class="col-sm-2 col-form-label">Fecha de nacimiento</label>
                <div class="col-sm-10">
                    <asp:Calendar ID="CalendarDate" runat="server" type="date"></asp:Calendar>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtObraSocial" class="col-sm-2 col-form-label">Plan</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtObraSocial" type="text" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="ltsEspecialidades" class="col-sm-2 col-form-label">Especialidades</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ltsEspecialidades"
                        AutoPostBack="True"
                        runat="server">
                        <asp:ListItem Selected="True" Value="Clinico"> Clinico </asp:ListItem>
                        <asp:ListItem Value="Clinico"> Clinico </asp:ListItem>
                        <asp:ListItem Value="Clinico"> Clinico </asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button Text="+" CssClass="btn btn-primary" ID="SumarEspecialidad" OnClick="btnSumarEsp_Click" runat="server" />
                </div>
                <asp:Label Text="" ID="lblEspecialidades" runat="server" />
            </div>

            <div class="row mb-3">
                <label for="txtDias" class="col-sm-2 col-form-label">Dias</label>
                <div class="col-sm-10">
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox1" value="option1">
                    <label class="form-check-label" for="inlineCheckbox1">Lunes</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox2" value="option2">
                    <label class="form-check-label" for="inlineCheckbox2">Martes</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox3" value="option3">
                    <label class="form-check-label" for="inlineCheckbox3">Miercoles</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox4" value="option1">
                    <label class="form-check-label" for="inlineCheckbox1">Jueves</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox5" value="option2">
                    <label class="form-check-label" for="inlineCheckbox2">Viernes</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="inlineCheckbox6" value="option3">
                    <label class="form-check-label" for="inlineCheckbox3">Sabados</label>
                </div>
                    </div>
            </div>
            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnRegistrar" OnClick="btnRegistrar_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
