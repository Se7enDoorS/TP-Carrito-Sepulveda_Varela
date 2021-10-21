<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>MERCADOESCLAVO</h3>
        <p class="lead">Carrito de Compras</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row" style="display:flex; justify-content:space-evenly; padding:10px">
        <div class="card" style="width:25rem; border:solid 2px grey; padding:10px">
            <h4 class="card-title">Articulo 1</h4>
            <h6 class="card-subtitle mb-2 text-muted">Categoria</h6>
            <p class="card-text">Descripcion del articulo para asegurarnos de que realice el wrapping de un texto hiper recontra archi largo que ya no se que más escribir</p>
            <a href="Carrito.aspx" class="card-link">Añadir al Carrito</a>
        </div>
    </div>

    
</asp:Content>
