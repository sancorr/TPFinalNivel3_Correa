<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3_Correa.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12 col-md-6">
            <div class="mb-3">
                <asp:Label for="tbxNombre" runat="server" CssClass="form-label">Nombre</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxNombre" placeholder="Nombre" />
            </div>

            <div class="mb-3">
                <asp:Label for="tbxApellido" runat="server" CssClass="form-label">Apellido</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxApellido" placeholder="Apellido" />
            </div>

            <div class="mb-3">
                <asp:Label for="tbxEmail" runat="server" CssClass="form-label">Email</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxEmail" placeholder="Nombre@ejemplo.com" />
            </div>

            <div class="mb-3">
                <asp:Label for="tbxPass" runat="server" CssClass="form-label">Contraseña</asp:Label>
                <asp:TextBox CssClass="form-control" type="password" runat="server" ID="tbxPass" placeholder="Contraseña" />
            </div>

            <div>
                <asp:Button runat="server" CssClass="btn btn-primary" ID="btnRegistro" Text="Registrarse" OnClick="btnRegistro_Click"/>
                <a href="Default.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
