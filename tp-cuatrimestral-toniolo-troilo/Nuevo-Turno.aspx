<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Nuevo-Turno.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <asp:UpdatePanel runat="server">
            <ContentTemplate>
            <div class="row mb-3">
                <label for="txtPaciente" class="col-sm-2 col-form-label">DNI Paciente</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPaciente" type="text" OnTextChanged="txtPaciente_TextChanged" AutoPostback="true"/>
                    <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtEspecialidad" class="col-sm-2 col-form-label">Especialidad</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" CssClass="btn btn-outline-dark dropdown-togglez"></asp:DropDownList>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtMedico" class="col-sm-2 col-form-label">Medico</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlMedico" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged" CssClass="btn btn-outline-dark dropdown-togglez"></asp:DropDownList>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtProximosTurnos" class="col-sm-2 col-form-label">Turnos más próximos:</label>
                <div class="col-sm-10">
                    <asp:Label ID="lblProximosTurnos" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mb-3">
                <label for="Fecha" class="col-sm-2 col-form-label">Fecha</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="Fecha" type="Date" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="Horario" class="col-sm-2 col-form-label">Horario</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlHorarios" runat="server" CssClass="btn btn-outline-dark dropdown-togglez"></asp:DropDownList>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-sm-10">
                    <asp:Button ID="btnConfirmarFecha" runat="server" Text="Confirmar fecha y hora" CssClass="btn btn-primary" OnClick="btnConfirmarFecha_Click" />
                    <asp:Label ID="lblConfirmarFecha" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <%if (Request.QueryString["ID"] != null)
                { %>
            <div class="row mb-3">
                <label for="txtEstado" class="col-sm-2 col-form-label">Estado</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="btn btn-outline-dark dropdown-togglez">
                    </asp:DropDownList>
                </div>
            </div>
            <%} %>

            <div class="row mb-3">
                <label for="txtObservaciones" class="col-sm-2 col-form-label">Observaciones</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtObservaciones" type="text" TextMode="MultiLine" Rows="3" Text=""/>
                </div>
            </div>

            <asp:Button Text="Agendar" CssClass="btn btn-primary" ID="btnAgendar" OnClick="btnAgendar_Click" runat="server" AutoPostback="true" />
            <asp:Label ID="lblConfirmar" runat="server" Text=""></asp:Label>
                </ContentTemplate>
        </asp:UpdatePanel>

        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
