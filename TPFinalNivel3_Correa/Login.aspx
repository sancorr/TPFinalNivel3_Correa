<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3_Correa.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center align-items-center vh-90 mx-0">
        <div class="col-12 col-md-10 col-lg-8">
            <div class="card shadow p-4">
                <h3 class="text-center mb-4">Ingresar</h3>
                <div class="mb-3">
                    <asp:Label for="tbxEmailIngreso" runat="server" CssClass="form-label">Email</asp:Label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="tbxEmailIngreso" placeholder="Nombre@ejemplo.com" />
                     <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxEmailIngreso" ErrorMessage="Email es requerido" />
                </div>

                <div class="mb-3">
                    <asp:Label for="tbxPassIngreso" runat="server" CssClass="form-label">Contraseña</asp:Label>
                    <asp:TextBox CssClass="form-control" type="password" runat="server" ID="tbxPassIngreso" placeholder="Contraseña" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxPassIngreso" ErrorMessage="Contraseña es requerido" />
                </div>

                <div>
                    <asp:Button runat="server" ID="btnIngreso" Text="Ingresar" CssClass="btn btn-success" OnClick="btnIngreso_Click" />
                    <a href="Default.aspx">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
