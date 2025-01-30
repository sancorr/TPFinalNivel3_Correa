<%@ Page Title="SAC-NET | Articulos ocultos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosOcultos.aspx.cs" Inherits="TPFinalNivel3_Correa.ArticulosOcultos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center">
        <asp:Label runat="server" Text="" Visible="false" ID="lblOcultosVacio" CssClass="alert alert-danger w-80 text-center"/>
    </div>
    <div class="row">
        <asp:Repeater runat="server" ID="repeaterOcultos">
            <itemtemplate>
                <div class="col-lg-3 col-md-6 col-12 d-flex align-items-stretch mb-3">
                    <div class="card" style="width: 100%;">
                        <img CssClass="image-limited" src="<%# string.IsNullOrEmpty((string)Eval("ImagenUrl")) || !Eval("ImagenUrl").ToString().Contains("http") ? "https://imgs.search.brave.com/TvImnNqSmkLvWLy9Y1Hkith2FQJECMibPyhZ122wNb0/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/dmVjdG9yLWdyYXRp/cy9pbHVzdHJhY2lv/bi1jb25jZXB0by1j/YXJwZXRhLWltYWdl/bmVzXzExNDM2MC0x/MTQuanBnP3NlbXQ9/YWlzX2h5YnJpZA" : Eval("ImagenUrl")%>" class="card-img-top img-fluid" alt='<%#Eval("Nombre")%>' />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <div class="d-flex flex-wrap gap-2">
                                <asp:Button runat="server" ID="btnRestaurar" Text="Restaurar articulo" CssClass="btn btn-success w-100" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" onclick="btnRestaurar_Click"/>
                                <asp:Button runat="server" ID="btnEliminar" Text="Eliminar articulo" CssClass="btn btn-danger w-100" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloIdEliminar" OnClick="btnEliminar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Content>
