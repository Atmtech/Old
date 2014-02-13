<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductInformation.aspx.cs" Inherits="ATMTECH.ShoppingCart.WebSite.AddProductToBasket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <atmtech:FenetreDialogue runat="server" ID="windowDisplayImage" Titre="Produits"
        Hauteur="400px" Largeur="500px">
        <div style="text-align: center;">
            <asp:Image runat="server" ID="imgDisplayImage" />
        </div>
    </atmtech:FenetreDialogue>
    <asp:Label runat="server" ID="titleProductInformation" Text="Information sur le produit"
        CssClass="title"></asp:Label>
    <table>
        <tr>
            <td>
                <asp:ImageButton runat="server" ID="imgProductPrincipal" OnClick="OpenWindowImage" />
                <asp:DataList ID="DataListProductFile" RepeatDirection="Horizontal" RepeatColumns="3"
                    runat="server" OnItemDataBound="ProductFileDataBound" OnItemCommand="ProductFileCommand">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="imgProductFile" CommandName="ChangeImage" />
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td valign="top">
                <table>
                    <tr>
                        <atmtech:ContenuLabelAvance runat="server" ID="lblName" Libelle="Nom:"></atmtech:ContenuLabelAvance>
                    </tr>
                    <tr>
                        <atmtech:ContenuLabelAvance runat="server" ID="lblIdent" Libelle="No produit:"></atmtech:ContenuLabelAvance>
                    </tr>
                    <tr>
                        <atmtech:ContenuLabelAvance runat="server" ID="lblUnitPrice" Libelle="Prix:"></atmtech:ContenuLabelAvance>
                    </tr>
                    <tr>
                        <atmtech:ContenuLabelAvance runat="server" ID="lblCostPrice" Libelle="Prix coutant:">
                        </atmtech:ContenuLabelAvance>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblDisplayWeight" Text="Poids:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblWeight"></asp:Label>
                            <asp:Label runat="server" ID="lblUnitWeight" Text="Lbs."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <atmtech:ContenuLabelAvance runat="server" ID="lblProductCategoryDescription" Libelle="Catégorie:">
                        </atmtech:ContenuLabelAvance>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DataList runat="server" ID="DataListStockNotOrderable" OnItemDataBound="StockDataBound"
                                Visible="false" OnItemCommand="StockAddCommand">
                                <HeaderTemplate>
                                    <table class="stockGrid">
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label>
                                            </td>
                                            <td style="display: none;">
                                                <asp:Label runat="server" ID="lblQuantityProductInformation" Text="Quantité"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblDescription"></asp:Label>
                                        </td>
                                        <td style="display: none;">
                                            <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtQuantity" Visible="False" EstNumeriqueSeul="true"
                                                EstObligatoire="true"></atmtech:AlphaNumTextBoxAvance>
                                        </td>
                                        <td style="display: none;">
                                            <asp:Button runat="server" ID="btnAddToBasket" CommandName="Add" Text="Ajouter au panier"
                                                Visible="False" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:DataList>
                            <asp:DataList runat="server" ID="DataListStockOrderable" OnItemDataBound="StockDataBound"
                                Visible="false" OnItemCommand="StockAddCommand">
                                <HeaderTemplate>
                                    <table class="stockGrid">
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblQuantityProductInformation" Text="Quantité"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblDescription"></asp:Label>
                                        </td>
                                        <td>
                                            <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtQuantity" ValidationGroup="AddBasket"
                                                TypeSaisie="Numerique" EstObligatoire="true"></atmtech:AlphaNumTextBoxAvance>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btnAddToBasket" CommandName="Add" Text="Ajouter au panier"
                                                ValidationGroup="AddBasket" />
                                                  <asp:Label runat="server" ID="lblStock" Text="Quantité en inventaire:"></asp:Label>
                                            <asp:Label runat="server" ID="lblStockQuantity" Text=""></asp:Label>
                                        </td>
                                        
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <atmtech:TitreLabelAvance runat="server" ID="lblAddToBasketSucessfull" Visible="false"
        Text="Ajouté avec succès..."></atmtech:TitreLabelAvance>
</asp:Content>
