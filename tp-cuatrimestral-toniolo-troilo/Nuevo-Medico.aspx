<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Nuevo-Medico.aspx.cs" Inherits="tp_cuatrimestral_toniolo_troilo.Nuevo_Medico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="row mb-3">
                <label for="txtNombre" class="col-sm-2 col-form-label">Nombre</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" type="text" MaxLength="20" />
                    <asp:RegularExpressionValidator ID="vldNombre" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="No puede ingresar numeros" ValidationExpression="^[A-Za-z]*$" Runat="server"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtNombre" ID="RegularExprssionValidator2" ValidationExpression = "^[\s\S]{3,20}$" runat="server" ErrorMessage="Entre 3 y 20 caracteres"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtApellido" class="col-sm-2 col-form-label">Apellido</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" type="text" MaxLength="20" />
                    <asp:RegularExpressionValidator ID="RegularExpressio1" ControlToValidate="txtApellido" Display="Dynamic" ErrorMessage="No puede ingresar numeros" ValidationExpression="^[A-Za-z]*$" Runat="server"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtApellido" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{3,20}$" runat="server" ErrorMessage="Entre 3 y 20 caracteres"></asp:RegularExpressionValidator>
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
                <label for="Fecha" class="col-sm-2 col-form-label">Fecha</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="Fecha" type="Date" />
                </div>
            </div>

            <div class="row mb-3">
                <label runat="server" for="ltsEspecialidades" class="col-sm-2 col-form-label">Especialidades</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ltsEspecialidades"
                        AutoPostBack="True"
                        runat="server"
                        CssClass="btn btn-outline-dark dropdown-togglez">
                    </asp:DropDownList>
                    <asp:Button Text="+" CssClass="btn btn-primary" ID="SumarEspecialidad" OnClick="btnSumarEsp_Click" runat="server" />
                </div>
                <asp:Repeater runat="server" id="repEspecialidades">
                    <ItemTemplate>
                            <div>
                                <asp:Label runat="server" ID="lblEspecialidades" Text='<%#Eval("Nombre") %>' />
                                <asp:Button Text="x" CssClass="btn btn-secondary" ID="RestarEspecialidad" OnClick="RestarEspecialidad_Click" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="EspecialidadID"/>
                            </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="row mb-3">
                <label for="txtDias" class="col-sm-2 col-form-label" runat="server">Dias</label>
                <div class="col-sm-10">
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" runat="server" type="checkbox" id="inlineCheckbox1" value="option1">
                        <label class="form-check-label" for="inlineCheckbox1">Lunes</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox2" value="option2" runat="server">
                        <label class="form-check-label" for="inlineCheckbox2">Martes</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox3" value="option3" runat="server">
                        <label class="form-check-label" for="inlineCheckbox3">Miercoles</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox4" value="option4" runat="server">
                        <label class="form-check-label" for="inlineCheckbox4">Jueves</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox5" value="option5" runat="server">
                        <label class="form-check-label" for="inlineCheckbox5">Viernes</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="inlineCheckbox6" value="option6" runat="server">
                        <label class="form-check-label" for="inlineCheckbox6">Sabados</label>
                    </div>
                </div>
            </div>

            <div class="row mb-3">
                <label for="HorarioInicio" class="col-sm-2 col-form-label">Horario Inicio</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="HorarioInicio" type="Time" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="HorarioFin" class="col-sm-2 col-form-label">Horario Fin</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="HorarioFin" type="Time" AutoPostBack="True" OnTextChanged="HorarioFin_OnTextChanged"/>
                    <label id="HorarioCheck" runat="server" >  </label>
                </div>
            </div>

            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnRegistrar" OnClick="btnRegistrar_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
