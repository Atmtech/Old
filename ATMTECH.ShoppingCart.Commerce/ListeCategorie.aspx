<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListeCategorie.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ListeCategorie" %>

<%@ Register Src="ListeProduit.ascx" TagName="ListeProduit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listeCategorie">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblLesCategories" Text="Catégories de produits"></asp:Label>
        </div>

        <ul style="line-height: 30px;list-style-type: none;margin-left: -40px;">
            <li>
                <asp:Button runat="server" ID="btnCategorieAccessoire" Text="Accessoires" CssClass="boutonLien" OnClick="btnCategorieClick" /></li>
            <li>
                <asp:Button runat="server" ID="btnCategorieChapeau" Text="Chapeau" CssClass="boutonLien" OnClick="btnCategorieClick" /></li>
            <li>
                <asp:Button runat="server" ID="btnCategorieGilet" Text="Gilet" CssClass="boutonLien" OnClick="btnCategorieClick" /></li>
            <li>
                <asp:Button runat="server" ID="btnCategorieManteau" Text="Manteau" CssClass="boutonLien" OnClick="btnCategorieClick" /></li>
            <li>
                <asp:Button runat="server" ID="btnCategoriePantalon" Text="Pantalon" CssClass="boutonLien" OnClick="btnCategorieClick" /></li>
            <li>
                <asp:Button runat="server" ID="btnCategoriePolo" Text="Polos" CssClass="boutonLien" OnClick="btnCategorieClick" /></li>
            <li>
                <asp:Button runat="server" ID="btnCategorieTshirt" Text="T-shirt" CssClass="boutonLien" OnClick="btnCategorieClick" /></li>
        </ul>
    </div>
    <div class="listeProduitCategorie">
        <uc2:ListeProduit ID="ListeProduit" runat="server" Langue='<%#Presenter.CurrentLanguage%>' />
    </div>

    <div style="clear: both;"></div>
</asp:Content>
