<%@ Page Title="SAC-NET | Formulario" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearArticulo.aspx.cs" Inherits="TPFinalNivel3_Correa.CrearArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="ScriptManagerArt"></asp:ScriptManager>

    <div class="row">
        <div class="col-sm-12 col-md-6">
            <div class="mb-3">
                <asp:Label for="tbxCodigo" runat="server" CssClass="form-label">Código</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxCodigo" placeholder="XX00" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxCodigo" ErrorMessage="Código es requerido" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Label for="tbxNombre" runat="server" CssClass="form-label">Nombre</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxNombre" placeholder="Producto" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxNombre" ErrorMessage="Nombre es requerido" />
            </div>

            <asp:UpdatePanel runat="server" ID="UpdatePanelDDL">
                <ContentTemplate>
                    <asp:CheckBox runat="server" ID="chkAgregarMyC" Text="Agregar Marca/Categoria" AutoPostBack="true" OnCheckedChanged="chkAgregarMyC_CheckedChanged" />

                    <%if (chkAgregarMyC.Checked)
                        {%>
                    <div class="mb-3">
                        <asp:Label runat="server" ID="lblAgregarMarca" CssClass="form-label" Text="Marca:"></asp:Label>
                        <asp:TextBox runat="server" ID="tbxAgregarMarca" CssClass="form-control" MaxLength="50"></asp:TextBox>
                        <asp:Button runat="server" CssClass="btn btn-success mt-2" ID="btnAgregarMarca" Text="Agregar" OnClick="btnAgregarMarca_Click" />
                        <asp:Label runat="server" Text="" Visible="false" ID="lblMarcaAgregada" />
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbxAgregarMarca" ErrorMessage="Sólo letras- Máx 50 caracteres" ValidationExpression="^[A-Za-z ]+$"></asp:RegularExpressionValidator>
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" ID="lblAgregarCategoria" CssClass="form-label" Text="Categoria:"></asp:Label>
                        <asp:TextBox runat="server" ID="tbxAgregarCategoria" CssClass="form-control" MaxLength="50"></asp:TextBox>
                        <asp:Button runat="server" CssClass="btn btn-success mt-2" ID="btnAgregarCategoria" Text="Agregar" OnClick="btnAgregarCategoria_Click" />
                        <asp:Label runat="server" Text="" Visible="false" ID="lblCategoriaAgregada" />
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbxAgregarCategoria" ErrorMessage="Sólo letras- Máx 50 caracteres" ValidationExpression="^[A-Za-z ]+$"></asp:RegularExpressionValidator>
                    </div>

                    <%} %>
                    <div class="mb-3">
                        <div>
                            <asp:Label runat="server" CssClass="form-label">Marca</asp:Label>
                        </div>
                        <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle" runat="server" ID="ddlMarca" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlMarca" ErrorMessage="Marca es requerido" />
                    </div>

                    <div class="mb-3">
                        <div>
                            <asp:Label runat="server" CssClass="form-label">Categoria</asp:Label>
                        </div>
                        <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle" runat="server" ID="ddlCategoria" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCategoria" ErrorMessage="Categoria es requerido" />
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="mb-3">
                <asp:Label for="tbxPrecio" runat="server" CssClass="form-label">Precio</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxPrecio" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxPrecio" ErrorMessage="Precio es requerido" Display="Dynamic" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="tbxPrecio" ErrorMessage="Solo se adminten numeros enteros" ValidationExpression="^\d+$" Display="Dynamic" />

            </div>
        </div>

        <div class="col-sm-12 col-md-6">

            <div class="mb-3">
                <asp:Label for="tbxDescripcion" runat="server" CssClass="form-label">Descripción</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="tbxDescripcion" MaxLength="50" TextMode="MultiLine" placeholder="Breve descripcion" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxDescripcion" Display="Dynamic" ErrorMessage="Campo requerido-Máximo 150 caracteres" />
            </div>

            <asp:UpdatePanel runat="server" ID="UpdatePanelIMG">
                <ContentTemplate>
                    <div class="d-flex flex-column">

                        <div class="mb-3">
                            <asp:Label for="tbxImagen" runat="server" CssClass="form-label">Url imagen</asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbxImagen" AutoPostBack="true" OnTextChanged="tbxImagen_TextChanged"></asp:TextBox>
                        </div>
                        <asp:Image runat="server" CssClass="image-limited" ID="artImagen" ImageUrl="https://imgs.search.brave.com/TvImnNqSmkLvWLy9Y1Hkith2FQJECMibPyhZ122wNb0/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/dmVjdG9yLWdyYXRp/cy9pbHVzdHJhY2lv/bi1jb25jZXB0by1j/YXJwZXRhLWltYWdl/bmVzXzExNDM2MC0x/MTQuanBnP3NlbXQ9/YWlzX2h5YnJpZA" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="container d-flex mt-3">
            <asp:Label runat="server" Text="" Visible="false" ID="lblMensajeCrear" CssClass="alert alert-danger w-80 text-center" />
        </div>

        <div class="mb-3 mt-3">
            <asp:Button runat="server" CssClass="btn btn-outline-primary" Text="Crear" ID="btnCrearArt" OnClick="btnCrearArt_Click" />
            <asp:Button runat="server" CssClass="btn btn-outline-danger" Text="Cancelar" ID="btnCancelarArt" OnClick="btnCancelarArt_Click" />
            <asp:Button runat="server" CssClass="btn btn-outline-warning" Text="Ocultar Producto" ID="btnOcultar" Visible="false" OnClick="btnOcultar_Click" />
        </div>
    </div>

</asp:Content>
