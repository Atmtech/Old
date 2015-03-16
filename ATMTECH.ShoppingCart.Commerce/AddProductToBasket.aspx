<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddProductToBasket.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.AddProductToBasket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="imageProduit">
        <asp:ImageButton runat="server" ID="imgProductPrincipal" ClientIDMode="Static" OnClick="imgProductPrincipalClick" CssClass="imageProduitAfficher" />
        <asp:DataList ID="DataListProductFile" RepeatDirection="Horizontal" runat="server"
            OnItemDataBound="ProductFileDataBound" OnItemCommand="ProductFileCommand">
            <ItemTemplate>
                <asp:ImageButton runat="server" ID="imgProductFile" CommandName="ChangeImage" Width="50px" Height="50px" />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="descriptionProduit">
        <div class="titreDescriptionProduit">
            <asp:Label runat="server" ID="lblIdentProduit"></asp:Label>
            -
            <asp:Label runat="server" ID="lblNomProduit"></asp:Label>
        </div>
        <div class="prixDescriptionProduit">
            <asp:Label runat="server" ID="lblPrixUnitaire" CssClass="prixPaye"></asp:Label>
            <br/>
            <asp:Label runat="server" ID="lblVousEpargnez" Text="Vous épargnez" Visible="False" CssClass="prixEpargner"></asp:Label>  <asp:Label runat="server" ID="lblPrixEpargner" Visible="False" CssClass="prixEpargner"></asp:Label>
        </div>
        <div class="quantiteDescriptionProduit">
            <div>
                <div class="Table">
                    <div class="Heading">
                        <div class="Cell">
                            <asp:Label runat="server" ID="lblCaracteristiqueAddProduct" Text="Choisir une caractéristique"></asp:Label>
                        </div>
                        <div class="Cell">
                            <asp:Label runat="server" ID="lblQuantiteAddProduct" Text="Quantité"></asp:Label>
                        </div>
                    </div>

                    <div class="Row" style="">
                        <div class="Cell" style="padding-top: 5px; padding-bottom: 5px; width: 300px; text-align: left;">
                            <atmtech:ComboBox runat="server" ID="ddlStock" />
                        </div>
                        <div class="Cell">
                            <asp:Button runat="server" ID="btnVousDevezEtreConnectePourAjouterQuantite" Text="Identifier vous" OnClick="btnVousDevezEtreConnectePourAjouterQuantiteClick" CssClass="boutonLien"></asp:Button>
                            <atmtech:Numeric runat="server" NoDecimal="True" ID="txtQuantite" CssClass="textBox" />
                        </div>
                    </div>
                </div>
                <br />
                <asp:Button runat="server" ID="btnAjouterLigneCommande" OnClick="btnAjouterLigneCommandeClick" CssClass="boutonActionRond"
                    Text="Ajouter au panier"></asp:Button>
            </div>
        </div>
        <div class="detailDescriptionProduit">
            <div style="float: left; padding-right: 10px;">
                <iframe id="twitter-widget-0" scrolling="no" frameborder="0" allowtransparency="true" src="http://platform.twitter.com/widgets/tweet_button.67ae45a68af44ab435dd5797206058d3.en.html#_=1423083634059&amp;count=none&amp;dnt=false&amp;id=twitter-widget-0&amp;lang=en&amp;original_referer=http%3A%2F%2Frutherford-romaguera2611.myshopify.com%2Fproducts%2Fbreitling-transocean&amp;size=m&amp;text=Breitling%20Transocean%20by%20Breitling&amp;url=http%3A%2F%2Frutherford-romaguera2611.myshopify.com%2Fproducts%2Fbreitling-transocean" class="twitter-share-button twitter-tweet-button twitter-share-button twitter-count-none" title="Twitter Tweet Button" data-twttr-rendered="true" style="width: 56px; height: 20px;"></iframe>
            </div>
            <div style="float: left;">
                <iframe src="//www.facebook.com/plugins/like.php?href=http://rutherford-romaguera2611.myshopify.com/products/breitling-transocean&amp;layout=button_count&amp;show_faces=true&amp;width=450&amp;action=like&amp;colorscheme=light&amp;height=21" scrolling="no" frameborder="0" style="border: none; overflow: hidden; width: 80px; height: 30px" allowtransparency="true"></iframe>
            </div>
            <div style="clear: both;"></div>
            <div style="padding-bottom: 10px;">
                <asp:Label runat="server" ID="lblDetail" Text="Détails"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" ID="lblDescription"></asp:Label>
            </div>
        </div>
    </div>
    <div style="clear: both;"></div>



</asp:Content>
