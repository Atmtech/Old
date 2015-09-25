<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Default1" %>

<%@ Register Src="UserControls/SlideShowProduct.ascx" TagPrefix="uc1" TagName="SlideShow" %>
<%@ Register Src="UserControls/ListeProduit.ascx" TagName="ListeProduit" TagPrefix="uc2" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <uc1:SlideShow runat="server" ID="SlideShowAccueil" />
    <br />
    <div style="background-image: url('JQuery/jquery-ui-1.11.2/img/SlideShow/black.jpg')">
        <div style='padding-right: 10px; padding-left: 10px;'>
            <div class='slideShowTitreProduit'>Vous avez besoin de personnaliser votre commande ? </div>
            <div class='slideShowDescriptionProduit'>Nous pouvons personnalisé à l'image de votre entreprise tout ce que vous commandez. Nous pouvons vous accompagnez dans cette démarche. 
                <br/><br/>
                
                Donner des exemples:::
                

            </div>
            <div style="padding-top: 10px; padding-bottom: 20px;"><a href='blabla.aspx' class='boutonActionRondSlideShow'>Contacter nous pour plus de détail ...</a></div>
        </div>
    </div>
    <%-- <div style="background-color: white; text-align: center; margin-top: 15px; padding: 10px 10px 10px 10px">
        <div style="margin-bottom: 20px;">
            <a href="ProductCatalog.aspx?Brand=Nike">
                <img src="Images/WebSite/Logonike.jpg" class="imageLogoMarqueAccueil" /></a>
            <a href="ProductCatalog.aspx?Brand=ck">
                <img src="Images/WebSite/Logock.jpg" class="imageLogoMarqueAccueil" /></a>
            <a href="ProductCatalog.aspx?Brand=NewBalance">
                <img src="Images/WebSite/LogoNewBalance.jpg" class="imageLogoMarqueAccueil" /></a>
            <a href="ProductCatalog.aspx?Brand=Oakley">
                <img src="Images/WebSite/LogoOakley.jpg" class="imageLogoMarqueAccueil" /></a>
        </div>
        <div style="margin-bottom: 20px;">
            <a href="ProductCatalog.aspx?Brand=anvil">
                <img src="Images/WebSite/LogoAnvil.jpg" class="imageLogoMarqueAccueil" /></a>
            <a href="ProductCatalog.aspx?Brand=bella">
                <img src="Images/WebSite/LogoBella.jpg" class="imageLogoMarqueAccueil" /></a>
            <a href="ProductCatalog.aspx?Brand=Driduck">
                <img src="Images/WebSite/LogoDriDuck.jpg" class="imageLogoMarqueAccueil" /></a>
            <a href="ProductCatalog.aspx?Brand=Flexfit">
                <img src="Images/WebSite/LogoFLEXFIT.jpg" class="imageLogoMarqueAccueil" /></a>
        </div>
        <div>
            <a href="ProductCatalog.aspx?Brand=Gildan">
                <img src="Images/WebSite/LogoGildan.jpg" class="imageLogoMarqueAccueil" /></a>
            <a href="ProductCatalog.aspx?Brand=OutdoorCap">
                <img src="Images/WebSite/LogoOutdoorCap.jpg" class="imageLogoMarqueAccueil" /></a>
            <a href="ProductCatalog.aspx?Brand=VanHeusen">
                <img src="Images/WebSite/LogoVanHeusen.jpg" class="imageLogoMarqueAccueil" /></a>
            <a href="ProductCatalog.aspx?Brand=Yupoong">
                <img src="Images/WebSite/LogoYupoong.jpg" class="imageLogoMarqueAccueil" /></a>
        </div>
    </div>--%>
    <div class="vente">
        <asp:Label runat="server" ID="lblItemEnVenteActuellement" Text="Items en vente actuellement"></asp:Label>
    </div>
    <div class="listeObjetEnPromo">
        <uc2:ListeProduit ID="ListeProduit" runat="server" Langue='<%#Presenter.CurrentLanguage%>' ProduitParRangee="4" AfficherBoutonTriEtNombreItem="False" />
    </div>
</asp:Content>
