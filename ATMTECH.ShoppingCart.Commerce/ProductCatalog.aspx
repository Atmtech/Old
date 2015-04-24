<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductCatalog.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ProductCatalog" %>

<%@ Register Src="ListeProduit.ascx" TagName="ListeProduit" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" ID="pnlMarque" Visible="false" CssClass="panneauMarqueCatalogue">
        <asp:Image runat="server" ID="imgLogoMarque" CssClass="imageLogoMarqueCatalogue" />
    </asp:Panel>

    <div style="font-size: 16px; font-weight: bold; padding-left: 18px; padding-top: 10px;">
        <asp:Label runat="server" ID="lblNombreElementAffichage" Text="Nombre d'élément retrouvé:"></asp:Label>
        <asp:Label runat="server" ID="lblNombreElement"></asp:Label>
    </div>
    <div style="font-size: 16px; padding-left: 18px; padding-top: 10px;">
        <asp:Button runat="server" ID="btnTrierMoinsChereAuPlusChere" Text="Prix: ascendant" CssClass="boutonActionRond" OnClick="btnTrierMoinsChereAuPlusChereClick" />
        <asp:Button runat="server" ID="btnTrierDuPlusChereAuMoinsChere" Text="Prix: descendant" CssClass="boutonActionRond" OnClick="btnTrierDuPlusChereAuMoinsChereClick" />
    </div>
    <uc2:ListeProduit ID="ListeProduit1" runat="server" Langue='<%#Presenter.CurrentLanguage%>' />

</asp:Content>
