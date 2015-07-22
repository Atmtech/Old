<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListeProduit.ascx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.UserControls.ListeProduit" %>
<%@ Import Namespace="ATMTECH.Common.Constant" %>

<asp:Panel runat="server" ID="pnlBoutonTriNombreElement">
    <div style="font-size: 16px; padding-top: 10px;">
        <asp:Button runat="server" ID="btnTrierMoinsChereAuPlusChere" Text="Prix: ascendant" CssClass="boutonActionRondFinaliser" Width="300px" OnClick="btnTrierMoinsChereAuPlusChereClick" />
        <asp:Button runat="server" ID="btnTrierDuPlusChereAuMoinsChere" Text="Prix: descendant" CssClass="boutonActionRondFinaliser"  Width="300px" OnClick="btnTrierDuPlusChereAuMoinsChereClick" />
    </div>
    <div style="font-size: 16px; font-weight: bold; padding-top: 10px;">
        <asp:Label runat="server" ID="lblNombreElementAffichage" Text="Nombre d'élément retrouvé:"></asp:Label>
        <asp:Label runat="server" ID="lblNombreElement" Text="0"></asp:Label>
    </div>
</asp:Panel>
<asp:DataList runat="server" ID="dataListListeProduitEnVente" RepeatDirection="Horizontal" RepeatColumns="4" OnItemDataBound="dataListListeProduitEnVenteOnItemDataBound">
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
                <asp:HyperLink ID="imgProduit" runat="server" NavigateUrl='<%# "~/AddProductToBasket.aspx?ProductId=" + Eval("Id")%>'>
                    <asp:Image runat="server" ID="imageProduit" ImageUrl='<%#"~/" +Eval("PrincipalFileUrl")%>'/>
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