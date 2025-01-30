<%@ Page Title="SAC-NET | Listado de articulos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="TPFinalNivel3_Correa.Listado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="table-responsive">
        <asp:GridView ID="GvListado" runat="server" AutoGenerateColumns="false"
            OnSelectedIndexChanged="GvListado_SelectedIndexChanged" DataKeyNames="Id"
            CssClass="table table-dark table-hover">
            <Columns>
                <asp:BoundField HeaderText="Producto" DataField="Nombre" />
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                <asp:BoundField HeaderText="$" DataField="Precio" DataFormatString="{0:F2}" />
                <asp:CommandField ShowSelectButton="true" SelectText="Click" HeaderText="Acción" />
            </Columns>
        </asp:GridView>
</div>

<asp:Button runat="server" CssClass="btn btn-outline-info" Text="Agregar" ID="btnAgregarArt" OnClick="btnAgregarArt_Click" />
<%if (Ocultos != null && Ocultos.Count >= 1)
        { %>
<asp:Button runat="server" ID="btnOcultos" CssClass="btn btn-outline-warning" Text="Articulos ocultos" OnClick="btnOcultos_Click" />
<%} %>
</asp:Content>
