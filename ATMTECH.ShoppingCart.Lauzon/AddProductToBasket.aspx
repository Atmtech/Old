<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="AddProductToBasket.aspx.cs" Inherits="ATMTECH.ShoppingCart.Lauzon.AddProductToBasket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="tile triple-vertical triple bg-color-darken">
        <div class="tile-content">
            <div style="float: left; text-align: center; padding-left: 20px; padding-top: 20px;">
                <asp:ImageButton runat="server" ID="imgProductPrincipal" ClientIDMode="Static" OnClick="imgProductPrincipalClick" />
            </div>
            <div style="float: left; padding-left: 20px; padding-top: 20px;">
                <asp:DataList ID="DataListProductFile" RepeatDirection="Vertical" runat="server"
                    OnItemDataBound="ProductFileDataBound" OnItemCommand="ProductFileCommand">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="imgProductFile" CommandName="ChangeImage" Width="50px" Height="50px" />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
    <div class="tile triple-vertical triple bg-color-grayDark">
        <div class="tile-content"  style="overflow: auto; overflow-x: hidden;">
            <h4>
                <asp:Label runat="server" ID="lblIdent" Visible="True"></asp:Label>
                <asp:Label runat="server" ID="lblName"></asp:Label>
            </h4>
            <br />
            <h4>
                <asp:Label runat="server" ID="lblUnitPrice"></asp:Label></h4>
            <br />
            <asp:Label runat="server" ID="lblDescription"></asp:Label>
            <asp:Label runat="server" ID="lblAddToBasketSucessfull" Visible="false" Text="Ajouté avec succès..."></asp:Label>
            <br />
            <br />
            <asp:DataList runat="server" ID="DataListStockNotOrderable" OnItemDataBound="StockDataBound"
                Visible="false" OnItemCommand="StockAddCommand">
                <ItemTemplate>
                    <div style="font-size: 12px;">
                        <asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:DataList runat="server" ID="DataListStockOrderable" OnItemDataBound="StockDataBound"
                Visible="false" OnItemCommand="StockAddCommand">
                <ItemTemplate>
                    <div style="font-size: 12px;">
                        <asp:TextBox runat="server" ID="txtQuantity" ValidationGroup="AddBasket"
                             Width="50px" ForeColor="Black"></asp:TextBox>
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
            <asp:Label runat="server" ID="lblStockNotPresent" Visible="False"></asp:Label>
            <asp:Button runat="server" ID="btnAddAllToBasket" OnClick="AddToBasketClick"
                Text="Ajouter au panier"></asp:Button>
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
    <asp:Label runat="server" ID="lblProductCategoryDescription" Visible="False"> </asp:Label>
</asp:Content>
