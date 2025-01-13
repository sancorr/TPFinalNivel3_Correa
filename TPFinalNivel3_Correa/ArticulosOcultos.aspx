<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosOcultos.aspx.cs" Inherits="TPFinalNivel3_Correa.ArticulosOcultos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="" ID="lblOcultosVacio" Visible="false" />
    <div class="row">
        <asp:Repeater runat="server" ID="repeaterOcultos">
            <itemtemplate>
                <div class="col-lg-3 col-md-6 col-12 d-flex align-items-stretch mb-3">
                    <div class="card" style="width: 100%;">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" alt='<%#Eval("Nombre")%>' />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <div>
                                <asp:Button runat="server" ID="btnRestaurar" Text="Restaurar articulo" CssClass="btn btn-success" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" onclick="btnRestaurar_Click"/>
                                <asp:Button runat="server" ID="btnEliminar" Text="Eliminar articulo" CssClass="btn btn-danger" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloIdEliminar" OnClick="btnEliminar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Content>
