<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Correa.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManagerFiltro"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanelFiltro">
        <contenttemplate>
            <asp:CheckBox runat="server" ID="chkFiltro" Text="Buscar productos" AutoPostBack="true" OnCheckedChanged="chkFiltro_CheckedChanged" />
            <%if (chkFiltro.Checked)
                { %>
            <div class="row">
                <p>Buscar productos</p>
                <asp:Label runat="server" Visible="false" Text="" ID="lblError" />
                <asp:Label runat="server" Visible="false" Text="" ID="lblResBusqueda" />

                <div class="mb-3">
                    <asp:Label runat="server" CssClass="form-label">Campo</asp:Label>
                    <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle" runat="server" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true" />
                    <asp:DropDownList runat="server" CssClass="btn btn-secondary dropdown-toggle" ID="ddlCriterio" />
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbxFiltro" />
                    <asp:Button runat="server" CssClass="btn btn-success" ID="btnBuscarFiltro" Text="Buscar" OnClick="btnBuscarFiltro_Click" />
                    <a href="Default.aspx">Volver</a>
                </div>
            </div>
            <%} %>


            <div class="row">
                <asp:Repeater runat="server" ID="repeaterHome">
                    <itemtemplate>
                        <div class="col-lg-3 col-md-6 col-12 d-flex align-items-stretch mb-3">
                            <div class="card" style="width: 100%;">
                                <img src="<%# string.IsNullOrEmpty((string)Eval("ImagenUrl")) || !Eval("ImagenUrl").ToString().Contains("http") ? "https://imgs.search.brave.com/TvImnNqSmkLvWLy9Y1Hkith2FQJECMibPyhZ122wNb0/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/dmVjdG9yLWdyYXRp/cy9pbHVzdHJhY2lv/bi1jb25jZXB0by1j/YXJwZXRhLWltYWdl/bmVzXzExNDM2MC0x/MTQuanBnP3NlbXQ9/YWlzX2h5YnJpZA" : Eval("ImagenUrl")%>" class="card-img-top img-fluid" alt='<%#Eval("Nombre")%>' />
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                    <p class="card-text"><%#Eval("Descripcion")%></p>
                                    <asp:Button runat="server" ID="btnVerDetaller" Text="Ver Detalle" CssClass="btn btn-primary" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnVerDetaller_Click" />
                                </div>
                            </div>
                        </div>
                    </itemtemplate>
                </asp:Repeater>
            </div>
        </contenttemplate>
    </asp:UpdatePanel>


</asp:Content>
