﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddProductToBasket.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.AddProductToBasket" %>

<%@ Register Src="ListeCouleur.ascx" TagName="ListeCouleur" TagPrefix="uc2" %>
<%@ Register Src="SlideShowFile.ascx" TagName="SlideShowFile" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="updatePanelAddProduct">
        <ContentTemplate>


            <div class="imageProduit">
                <uc3:SlideShowFile ID="ListeFichier" runat="server" />
            </div>
            <div class="descriptionProduit">
                <div class="titreDescriptionProduit">
                    <asp:Label runat="server" ID="lblIdentProduit"></asp:Label>
                    -
            <asp:Label runat="server" ID="lblNomProduit"></asp:Label>
                </div>
                <div class="prixDescriptionProduit">
                    <asp:Label runat="server" ID="lblPrixUnitaire" CssClass="prixPaye"></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="lblPrixOriginal" CssClass="prixRaye"></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="lblVousEpargnez" Text="Vous épargnez" Visible="False" CssClass="prixEpargner"></asp:Label>
                    <asp:Label runat="server" ID="lblPrixEpargner" Visible="False" CssClass="prixEpargner"></asp:Label>
                </div>
                <div class="quantiteDescriptionProduit">
                    <div>
                        <div class="Table">
                            <div class="Heading">
                                <div class="Cell">
                                    <asp:Label runat="server" ID="lblCaracteristiqueAddProduct" Text="Choisir les caractéristiques"></asp:Label>
                                </div>
                                <div class="Cell">
                                    <asp:Label runat="server" ID="lblQuantiteAddProduct" Text="Quantité"></asp:Label>
                                </div>
                            </div>

                            <div class="Row" style="">
                                <div class="Cell" style="padding-bottom: 10px; width: 300px; text-align: left;">
                                    <atmtech:ComboBox runat="server" ID="ddlStock" Visible="False" />

                                    <asp:Label runat="server" ID="lblCouleur" Text="Couleur"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlCouleur" AutoPostBack="True" OnSelectedIndexChanged="ddlCouleurSelectedIndexChanged" CssClass="dropDownList" Width="100%" />
                                    <asp:Label runat="server" ID="lblTaille" Text="Taille"></asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlTaille" AutoPostBack="True" OnSelectedIndexChanged="ddlTailleSelectedIndexChanged" CssClass="dropDownList" Width="100%" />
                                </div>
                                <div class="Cell" style="">
                                    <br />
                                    <asp:Button runat="server" ID="btnVousDevezEtreConnectePourAjouterQuantite" Text="Identifier vous" OnClick="btnVousDevezEtreConnectePourAjouterQuantiteClick" CssClass="boutonLien"></asp:Button>
                                    <atmtech:Numeric runat="server" NoDecimal="True" ID="txtQuantite" CssClass="textBox" Width="50px" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <uc2:ListeCouleur ID="ListeCouleur" runat="server" />
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

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
