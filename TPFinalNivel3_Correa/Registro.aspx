<%@ Page Title="SAC-NET | Registrarse" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3_Correa.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="ScriptmanagerAdmin"></asp:ScriptManager>

    <div class="row justify-content-center align-items-center vh-90 mx-0">

        <div class="col-sm-12 col-md-6">

            <div class="card shadow p-4">
                <div class="mb-3">
                    <asp:Label for="tbxNombre" runat="server" CssClass="form-label">Nombre</asp:Label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="tbxNombre" placeholder="Nombre" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxNombre" ErrorMessage="Apellido es requerido" />
                </div>

                <div class="mb-3">
                    <asp:Label for="tbxApellido" runat="server" CssClass="form-label">Apellido</asp:Label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="tbxApellido" placeholder="Apellido" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxApellido" ErrorMessage="Apellido es requerido" />
                </div>

                <div class="mb-3">
                    <asp:Label for="tbxEmail" runat="server" CssClass="form-label">Email</asp:Label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="tbxEmail" placeholder="Nombre@ejemplo.com" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxEmail" ErrorMessage="Email es un campo requerido" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="validatorEmail" runat="server" ControlToValidate="tbxEmail" ErrorMessage="El formato de email no es correcto" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <asp:Label for="tbxPass" runat="server" CssClass="form-label">Contraseña</asp:Label>
                    <asp:TextBox CssClass="form-control" type="password" runat="server" ID="tbxPass" placeholder="Contraseña" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxPass" ErrorMessage="Contraseña es requerido" />
                </div>

                <asp:UpdatePanel runat="server" ID="UpdatePanelAdmin">
                    <ContentTemplate>

                        <div class="container d-flex mt-3 mb-3">
                            <asp:CheckBox ID="chkAdmin" runat="server" Text=" Ser administrador" AutoPostBack="true" OnCheckedChanged="chkAdmin_CheckedChanged" />
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="d-flex justify-content-between">
                    <asp:Button runat="server" CssClass="btn btn-primary" ID="btnRegistro" Text="Registrarse" OnClick="btnRegistro_Click" />
                    <a href="Default.aspx">Cancelar</a>
                </div>

            </div>



        </div>
    </div>
</asp:Content>
