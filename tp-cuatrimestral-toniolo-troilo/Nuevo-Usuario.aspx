<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Nuevo-Usuario.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Formulario_web15" %>

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
                <label for="txtUsuario" class="col-sm-2 col-form-label">Usuario</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" type="text" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtContrasenia" class="col-sm-2 col-form-label">Contraseña</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtContrasenia" type="password" />
                </div>
            </div>


            <div class="row mb-3">
                <label for="ltsPermisos" class="col-sm-2 col-form-label">Permisos</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ltsPermisos"
                        AutoPostBack="True"
                        runat="server">
                        <asp:ListItem Selected="True" Value="Medico"> Médico </asp:ListItem>
                        <asp:ListItem Value="Recepcionista"> Recepcionista </asp:ListItem>
                        <asp:ListItem Value="Administrador"> Administrador </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <asp:Button Text="Registrar" CssClass="btn btn-primary" ID="btnRegistrar" OnClick="btnRegistrar_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
