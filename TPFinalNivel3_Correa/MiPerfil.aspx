<%@ Page Title="SAC-NET | Mi perfil" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPFinalNivel3_Correa.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mi Perfil</h3>


    <div class="row">
        <div class="col-md-5">
            <div class="mb-3">
                <asp:Label runat="server" ID="lblEmail" for="tbxEmail" Text="Email:" CssClass="form-label"></asp:Label>
                <asp:TextBox runat="server" ID="tbxEmail" CssClass="form-control" placeholder="name@ejemplo.com"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxEmail" ErrorMessage="Email es requerido"/>
            </div>

            <div class="mb-3">
                <asp:Label runat="server" ID="lblNombre" for="tbxNombre" Text="Nombre:" CssClass="form-label"></asp:Label>
                <asp:TextBox runat="server" ID="tbxNombre" CssClass="form-control" placeholder="Jonh"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxNombre" ErrorMessage="Nombre es requerido"/>
            </div>

            <div class="mb-3">
                <asp:Label runat="server" ID="lblApellido" for="tbxApellido" Text="Apellido:" CssClass="form-label"></asp:Label>
                <asp:TextBox runat="server" ID="tbxApellido" CssClass="form-control" placeholder="Doe"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxApellido" ErrorMessage="Apellido es requerido"/>
            </div>
        </div>

        <div class="col-md-5">
            <div class="mb-3">
                <asp:Label runat="server" ID="lblImagenPerfil" for="tbxImagenPerfil" Text="Imagen de perfil (Sólo .jpg)" CssClass="form-label" />
                <input runat="server" type="file" ID="tbxImagenPerfil" class="form-control"/>
            </div>
            <asp:Image runat="server" ID="imagenPerfil" ImageUrl="https://imgs.search.brave.com/UoEGoEVhpqRO83GQUva4-8Xw_r1PhAGKGtCKmb9aaDA/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly90NC5m/dGNkbi5uZXQvanBn/LzA4Lzc1LzQ1Lzk3/LzM2MF9GXzg3NTQ1/OTcxOV84aTdKM2F0/R2JzRG9SUFQwWlcw/RGpCcGdBRlZUcktB/ZS5qcGc" CssClass="img-fluid mb-3" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 d-flex flex-column flex-md-row gap-2">
            <asp:Button runat="server" Text="Guardar cambios" CssClass="btn btn-primary w-100 w-md-auto" ID="btnGuardar" OnClick="btnGuardar_Click" />
            <%if (TPFinalNivel3_Correa.negocio.Seguridad.verificarAdmin(Session["sesionAbierta"]))
                { %>
            <asp:Button runat="server" ID="btnEliminarAdmin" CssClass="btn btn-dark w-100 w-md-auto" Text="NO ser admin" OnClick="btnEliminarAdmin_Click" />
            <%} %>
            <a href="Default.aspx" class="btn btn-secondary w-100 w-md-auto text-center">Regresar</a>
        </div>
    </div>
</asp:Content>
