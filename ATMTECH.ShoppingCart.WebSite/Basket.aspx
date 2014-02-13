<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Basket.aspx.cs" Inherits="ATMTECH.ShoppingCart.WebSite.Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="titleBasket" Text="Votre panier" CssClass="title"></asp:Label>
    <asp:Panel runat="server" ID="pnlBasketNotEmpty" Visible="True">
        <asp:Label runat="server" ID="lblOrderNumber" Text="Numéro de commande:"></asp:Label>
        <asp:Label runat="server" ID="lblOrderId"></asp:Label>
        <asp:GridView runat="server" ID="grvBasket" AutoGenerateColumns="false" CssClass="basketGrid"
            ShowHeader="False" OnRowCommand="GrvBasketCommand">
            <HeaderStyle CssClass="basketGridHeader" />
            <FooterStyle CssClass="basketGridFooter" />
            <Columns>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblIdent" Text='<%#Eval("Stock.Product.Ident")%>'></asp:Label>
                        <asp:Label runat="server" ID="lblProductName" Text='<%#Eval("Stock.Product.Name")%>'></asp:Label>
                        <asp:Label runat="server" ID="lblStockFeature" Text='<%# "(" +Eval("Stock.Feature") + ")" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prix unitaire">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblUnitPrice" Text='<%# Eval("Stock.Product.UnitPrice", "{0:c}")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtQuantity" Text='<%#Eval("Quantity")%>'
                            EstNumeriqueSeul="true"></atmtech:AlphaNumTextBoxAvance>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkDelete" CommandName="DeleteOrderLine" Text="Supprimer"
                            CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <atmtech:Bouton runat="server" ID="btnCalculate" Text="Recalculer" OnClick="RecalculerClick" />
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
                    <asp:Label runat="server" ID="lblShippingNotIncluded" Visible="False" Text="Envoi non inclus."></asp:Label>
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
                    <asp:Label runat="server" ID="lblGrandTotalLabel" Text="Grand total:" CssClass="grandTotalLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblGrandTotal" CssClass="grandTotalLabel" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblShippingLabel" Text="Adresse d'envoi" />
                </td>
                <td>
                    <atmtech:ComboBoxAvance runat="server" ID="ddlShipping" />
                    <asp:Panel runat="server" ID="pnlModifyShippingAddress" Visible="False">
                        <asp:Label runat="server" ID="lblTitleModifyShippingTitle" Text="Modifié votre adresse d'envoi"></asp:Label>
                        <table>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyShippingWay" Libelle="Rue" EstObligatoire="True"
                                    ValidationGroup="FinalizeOrder" />
                            </tr>
                            <tr>
                                <atmtech:ComboBoxAvance runat="server" ID="ddlModifyShippingCountry" Libelle="Pays"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" />
                            </tr>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyShippingCity" Libelle="Ville"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" />
                            </tr>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyShippingPostalCode" Libelle="Code postal"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" />
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>
                    <atmtech:Bouton runat="server" ID="btnModifyShippingAddress" OnClick="ShowModifyShippingAddress"
                        Text="Modifié l'adresse d'envoi" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblBillingLabel" Text="Adresse de facturation" />
                </td>
                <td>
                    <atmtech:ComboBoxAvance runat="server" ID="ddlBilling" />
                    <asp:Panel runat="server" ID="pnlModifyBillingAddress" Visible="False">
                        <asp:Label runat="server" ID="lblTitleModifyBillingTitle" Text="Modifié votre adresse de facturation"></asp:Label>
                        <table>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyBillingWay" Libelle="Rue" EstObligatoire="True"
                                    ValidationGroup="FinalizeOrder" />
                            </tr>
                            <tr>
                                <atmtech:ComboBoxAvance runat="server" ID="ddlModifyBillingCountry" Libelle="Pays"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" />
                            </tr>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyBillingCity" Libelle="Ville" EstObligatoire="True"
                                    ValidationGroup="FinalizeOrder" />
                            </tr>
                            <tr>
                                <atmtech:TextBoxAvance runat="server" ID="txtModifyBillingPostalCode" Libelle="Code postal"
                                    EstObligatoire="True" ValidationGroup="FinalizeOrder" />
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>
                    <atmtech:Bouton runat="server" ID="btnModifyBillingAddress" OnClick="ShowModifyBillingAddress"
                        Text="Modifié l'adresse de facturation" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtProject" Libelle="Projet:" />
            </tr>
        </table>
        <atmtech:Bouton runat="server" ID="btnFinalizeOrder" Text="Finaliser la commande"
            OnClick="FinalizeOrderClick" ValidationGroup="FinalizeOrder" />
        <atmtech:Bouton runat="server" ID="btnFinalizeOrderPaypal" Text="Finaliser la commande avec Paypal"
            OnClick="FinalizeOrderPaypal" ValidationGroup="FinalizeOrder" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlBasketEmpty" Visible="False">
        <asp:Label runat="server" ID="lblBasketIsEmpty" Text="Votre panier est vide"></asp:Label>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlOrderFinalized" Visible="False">
        <asp:Label runat="server" ID="lblOrderIsFinalized" Text="Merci de votre commande"></asp:Label>
        <atmtech:Bouton runat="server" ID="btnPrintOrder" Text="Imprimer le détail de votre commande"
            OnClick="PrintOrderClick" />
    </asp:Panel>
</asp:Content>
