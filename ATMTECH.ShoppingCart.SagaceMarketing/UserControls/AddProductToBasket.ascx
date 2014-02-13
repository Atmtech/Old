<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProductToBasket.ascx.cs"
    Inherits="ATMTECH.ShoppingCart.SagaceMarketing.UserControls.AddProductToBasket" %>
<script type="text/javascript" language="javascript">
    function changeImage(img) {
        document.getElementById('imgProductPrincipal').src = img;
    }
</script>
<asp:Panel runat="server" ID="pnlError" CssClass="panelError" Visible="False">
    <asp:Literal runat="server" ID="lblError"></asp:Literal>
</asp:Panel>
<table>
    <tr>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:ImageButton runat="server" ID="imgProductPrincipal" ClientIDMode="Static" />
                    </td>
                    <td valign="top">
                        <asp:DataList ID="DataListProductFile" RepeatDirection="Vertical" runat="server"
                            OnItemDataBound="ProductFileDataBound" OnItemCommand="ProductFileCommand">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgProductFile" CommandName="ChangeImage" CssClass="productFileThumbNail"
                                    Width="50px" Height="50px" />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" style="border-left: solid 1px gray; padding-left: 10px;">
            <table>
                <tr>
                    <td>
                        <div class="productIdent">
                            <asp:Label ID="lblIdent" runat="server"></asp:Label>
                        </div>
                        <div>
                            <div style="float: left" class="productName">
                                <asp:Label runat="server" ID="lblName" CssClass="productViewButton"></asp:Label>
                            </div>
                            <div style="float: left; padding-left: 10px;">
                                <asp:Label runat="server" ID="lblUnitPrice" CssClass="productPrice"></asp:Label>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 20px;">
                        <asp:Label runat="server" ID="lblDescription"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 0px;">
                        <asp:Label runat="server" ID="lblAddToBasketSucessfull" Visible="false" Text="Ajouté avec succès..."></asp:Label>
                        <asp:DataList runat="server" ID="DataListStockNotOrderable" OnItemDataBound="StockDataBound"
                            Visible="false" OnItemCommand="StockAddCommand">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label><br />
                                <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtQuantity" ValidationGroup="AddBasket"
                                    Visible="False" TypeSaisie="Numerique" EstObligatoire="true"></atmtech:AlphaNumTextBoxAvance>
                                <asp:Button runat="server" ID="btnAddToBasket" CommandName="Add" Text="Ajouter au panier"
                                    ValidationGroup="AddBasket" Visible="False" />
                                <asp:Label runat="server" ID="lblStock" Text="Quantité en inventaire:" CssClass="stockDisplay"></asp:Label>
                                <asp:Label runat="server" ID="lblStockQuantity" Text="" CssClass="stockDisplay"></asp:Label>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:DataList runat="server" ID="DataListStockOrderable" OnItemDataBound="StockDataBound"
                            Visible="false" OnItemCommand="StockAddCommand">
                            <ItemTemplate>
                                <br />
                                <b><asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label></b>
                                <br>
                                <br />
                                <asp:Label runat="server" ID="lblQuantityDisplay"></asp:Label>
                                <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtQuantity" ValidationGroup="AddBasket"
                                    TypeSaisie="Numerique" EstObligatoire="true" Width="50px"></atmtech:AlphaNumTextBoxAvance>
                                <asp:Button runat="server" ID="btnAddToBasket" CommandName="Add" Text="Ajouter au panier"
                                    ValidationGroup="AddBasket" CssClass="button" />
                                <br />
                                <asp:Label runat="server" ID="lblStock" Text="Quantité en inventaire:" CssClass="stockDisplay"></asp:Label>
                                <asp:Label runat="server" ID="lblStockQuantity" Text="" CssClass="stockDisplay"></asp:Label>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Label runat="server" ID="lblStockNotPresent" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:Label runat="server" ID="lblCostPrice" Visible="False"></asp:Label>
<asp:Label runat="server" ID="lblDisplayWeight" Visible="False"></asp:Label>
<asp:Label runat="server" ID="lblWeight" Visible="False"></asp:Label>
<asp:Label runat="server" ID="lblUnitWeight" Visible="False"></asp:Label>
<asp:Label runat="server" ID="lblProductCategoryDescription" Visible="False"> </asp:Label>
