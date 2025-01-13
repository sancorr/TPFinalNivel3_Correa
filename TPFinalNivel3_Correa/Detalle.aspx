<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPFinalNivel3_Correa.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:Repeater runat="server" ID="repeaterDetalle">
            <itemtemplate>
                <div class="col-lg-12 col-md-6 col-12 d-flex justify-content-center mb-3">
                    <div class="card" style="width: 15rem;">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" alt='<%#Eval("Nombre")%>' />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <asp:Button runat="server" ID="btnFavoritos" Text="Agregar a favoritos" CssClass="btn btn-success" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnFavoritos_Click" />
                        </div>
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Content>
