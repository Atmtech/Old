<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductSearch.aspx.cs" Inherits="ATMTECH.ShoppingCart.SagaceMarketing.ProductSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <atmtech:FenetreDialogue runat="server" ID="windowAddToBasket" Largeur="700">
        <atmtech:addproducttobasket runat="server" ID="addProductToBasket"></atmtech:addproducttobasket>
    </atmtech:FenetreDialogue>

    <table style="display: none;">
        <tr>
            <atmtech:TextBoxAvance runat="server" Libelle="Rechercher:" ID="txtSearch" />
            <td>
                <atmtech:Bouton runat="server" ID="btnSearch" OnClick="SearchClick" Text="Rechercher" />
            </td>
        </tr>
    </table>
    <div class="displayProduct">
        <asp:DataList runat="server" ID="dataListProduct" OnItemDataBound="ProductDataBound"
            Width="100%" OnItemCommand="ProductCommand" RepeatDirection="Horizontal" RepeatColumns="3">
            <ItemTemplate>
                <div style="float: left;">
                    <asp:Literal runat="server" ID="lblSpacer" Text="<div style='width:100px;'></div>"></asp:Literal>
                </div>
                <div style="float: left;">
                    <div>
                        <asp:ImageButton runat="server" ID="imgProduct" CommandName="ViewProduct"  Width="200px" />
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
    </div>
</asp:Content>
