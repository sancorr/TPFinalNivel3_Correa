<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3_Correa.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="" Visible="false" ID="lblMensaje" />
    <div class="row">
        <asp:Repeater runat="server" ID="repeaterFavoritos">
            <itemtemplate>
                <div class="col-lg-3 col-md-6 col-12 d-flex align-items-stretch mb-3">
                    <div class="card" style="width: 100%;">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" alt='<%#Eval("Nombre")%>' />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <asp:Button runat="server" ID="btnEliminarFavoritos" Text="Quitar" CssClass="btn btn-warning" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnEliminarFavoritos_Click" />
                        </div>
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Content>
