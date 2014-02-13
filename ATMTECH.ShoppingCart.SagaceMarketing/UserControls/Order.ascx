<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Order.ascx.cs" Inherits="ATMTECH.ShoppingCart.SagaceMarketing.UserControls.Order" %>
<asp:Label runat="server" ID="lblOrderNumber" Text="Numéro de commande:"></asp:Label>
<asp:Label runat="server" ID="lblOrderId"></asp:Label>
<asp:GridView runat="server" ID="grvBasket" AutoGenerateColumns="false" CssClass="basketGrid"
    ShowHeader="False">
    <HeaderStyle CssClass="basketGridHeader" />
    <FooterStyle CssClass="basketGridFooter" />
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label runat="server" ID="lblIdent" Text='<%#Eval("Stock.Product.Ident")%>'></asp:Label>
                <asp:Label runat="server" ID="lblProductName" Text='<%#Eval("Stock.Product.Name")%>'></asp:Label>
                <asp:Label runat="server" ID="lblStockFeature" Text='<%# "(" +Eval("Stock.Feature") + ")" %>'></asp:Label>)
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label runat="server" ID="lblQuantity" Text='<%#Eval("Quantity")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<table>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblSubTotalLabel" Text="Sous-total:"></asp:Label>
        </td>
        <td>
            <asp:Label runat="server" ID="lblSubTotal" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblShippingTotalLabel" Text="Livraison:"></asp:Label>
        </td>
        <td>
            <asp:Label runat="server" ID="lblShippingTotal" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblSubTotalTaxesRegionLabel" Text="TVQ:"></asp:Label>
        </td>
        <td>
            <asp:Label runat="server" ID="lblSubTotalTaxesRegion" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblSubTotalTaxesCountryLabel" Text="TPS:"></asp:Label>
        </td>
        <td>
            <asp:Label runat="server" ID="lblSubTotalTaxesCountry" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblGrandTotalLabel" Text="Grand total:"></asp:Label>
        </td>
        <td>
            <asp:Label runat="server" ID="lblGrandTotal" />
        </td>
    </tr>
</table>
