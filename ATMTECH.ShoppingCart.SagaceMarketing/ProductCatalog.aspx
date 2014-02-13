<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductCatalog.aspx.cs" Inherits="ATMTECH.ShoppingCart.SagaceMarketing.ProductCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <atmtech:FenetreDialogue runat="server" ID="windowAddToBasket" Largeur="900">
        <atmtech:AddProductToBasket runat="server" ID="addProductToBasket"></atmtech:AddProductToBasket>
    </atmtech:FenetreDialogue>
    <asp:Label runat="server" ID="titleProductCatalog" Text="Liste des produits" CssClass="title"
        Visible="False"></asp:Label>
    <asp:DataList runat="server" ID="dataListCategory" OnItemDataBound="CategoryDataBound"
        Width="100%" OnItemCommand="ProductCommand">
        <ItemTemplate>
            <asp:Panel runat="server" ID="pnlTitleProductCategory" CssClass="titleProductCategory">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlProduct" Visible="False">
                <asp:DataList runat="server" ID="dataListProductByCategory" OnItemDataBound="ProductDataBound"
                    OnItemCommand="ProductCommand" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <div style="float: left;">
                            <asp:Literal runat="server" ID="lblSpacer" Text="<div style='width:100px;'></div>"></asp:Literal>
                        </div>
                        <div style="float: left;">
                            <div style="float: center;">
                                <asp:ImageButton runat="server" ID="imgProduct" CommandName="ViewProduct" Width="200px" />
                            </div>
                            <div class="productIdent">
                                <asp:Label ID="lblIdent" runat="server"></asp:Label>
                            </div>
                            <div>
                                <div style="float: left" class="productName">
                                    <asp:Button ID="btnName" runat="server" CssClass="productViewButton" CommandName="ViewProduct">
                                    </asp:Button>
                                </div>
                                <div style="float: left; padding-left: 10px;">
                                    <asp:Label runat="server" ID="lblUnitPrice" CssClass="productPrice"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlNoProduct" Visible="False">
                <asp:Label ID="lblNoProductForThisCategory" runat="server" Text="Aucun produit pour cette catégorie"></asp:Label>
            </asp:Panel>
        </ItemTemplate>
    </asp:DataList>
    
     <asp:Panel runat="server" ID="pnlNoCategory" Visible="False">
                <asp:Label ID="lblNoCategory" runat="server" Text="Aucune catégorie"></asp:Label>
    </asp:Panel>

</asp:Content>
