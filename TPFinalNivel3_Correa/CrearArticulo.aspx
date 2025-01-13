<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearArticulo.aspx.cs" Inherits="TPFinalNivel3_Correa.CrearArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="ScriptManagerArt"></asp:ScriptManager>

    <div class="row">
        <div class="col-sm-12 col-md-6">
            <div class="mb-3">
                <asp:Label for="tbxCodigo" runat="server" CssClass="form-label">Código</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxCodigo" placeholder="XX00" />
            </div>

            <div class="mb-3">
                <asp:Label for="tbxNombre" runat="server" CssClass="form-label">Nombre</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxNombre" placeholder="Producto" />
            </div>

            <asp:UpdatePanel runat="server" ID="UpdatePanelDDL">
                <ContentTemplate>

                    <div class="mb-3">
                        <asp:Label runat="server" CssClass="form-label">Marca</asp:Label>
                        <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle" runat="server" ID="ddlMarca" />
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" CssClass="form-label">Categoria</asp:Label>
                        <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle" runat="server" ID="ddlCategoria" />
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="mb-3">
                <asp:Label for="tbxPrecio" runat="server" CssClass="form-label">Precio</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxPrecio" placeholder="100.00" />
            </div>
        </div>

        <div class="col-sm-12 col-md-6">

            <div class="mb-3">
                <asp:Label for="tbxDescripcion" runat="server" CssClass="form-label">Descripción</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxDescripcion" MaxLength="50" TextMode="MultiLine" placeholder="Breve descripcion" />
            </div>

            <asp:UpdatePanel runat="server" ID="UpdatePanelIMG">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label for="tbxImagen" runat="server" CssClass="form-label">Url imagen</asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tbxImagen" AutoPostBack="true" OnTextChanged="tbxImagen_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Image  Width="60%" runat="server" ID="artImagen" ImageUrl="https://imgs.search.brave.com/TvImnNqSmkLvWLy9Y1Hkith2FQJECMibPyhZ122wNb0/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/dmVjdG9yLWdyYXRp/cy9pbHVzdHJhY2lv/bi1jb25jZXB0by1j/YXJwZXRhLWltYWdl/bmVzXzExNDM2MC0x/MTQuanBnP3NlbXQ9/YWlzX2h5YnJpZA" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="mb-3">
            <%if (Eliminar)
                { %>
            <asp:Button runat="server" CssClass="btn btn-warning" Text="Ocultar Producto" ID="btnOcultar" OnClick="btnOcultar_Click" />
            <%}else
                { %>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Crear" ID="btnCrearArt" OnClick="btnCrearArt_Click" />
            <%} %>
            <asp:Button runat="server" CssClass="btn btn-danger" Text="Cancelar" ID="btnCancelarArt" OnClick="btnCancelarArt_Click" />
        </div>
    </div>

</asp:Content>
