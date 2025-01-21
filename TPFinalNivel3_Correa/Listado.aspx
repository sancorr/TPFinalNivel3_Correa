<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="TPFinalNivel3_Correa.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GvListado" runat="server" AutoGenerateColumns="false" 
        OnSelectedIndexChanged="GvListado_SelectedIndexChanged" DataKeyNames="Id"
        >
        <Columns>
            <asp:BoundField HeaderText="Producto" DataField="Nombre" />
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
            <asp:BoundField HeaderText="$" DataField="Precio" DataFormatString="{0:F2}" />
            <asp:CommandField ShowSelectButton="true" SelectText="Click" HeaderText="Acción"/>
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" CssClass="bnt btn-primary" Text="Agregar" ID="btnAgregarArt" OnClick="btnAgregarArt_Click"/>
    <%if (Ocultos != null && Ocultos.Count >= 1)
        { %>
    <asp:Button runat="server" ID="btnOcultos" CssClass="btn btn-primary" Text="Articulos ocultos" OnClick="btnOcultos_Click" />
    <%} %>
</asp:Content>
