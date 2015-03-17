<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Default1" %>

<%@ Register Src="SlideShow.ascx" TagPrefix="uc1" TagName="SlideShow" %>
<%@ Register Src="ListeProduit.ascx" TagName="ListeProduit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SlideShow runat="server" ID="SlideShow" />
    <div class="categorie">
        <img src="Images/WebSite/test1Promo.jpg" width="321px" />
        <img src="Images/WebSite/test1Promo.jpg" width="321px" style="padding-left: 15px; padding-right: 15px;" />
        <img src="Images/WebSite/test1Promo.jpg" width="320px" />
    </div>
    <div class="vente">
        <asp:Label runat="server" ID="lblItemEnVenteActuellement" Text="Items en vente actuellement"></asp:Label>
    </div>
    <div class="listeObjetEnPromo">
        <uc2:ListeProduit ID="ListeProduit1" runat="server" Langue='<%#Presenter.CurrentLanguage%>' />
    </div>
</asp:Content>
