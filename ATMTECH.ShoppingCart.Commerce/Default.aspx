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
            <div class='slideShowTitreProduit'>
                <asp:Label runat="server" ID="lblTitrePersonnaliseCommande" Text="Vous avez besoin de personnaliser votre commande ?"></asp:Label>
            </div>
            <div class='slideShowDescriptionProduit'>
                <br />
                
                <asp:Label runat="server" ID="lblDescriptionPersonnaliseCommande" Text="<b>MÉTHODE DE DÉCORATION</b><br><br>Plusieurs méthodes de décoration peuvent s'offrir à vous selon l'item choisi. Nous vous aiderons à choisir le meilleur procédé, selon les options disponibles, et selon le matériel choisi.<br><br> Sur les vêtements: broderie à plat, en 3D, sérigraphie, transfert, impression.<br><br><b>INFOGRAPHIE</b><br><br>Pour éviter plusieurs tracas, CHECKLEPRIX offre également le service d'infographie afin de mieux personnaliser vos vêtements."></asp:Label>
                <br />
                <br />
                <img src="Images/WebSite/Service1.jpg" style="width: 150px; padding-right: 5px;" /><img src="Images/WebSite/services2.jpg" style="width: 150px; padding-right: 5px;" /><img src="Images/WebSite/services3.jpg" style="width: 150px; padding-right: 5px;" />
            </div>
            <div style="padding-top: 10px; padding-bottom: 20px;"><a href='Contact.aspx' class='boutonActionRondSlideShow'>Contacter nous pour plus de détail ...</a></div>
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
