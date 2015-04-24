<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Default1" %>

<%@ Register Src="SlideShowProduct.ascx" TagPrefix="uc1" TagName="SlideShow" %>
<%@ Register Src="ListeProduit.ascx" TagName="ListeProduit" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SlideShow runat="server" ID="SlideShowAccueil" />
    <div style="background-color: white; text-align: center; margin-top: 15px; padding: 10px 10px 10px 10px">
        <a href="ProductCatalog.aspx?Brand=anvil"><img src="Images/WebSite/LogoAnvil.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=bella"><img src="Images/WebSite/LogoBella.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=ck"><img src="Images/WebSite/Logock.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=Driduck"><img src="Images/WebSite/LogoDriDuck.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=Flexfit"><img src="Images/WebSite/LogoFLEXFIT.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=Gildan"><img src="Images/WebSite/LogoGildan.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=NewBalance"><img src="Images/WebSite/LogoNewBalance.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=Nike"><img src="Images/WebSite/Logonike.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=OutdoorCap"><img src="Images/WebSite/LogoOutdoorCap.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=VanHeusen"><img src="Images/WebSite/LogoVanHeusen.jpg" class="imageLogoMarqueAccueil" /></a>
        <a href="ProductCatalog.aspx?Brand=Yupoong"><img src="Images/WebSite/LogoYupoong.jpg" class="imageLogoMarqueAccueil" /></a>
    </div>
    <div class="vente">
        <asp:Label runat="server" ID="lblItemEnVenteActuellement" Text="Items en vente actuellement"></asp:Label>
    </div>
    <div class="listeObjetEnPromo">
        <uc2:ListeProduit ID="ListeProduit" runat="server" Langue='<%#Presenter.CurrentLanguage%>' />
    </div>
</asp:Content>
