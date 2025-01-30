<%@ Page Title="SAC-NET | Detalles" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPFinalNivel3_Correa.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:Repeater runat="server" ID="repeaterDetalle">
            <ItemTemplate>
                <div class="col-lg-12 col-md-6 col-12 d-flex justify-content-center mb-3">
                    <div class="card" style="width: 15rem;">
                        <img src="<%# string.IsNullOrEmpty((string)Eval("ImagenUrl")) || !Eval("ImagenUrl").ToString().Contains("http") ? "https://imgs.search.brave.com/TvImnNqSmkLvWLy9Y1Hkith2FQJECMibPyhZ122wNb0/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/dmVjdG9yLWdyYXRp/cy9pbHVzdHJhY2lv/bi1jb25jZXB0by1j/YXJwZXRhLWltYWdl/bmVzXzExNDM2MC0x/MTQuanBnP3NlbXQ9/YWlzX2h5YnJpZA" : Eval("ImagenUrl")%>" class="card-img-top img-fluid" alt='<%#Eval("Nombre")%>' />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <p class="card-text">$ <%#String.Format("{0:F2}", Eval("Precio"))%></p>
                            <%if (TPFinalNivel3_Correa.negocio.Seguridad.sesionActiva(Session["sesionAbierta"]))
                                {%>
                            <div class="d-flex flex-column align-items-center">
                                <asp:Button runat="server" ID="btnFavoritos" Text="Agregar a favoritos" CssClass="btn btn-success mb-2" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnFavoritos_Click" />
                                <asp:Label runat="server" ID="lblFavoritos" Text="" Visible="false" CssClass="alert alert-info w-100 text-center" />
                            </div>
                            <%} %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
