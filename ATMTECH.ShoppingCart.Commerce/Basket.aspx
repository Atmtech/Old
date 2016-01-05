<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Basket.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Panier">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblVotrePanier" Text="Panier"></asp:Label>
        </div>

        <div style="float: left;">
            <div style="width: 100%; text-align: center; border: solid 5px gray; background-color: white; margin-bottom: 10px; color: black; padding-top: 5px; padding-bottom: 5px;">
                <asp:Label runat="server" ID="lblAvertissementShippingPlusAvantageuxEnGroupe" Text="Quand vous commandez plusieurs articles les coûts d'envois sont plus avantageux"></asp:Label>
            </div>
            <asp:DataList runat="server" ID="dataListeCommande" OnItemCommand="dataListeCommande_ItemCommand">
                <ItemTemplate>
                    <div style="border-bottom: solid 2px lightGray; margin-bottom: 10px; width: 750px;">
                        <div style="float: left; text-align: center">
                            <asp:Image ID="imageProduit" runat="server" ImageUrl='<%# "images/product/" +Eval("Stock.Product.PrincipalFileUrlWithoutDirectory")  %>' CssClass="imageThumbNailPanier"></asp:Image>
                            <br />
            
                        </div>
                        <div style="float: left; padding-left: 10px; padding-top: 10px; width: 300px;">
                            <div style="font-weight: bold;">
                                <asp:Label runat="server" ID="lblIdent" Text='<%#Eval("Stock.Product.Ident")%>'></asp:Label>
                                <asp:Label runat="server" ID="lblNom" Text='<%# Session["currentLanguage"].ToString().Equals("fr") ?  Eval("Stock.Product.NameFrench") : Eval("Stock.Product.NameEnglish")%>'></asp:Label>
                                <br />
                                <asp:Label runat="server" ID="lblCaracteristique" Text='<%# Session["currentLanguage"].ToString().Equals("fr") ?  Eval("Stock.FeatureFrench") : Eval("Stock.FeatureEnglish")  %>'></asp:Label>
                                <br />
                            </div>
                        </div>
                    </div>
                    <div style="float: left; padding-left: 30px; width: 200px; padding-bottom: 20px">
                        <div style="font-weight: bold; border-bottom: solid 1px gray; padding-bottom: 20px;">
                            <asp:Label runat="server" ID="lblPrixUnitaire" Text='<%# Eval("UnitPrice","{0:c}")  %>' CssClass="prixPaye"></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lblPrixOriginal" Text='<%# Eval("Stock.Product.UnitPrice","{0:c}")  %>' Visible='<%# Convert.ToDecimal(Eval("Stock.Product.UnitPrice")) > Convert.ToDecimal(Eval("UnitPrice")) %>' CssClass="prixRaye"></asp:Label>
                         <br />
                            <asp:Label runat="server" ID="lblVousEpargnez" Text="Vous épargnez: " Visible='<%# Convert.ToDecimal(Eval("Stock.Product.UnitPrice")) > Convert.ToDecimal(Eval("UnitPrice")) %>' CssClass="prixEpargner"></asp:Label>
                            <asp:Label runat="server" ID="lblPrixVente" Text='<%# Eval("SavePrice","{0:c}")  %>' Visible='<%# Convert.ToInt32(Eval("Stock.Product.UnitPrice")) > Convert.ToInt32(Eval("UnitPrice")) %>' CssClass="prixEpargner"></asp:Label>

                        </div>
                        <div style="font-weight: bold; border-bottom: solid 1px gray; padding-top: 10px; padding-bottom: 10px; text-align: center;">
                            <atmtech:Numeric runat="server" ID="txtQuantite" Text='<%#Eval("Quantity")%>' NoDecimal="True" Width="50px" CssClass="textBox"></atmtech:Numeric>
                            <asp:Button runat="server" ID="btnRecalculer" Text="Mise à jour quantité" CssClass="boutonLien" CommandName="RecalculerCommande" CommandArgument='<%# Eval("Id") %>' />
                        </div>

                        <div class="totalPanierLigneCommande">
                            Total:
                                <asp:Label runat="server" ID="lblSousTotal" Text='<%#Eval("SubTotal","{0:c}")%>'></asp:Label>
                        </div>
                        <div style="padding-top: 10px;">
                                        <asp:Button runat="server" ID="btnRetirerArticle" Text="Retirer ce produit du panier" CssClass="boutonActionRond" CommandName="SupprimerLigneCommande" CommandArgument='<%# Eval("Id") %>' />
                            
                            </div>
                    </div>
                    <div style="clear: both;"></div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            
        </div>
        <div style="float: left; padding-left: 20px; border-left: solid 1px gray; margin-left: 10px; width: 200px">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblVotreCommande" Text="La commande"></asp:Label>
            </div>

            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblSousTotalAffichage" Text="Sous-total: "></asp:Label></td>
                    <td>
                        <asp:Label runat="server" ID="lblSousTotal"></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblTaxeProvincialeAffichage" Text="TVQ: "></asp:Label></td>
                    <td>
                        <asp:Label runat="server" ID="lblTaxeProvinciale"></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblTaxeFederaleAffichage" Text="TPS: "></asp:Label></td>
                    <td>
                        <asp:Label runat="server" ID="lblTaxeFederale"></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblCoutLivraisonAffichage" Text="Livraison: "></asp:Label></td>
                    <td>
                        <asp:Label runat="server" ID="lblCoutLivraison"></asp:Label></td>
                </tr>

                <tr>
                    <td class="totalCommandePanier">
                        <asp:Label runat="server" ID="lblGrandTotalAffichage" Text="Total: "></asp:Label></td>
                    <td class="totalCommandePanier">
                        <asp:Label runat="server" ID="lblGrandTotal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="totalCommandePanier">
                        <asp:Label runat="server" ID="lblGrandTotalAffichageAvecCoupon" Text="Total avec coupon: " Visible="false"></asp:Label></td>
                    <td class="totalCommandePanier">
                        <asp:Label runat="server" ID="lblGrandTotalApresCoupon" Visible="False"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" class="affichageValeurCoupon">
                        <asp:Label runat="server" ID="lblCouponValeur" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="lblCouponAucunFraisLivraison" Text="(Coupon: Aucun frais livraison)" Visible="false"></asp:Label><br />
                    </td>

                </tr>
            </table>

            <div>
                <div class="adresseLivraisonClient">
                    <div class="titreDansPage">
                        <asp:Label runat="server" ID="lblCoupon" Text="Entrer votre coupon"></asp:Label>
                    </div>
                    <div style="padding-bottom: 10px;">
                        <asp:TextBox runat="server" ID="txtCoupon" CssClass="textBox"></asp:TextBox>
                    </div>
                    <asp:Button runat="server" ID="btnValiderCoupon" Text="Valider" OnClick="btnValiderCouponClick" CssClass="boutonActionRond" />
                    <asp:Button runat="server" ID="btnEffacerCoupon" Text="Effacer" OnClick="btnEffacerCouponClick" CssClass="boutonActionRond" />
                </div>
            </div>

            <div style="padding-bottom: 20px;">
                <div class="adresseLivraisonClient">
                    <div class="titreDansPage">
                        <asp:Label runat="server" ID="lblAdresseLivraisonClient" Text="Adresse de livraison"></asp:Label>
                    </div>
                    <asp:Label runat="server" ID="lblAdresseLivraison" CssClass="affichageAdressePanier"></asp:Label>
                    <asp:Label runat="server" ID="lblSansAdresseLivraison" Text="Vous devez configurez votre adresse de livraison pour finaliser la commande" Visible="False" ForeColor="red"></asp:Label>
                </div>
                <div class="adresseFacturationClient">
                    <div class="titreDansPage">
                        <asp:Label runat="server" ID="lblAdresseFacturationClient" Text="Adresse de facturation"></asp:Label>
                    </div>
                    <asp:Label runat="server" ID="lblAdresseFacturation" CssClass="affichageAdressePanier"></asp:Label>
                    <asp:Label runat="server" ID="lblSansAdresseFacturation" Text="Vous devez configurez votre adresse de facturation pour finaliser la commande" Visible="False"></asp:Label>
                </div>
                <br />
                <asp:Button runat="server" ID="btnModifierAdresse" Text="Modifier mes adresses" OnClick="btnModifierAdresseClick" CssClass="boutonActionRond" />
            </div>

            <asp:Button runat="server" ID="btnFinaliserCommande" OnClick="btnFinaliserCommandeClick" Text="Finaliser la commande" CssClass="boutonActionRondFinaliser" />
        </div>
        <div style="clear: both;"></div>


    </div>

</asp:Content>
