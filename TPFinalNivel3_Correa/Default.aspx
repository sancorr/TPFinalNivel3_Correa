<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Correa.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:Repeater runat="server" ID="repeaterHome">
            <itemtemplate>
                <div class="col-lg-3 col-md-6 col-12 d-flex align-items-stretch mb-3">
                    <div class="card" style="width: 100%;">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" alt='<%#Eval("Nombre")%>' />
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
</asp:Content>
