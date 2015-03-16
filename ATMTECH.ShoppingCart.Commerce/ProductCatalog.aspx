<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductCatalog.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ProductCatalog" %>

<%@ Import Namespace="ATMTECH.Common.Constant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DataList runat="server" ID="dataListProduitTrouve" RepeatDirection="Horizontal" RepeatColumns="4">
        <ItemTemplate>
            <div style="padding-left: 15px; padding-bottom: 10px;">
                <div class="wrapper">
                    <asp:Panel runat="server" ID="pnlProduitEnVente">
                        <div class="ribbon-wrapper-green">
                            <div class="ribbon-green">
                                <asp:Label runat="server" ID="lblVentes" Text='<%#Presenter.CurrentLanguage == LocalizationLanguage.FRENCH ? "VENTES" : "SALES"%>'></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:HyperLink ID="imgProduit" runat="server" NavigateUrl='<%# "AddProductToBasket.aspx?ProductId=" + Eval("Id")%>'>
                        <asp:Image runat="server" ID="tes" ImageUrl='<%#Eval("PrincipalFileUrl")%>' CssClass="thumbnailImageListeProduitEnVente" />
                    </asp:HyperLink>

                    <br />
                    <asp:Label runat="server" ID="lblNomProduit" Text='<%#Presenter.CurrentLanguage == LocalizationLanguage.FRENCH ? Eval("NameFrench") : Eval("NameEnglish")%>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="lblPrixAvant" Text='<%#Presenter.CurrentLanguage == LocalizationLanguage.FRENCH ? "Était" : "Was"%>' />
                    <asp:Label runat="server" ID="lblPrixActuel" Text='<%#String.Format("{0:C}", Eval("UnitPrice") )%>' CssClass="prixRaye"></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="lblPrixMaintenant" Text='<%#Presenter.CurrentLanguage == LocalizationLanguage.FRENCH ? "Maintenant" : "Now"%>' />
                    <asp:Label runat="server" ID="lblPrixVente" Text='<%#String.Format("{0:C}",Eval("SalePrice"))%>'></asp:Label>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
