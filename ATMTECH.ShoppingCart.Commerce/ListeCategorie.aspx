<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListeCategorie.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ListeCategorie" %>

<%@ Register Src="UserControls/ListeProduit.ascx" TagName="ListeProduit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listeCategorie">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblLesCategories" Text="Catégories de produits"></asp:Label>
        </div>
        <asp:Button runat="server" ID="btnCategorieAccessoire" Text="Accessoires" CssClass="boutonLienCategorie" OnClick="btnCategorieClick" />
        <asp:Button runat="server" ID="btnCategorieChapeau" Text="Chapeau" CssClass="boutonLienCategorie" OnClick="btnCategorieClick" />
        <asp:Button runat="server" ID="btnCategorieGilet" Text="Gilet" CssClass="boutonLienCategorie" OnClick="btnCategorieClick" />
        <asp:Button runat="server" ID="btnCategorieManteau" Text="Manteau" CssClass="boutonLienCategorie" OnClick="btnCategorieClick" />
        <asp:Button runat="server" ID="btnCategoriePantalon" Text="Pantalon" CssClass="boutonLienCategorie" OnClick="btnCategorieClick" />
        <asp:Button runat="server" ID="btnCategoriePolo" Text="Polos" CssClass="boutonLienCategorie" OnClick="btnCategorieClick" />
        <asp:Button runat="server" ID="btnCategorieTshirt" Text="T-shirt" CssClass="boutonLienCategorie" OnClick="btnCategorieClick" />
    </div>
    <uc2:ListeProduit ID="ListeProduit" runat="server" Langue='<%#Presenter.CurrentLanguage%>' ProduitParRangee="4" AfficherBoutonTriEtNombreItem="True" />
</asp:Content>
