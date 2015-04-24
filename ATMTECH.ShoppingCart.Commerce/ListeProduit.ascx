<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListeProduit.ascx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ListeProduit" %>
<%@ Import Namespace="ATMTECH.Common.Constant" %>
<asp:DataList runat="server" ID="dataListListeProduitEnVente" RepeatDirection="Horizontal" RepeatColumns="4">
    <ItemTemplate>

        <div style="padding-left: 15px; padding-bottom: 10px;">
            <div class="wrapperListeProduit">
                <asp:Panel runat="server" ID="pnlAfficherRubanVert" Visible='<%# Convert.ToDecimal(Eval("SalePrice")) < Convert.ToDecimal(Eval("UnitPrice")) && Convert.ToDecimal(Eval("SalePrice")) != 0 %>'>
                    <div class="ribbon-wrapper-green">
                        <div class="ribbon-green">
                            <asp:Label runat="server" ID="lblVentes" Text='<%#Langue == LocalizationLanguage.FRENCH ? "VENTES" : "SALES"%>'></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <asp:HyperLink ID="imgProduit" runat="server" NavigateUrl='<%# "AddProductToBasket.aspx?ProductId=" + Eval("Id")%>'>
                    <asp:Image runat="server" ID="tes" ImageUrl='<%#Eval("PrincipalFileUrl")%>' CssClass="thumbnailImageListeProduitEnVente" />
                </asp:HyperLink>

                <br />
                <asp:Label runat="server" ID="lblMarque" Text='<%#Eval("Brand")%>'></asp:Label>

                <asp:Label runat="server" ID="lblNomProduit" Text='<%#Langue == LocalizationLanguage.FRENCH ? Eval("NameFrench") : Eval("NameEnglish")%>'></asp:Label>
                <br />

                <asp:Label runat="server" ID="lblPrixActuel" Text='<%#String.Format("{0:C}", Eval("UnitPrice") )%>' CssClass='<%# Convert.ToDecimal(Eval("SalePrice")) < Convert.ToDecimal(Eval("UnitPrice")) && Convert.ToDecimal(Eval("SalePrice")) != 0 ? "prixRaye" : "" %>'></asp:Label>
                <asp:Label runat="server" ID="lblPrixVente" Text='<%#String.Format("{0:C}",Eval("SalePrice"))%>' Visible='<%# Convert.ToDecimal(Eval("SalePrice")) < Convert.ToDecimal(Eval("UnitPrice")) && Convert.ToDecimal(Eval("SalePrice")) != 0 %>'></asp:Label>
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>