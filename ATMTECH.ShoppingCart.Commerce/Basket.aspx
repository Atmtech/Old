<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Basket.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="grdPanier" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Article(s)">
                <ItemTemplate>
                    <div style="float: left;">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ThumbNail.aspx?width=109&height=104&directory=images/product/&filename=" +Eval("Stock.Product.PrincipalFileUrlWithoutDirectory")  %>'></asp:Image>
                    </div>
                    <div style="float: left; padding-left: 10px;">
                        <asp:Label runat="server" ID="lblIdent" Text='<%#Eval("Stock.Product.Ident")%>'></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblNom" Text='<%# Session["currentLanguage"].ToString().Equals("fr") ?  Eval("Stock.Product.NameFrench") : Eval("Stock.Product.NameEnglish")%>'></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblCaracteristique" Text='<%# Session["currentLanguage"].ToString().Equals("fr") ?  Eval("Stock.FeatureFrench") : Eval("Stock.FeatureEnglish")  %>'></asp:Label>

                        <asp:Label runat="server" ID="lblPrixAjuste" Text='<%# "( +" + Eval("Stock.AdjustPrice","{0:c}") + ")"  %>' Visible='<%#  Convert.ToDecimal(Eval("Stock.AdjustPrice")) > 0 %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantité">
                <ItemTemplate>
                    <atmtech:Numeric runat="server" ID="txtQuantite" Text='<%#Eval("Quantity")%>' NoDecimal="True" Width="50px" CssClass="textBox"></atmtech:Numeric>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Prix">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblPrixUnitaire" Text='<%# Eval("Stock.StockPrice","{0:c}")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Retirer">
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="lnkSupprimer" CommandName="SupprimerLigneCommande" ImageUrl="~/Images/WebSite/Retirer.png" CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button runat="server" ID="btnRecalculer" OnClick="btnRecalculerClick" Text="Recalculer le panier" CssClass="boutonActionRond" />
    <br />

    <table>
        <tr>
            <td>
                <div class="adresseLivraisonClient">
                    <div class="titreDansPage">
                        <asp:Label runat="server" ID="lblAdresseLivraisonClient" Text="Adresse de livraison"></asp:Label>
                    </div>
                    <asp:Label runat="server" ID="lblAdresseLivraison"></asp:Label>
                </div>
                <div class="adresseFacturationClient">
                    <div class="titreDansPage">
                        <asp:Label runat="server" ID="lblAdresseFacturationClient" Text="Adresse de facturation"></asp:Label>
                    </div>
                    <asp:Label runat="server" ID="lblAdresseFacturation"></asp:Label>
                </div>
                <asp:Button runat="server" ID="btnModifierAdresse" Text="Modifier mes adresses" OnClick="btnModifierAdresseClick" />
            </td>
            <td>
                <div class="Table">
                    <div class="Row">
                        <div class="Cell">
                            <p>Sous-Total</p>
                        </div>
                        <div class="Cell">
                            <p><asp:Label runat="server" ID="lblSousTotal"></asp:Label></p>
                        </div>
                    </div>
                    <div class="Row">
                        <div class="Cell">
                            <p>TVQ</p>
                        </div>
                        <div class="Cell">
                            <p><asp:Label runat="server" ID="lblTaxeProvinciale"></asp:Label></p>
                        </div>
                    </div>
                    <div class="Row">
                        <div class="Cell">
                            <p>TPS</p>
                        </div>
                        <div class="Cell">
                            <p><asp:Label runat="server" ID="lblTaxeFederale"></asp:Label></p>
                        </div>
                    </div>

                    <div class="Row">
                        <div class="Cell">
                            <p>Grand-Total</p>
                        </div>
                        <div class="Cell">
                            <p><asp:Label runat="server" ID="lblGrandTotal"></asp:Label></p>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>





    <asp:Button runat="server" ID="btnFinaliserCommande" OnClick="btnFinaliserCommandeClick" Text="Finaliser la commande" CssClass="boutonActionRond" />
</asp:Content>
