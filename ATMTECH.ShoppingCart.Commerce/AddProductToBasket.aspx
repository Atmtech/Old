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
            <asp:Label runat="server" ID="lblIdent" Visible="True" Text="Test"></asp:Label><asp:Label runat="server" ID="lblName" Text="test"></asp:Label>
        </div>
        <div class="prixDescriptionProduit">
            <asp:Label runat="server" ID="lblUnitPrice" Text="$ 100.00"></asp:Label>
        </div>

        <div class="quantiteDescriptionProduit">
            <asp:Label runat="server" ID="lblQuantiteTitre" Text="Quantité"></asp:Label>

            <div style="padding-top: 20px;">

                <asp:DataList runat="server" ID="DataListStockOrderable" OnItemDataBound="StockDataBound"
                    Visible="false" OnItemCommand="StockAddCommand">
                    <ItemTemplate>
                        <div style="font-size: 12px;">
                            <atmtech:Numeric runat="server" ID="txtQuantity" Width="50px" ForeColor="Black" NoDecimal="True"></atmtech:Numeric>
                            <asp:Label runat="server" ID="lblStockId" Visible="False"></asp:Label>
                            <asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label>
                            <asp:Label runat="server" ID="lblQuantityDisplay"></asp:Label>
                            <td>
                                <asp:Label runat="server" ID="lblStock"></asp:Label>
                                <asp:Label runat="server" ID="lblStockQuantity" Text=""></asp:Label>
                            </td>
                        </div>
                    </ItemTemplate>
                </asp:DataList>



                <asp:Button runat="server" ID="btnAddAllToBasket" OnClick="AddToBasketClick" CssClass="boutonActionRond"
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
            <div>
                Détails
            </div>
        </div>
    </div>
    <div style="clear: both;"></div>

    <%--  <div class="tile triple-vertical triple bg-color-darken">
        <div class="tile-content">
            <div style="float: left; text-align: center; padding-left: 20px; padding-top: 20px;">
                <br/>
               
            </div>
            <div style="float: left; padding-left: 20px; padding-top: 20px;">
                
            </div>
        </div>
    </div>
    <div class="tile triple-vertical triple bg-color-grayDark">
        <div class="tile-content" style="overflow: auto; overflow-x: hidden;">
            <h4>
                
                
            </h4>
            <br />
            <h4>
                </h4>
            <br />
            <asp:Label runat="server" ID="lblDescription"></asp:Label>
            <asp:Label runat="server" ID="lblAddToBasketSucessfull" Visible="false" Text="Ajouté avec succès..."></asp:Label>
            <br />
            <br />
           
            <asp:Label runat="server" ID="lblStockNotPresent" Visible="False"></asp:Label>
           
            <asp:Button runat="server" ID="btnContinueShopping" OnClick="RedirectProductCatalog"
                Text="Continuer le magasinage"></asp:Button>
            <br />
            <b>
                <asp:Label runat="server" ID="lblCannotOrderBecauseSecurity" Visible="False" ForeColor="Red"></asp:Label></b>
        </div>
    </div>
    <asp:Label runat="server" ID="lblCostPrice" Visible="False"></asp:Label>
    <asp:Label runat="server" ID="lblDisplayWeight" Visible="False"></asp:Label>
    <asp:Label runat="server" ID="lblWeight" Visible="False"></asp:Label>
    <asp:Label runat="server" ID="lblUnitWeight" Visible="False"></asp:Label>
    <asp:Label runat="server" ID="lblProductCategoryDescription" Visible="False"> </asp:Label>--%>
</asp:Content>
