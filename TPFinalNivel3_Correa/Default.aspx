<%@ Page Title="SAC-NET | Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Correa.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManagerFiltro"></asp:ScriptManager>

    <asp:UpdatePanel runat="server" ID="UpdatePanelFiltro">
        <ContentTemplate>
            <div class="container my-4">
                <div class="row">
                    <p>Buscar productos</p>
                    <asp:Label runat="server" Visible="false" Text="" ID="lblError" />
                    <asp:Label runat="server" Visible="false" Text="" ID="lblResBusqueda" />
                </div>


                <div class="mb-3">

                    <div class="row g-2">

                        <div class="col-12 col-sm-4 col-md-3">
                            <asp:DropDownList CssClass="form-select" runat="server" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>

                        <div class="col-12 col-sm-4 col-md-3">
                            <asp:DropDownList CssClass="form-select" runat="server" ID="ddlCriterio"></asp:DropDownList>
                        </div>

                        <div class="col-12 col-sm-4 col-md">
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbxFiltro"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mt-3 text-center text-sm-start">
                        <div class="col">
                            <asp:Button runat="server" CssClass="btn btn-success me-2" ID="btnBuscarFiltro" Text="Buscar" OnClick="btnBuscarFiltro_Click" />
                            <a href="Default.aspx" class="btn btn-link">Volver</a>
                        </div>
                    </div>
                </div>
            </div>


            <div class="container">
                <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 g-4">
                    <asp:Repeater runat="server" ID="repeaterHome">
                        <ItemTemplate>

                            <div class="col">
                                <div class="card h-100">
                                    <img src="<%# string.IsNullOrEmpty((string)Eval("ImagenUrl")) || !Eval("ImagenUrl").ToString().Contains("http") ? "https://imgs.search.brave.com/TvImnNqSmkLvWLy9Y1Hkith2FQJECMibPyhZ122wNb0/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/dmVjdG9yLWdyYXRp/cy9pbHVzdHJhY2lv/bi1jb25jZXB0by1j/YXJwZXRhLWltYWdl/bmVzXzExNDM2MC0x/MTQuanBnP3NlbXQ9/YWlzX2h5YnJpZA" : Eval("ImagenUrl")%>" class="card-img-top img-fluid image-limited" alt='<%#Eval("Nombre")%>' />
                                    <div class="card-body d-flex flex-column">
                                        <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                        <p class="card-text text-truncate"><%#Eval("Descripcion")%></p>
                                        <asp:Button runat="server" ID="btnVerDetaller" Text="Ver Detalle" CssClass="btn btn-primary mt-auto" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnVerDetaller_Click" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
