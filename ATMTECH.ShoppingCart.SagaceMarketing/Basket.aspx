<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Basket.aspx.cs" Inherits="ATMTECH.ShoppingCart.SagaceMarketing.Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="displayProduct">
        <asp:Label runat="server" ID="titleBasket" Text="Votre panier" CssClass="title" Visible="False"></asp:Label>
        <asp:Panel runat="server" ID="pnlBasketNotEmpty" Visible="True">
            <asp:Label runat="server" ID="lblOrderNumber" Text="Numéro de commande:" Visible="False"></asp:Label>
            <asp:Label runat="server" ID="lblOrderId" Visible="False"></asp:Label>
            <asp:GridView runat="server" ID="grvBasket" AutoGenerateColumns="false" CssClass="basketGrid"
                ShowHeader="True" ShowFooter="False" OnRowCommand="GrvBasketCommand">
                <HeaderStyle CssClass="basketGridHeader" />
                <Columns>
                    <asp:TemplateField HeaderText="Article(s)">
                        <ItemTemplate>
                            <div style="float: left;">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ThumbNail.aspx?width=109&height=104&directory=images/product/&filename=" +Eval("Stock.Product.PrincipalFileUrl")  %>'>
                                </asp:Image>
                            </div>
                            <div style="float: left;">
                                <asp:Label runat="server" ID="lblIdent" Text='<%#Eval("Stock.Product.Ident")%>'></asp:Label>
                                <br />
                                <asp:Label runat="server" ID="lblProductName" Text='<%#Eval("Stock.Product.Name")%>'
                                    CssClass="basketProductName"></asp:Label>
                                <br />
                                <asp:Label runat="server" ID="lblStockFeature" Text='<%# Eval("Stock.Feature")  %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantité">
                        <ItemTemplate>
                            <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtQuantity" Text='<%#Eval("Quantity")%>'
                                Width="50px" EstNumeriqueSeul="true"></atmtech:AlphaNumTextBoxAvance>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Prix">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblUnitPrice" Text='<%# Eval("Stock.Product.UnitPrice", "{0:c}")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Retirer">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lnkDelete" CommandName="DeleteOrderLine"
                                ImageUrl="Images/WebSite/Retirer.png" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div style="padding-top: 10px; padding-bottom: 10px; text-align: right;">
                <asp:Button runat="server" ID="btnRecalculateBasket" Text="Recalculer" OnClick="RecalculerClick"
                    CssClass="button" />
            </div>
            <div style="float: left; width: 50%;">
                <table>
                    <tr>
                        <atmtech:TextBoxAvance runat="server" ID="txtProject" Libelle="Projet:" Width="300px"
                            TextMode="MultiLine" Height="100px" />
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 49%;">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblSubTotalLabel" Text="Sous-total:"></asp:Label>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label runat="server" ID="lblSubTotal" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblShippingTotalLabel" Text="Livraison:"></asp:Label>
                            <asp:Label runat="server" ID="lblShippingWeight" Text=""></asp:Label>
                            <asp:Label runat="server" ID="lblShippingNotIncluded" Visible="False" Text="Envoi non inclus."></asp:Label>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label runat="server" ID="lblShippingTotal" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblSubTotalTaxesRegionLabel" Text="TVQ:"></asp:Label>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label runat="server" ID="lblSubTotalTaxesRegion" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblSubTotalTaxesCountryLabel" Text="TPS:"></asp:Label>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label runat="server" ID="lblSubTotalTaxesCountry" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblGrandTotalLabel" Text="Grand total:" CssClass="grandTotalLabel"></asp:Label>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label runat="server" ID="lblGrandTotal" CssClass="grandTotalLabel" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="clear: both;">
            </div>
            
            <div class="adressInformation">
              <asp:Label runat="server" ID="lblAdressInformationBasket"></asp:Label>
            </div>

            <div style="margin-top: 10px;">
                <div class="shippingAdressBasket">
                    <asp:Label runat="server" ID="lblShippingLabel" Text="Adresse d'envoi" />
                    <br />
                    <atmtech:ComboBoxAvance runat="server" ID="ddlShipping" />
                    <asp:Button runat="server" ID="btnModifyShippingAddress" OnClick="ShowModifyShippingAddress"
                        Text="Modifier" CssClass="button" />
                    <asp:Panel runat="server" ID="pnlModifyShippingAddress" Visible="False">
                        <table style="width: 100%;">
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyShippingWay" Libelle="Rue" EstObligatoire="True"
                                    ValidationGroup="FinalizeOrder" Width="350px" />
                            </tr>
                            <tr>
                                <atmtech:ComboBoxAvance runat="server" ID="ddlModifyShippingCountry" Libelle="Pays"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" Width="350px" />
                            </tr>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyShippingCity" Libelle="Ville"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" Width="350px" />
                            </tr>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyShippingPostalCode" Libelle="Code postal"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" Width="350px" />
                            </tr>
                        </table>
                        <asp:Button runat="server" ID="btnCancelModifiedShippingAddress" Text="Annuler la modification" OnClick="CancelModifiedShippingAddressClick"
                            CausesValidation="False" CssClass="button" />
                    </asp:Panel>
                </div>
                <div class="billingAdressBasket">
                    <asp:Label runat="server" ID="lblBillingLabel" Text="Adresse de facturation" />
                    <br />
                    <atmtech:ComboBoxAvance runat="server" ID="ddlBilling" />
                    <asp:Button runat="server" ID="btnModifyBillingAddress" OnClick="ShowModifyBillingAddress"
                        Text="Modifier" CssClass="button" />
                    <asp:Panel runat="server" ID="pnlModifyBillingAddress" Visible="False">
                        <table>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyBillingWay" Libelle="Rue" EstObligatoire="True"
                                    ValidationGroup="FinalizeOrder" Width="350px" />
                            </tr>
                            <tr>
                                <atmtech:ComboBoxAvance runat="server" ID="ddlModifyBillingCountry" Libelle="Pays"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" Width="350px" />
                            </tr>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyBillingCity" Libelle="Ville" EstObligatoire="True"
                                    ValidationGroup="FinalizeOrder" Width="350px" />
                            </tr>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyBillingPostalCode" Libelle="Code postal"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" Width="350px" />
                            </tr>
                        </table>
                        <asp:Button runat="server" ID="btnCancelModifiedBillingAddress" Text="Annuler la modification"
                            CausesValidation="False" CssClass="button" OnClick="CancelModifiedBillingAddressClick" />
                    </asp:Panel>
                </div>
            </div>
            <div style="clear: both;">
            </div>
            <div class="menuWithButtonRight">
                <table width="100%">
                    <tr>
                        <td style="text-align: left;">
                            <a href="#" title="How PayPal Works" onclick="javascript:window.open('https://www.paypal.com/webapps/mpp/paypal-popup','WIPaypal','toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, width=1060, height=700');">
                                <img src="https://www.paypalobjects.com/webstatic/mktg/logo/AM_mc_vs_dc_ae.jpg" border="0" width="50%" height="50%"
                                    alt="PayPal Acceptance Mark"></a>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnContinueShopping" Text="Continuer le magasinage"
                                OnClick="ContinueShoppingClick" CausesValidation="False" CssClass="button" />
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnFinalizeOrder" Text="Finaliser la commande" OnClick="FinalizeOrderClick"
                                ValidationGroup="FinalizeOrder" CssClass="button" />
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnFinalizeOrderPaypal" Text="Finaliser la commande avec Paypal"
                                OnClick="FinalizeOrderPaypal" ValidationGroup="FinalizeOrder" CssClass="button" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlBasketEmpty" Visible="False">
            <asp:Label runat="server" ID="lblBasketIsEmpty" Text="Votre panier est vide"></asp:Label>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlOrderFinalized" Visible="False">
            <asp:Label runat="server" ID="lblOrderIsFinalized" Text="Merci de votre commande"></asp:Label><br />
            <div class="menuWithButtonRight">
                <asp:Button runat="server" ID="btnPrintOrder" Text="Imprimer le détail de votre commande"
                    OnClick="PrintOrderClick" CssClass="button" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
