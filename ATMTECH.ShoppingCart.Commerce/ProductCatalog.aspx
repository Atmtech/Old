<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductCatalog.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ProductCatalog" %>

<%@ Register Src="UserControls/ListeProduit.ascx" TagName="ListeProduit" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlMarque" Visible="false" CssClass="panneauMarqueCatalogue">
        <asp:Image runat="server" ID="imgLogoMarque" CssClass="imageLogoMarqueCatalogue" />
    </asp:Panel>
    <uc2:ListeProduit ID="ListeProduit" runat="server" Langue='<%#Presenter.CurrentLanguage%>' ProduitParRangee="4" AfficherBoutonTriEtNombreItem="True" />
</asp:Content>
