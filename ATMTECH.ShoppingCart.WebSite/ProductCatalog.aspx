<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductCatalog.aspx.cs" Inherits="ATMTECH.ShoppingCart.WebSite.ProductCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="titleProductCatalog" Text="Liste des produits" CssClass="title"></asp:Label>
    <asp:DataList runat="server" ID="dataListCategory" OnItemDataBound="CategoryDataBound"
        Width="100%" OnItemCommand="ProductCommand">
        <ItemTemplate>
            <asp:Panel runat="server" ID="pnlTitleProductCategory" CssClass="titleProductCategory">
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlProduct" Visible="False">
                
                <asp:DataList runat="server" ID="dataListProductByCategory" OnItemDataBound="ProductDataBound"
                    OnItemCommand="ProductCommand" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Image runat="server" ID="imgProduct" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblIdent" runat="server"></asp:Label>
                                        ::
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton runat="server" ID="lnkViewProduct" CssClass="linkButton" Text="[ Voir ce produit ]"
                                            CommandName="ViewProduct"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </ItemTemplate>
                </asp:DataList>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlNoProduct" Visible="False">
                <asp:Label ID="lblNoProductForThisCategory" runat="server" Text="Aucun produit pour cette catégorie"></asp:Label>
            </asp:Panel>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
