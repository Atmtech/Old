<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CustomerInformation.aspx.cs" Inherits="ATMTECH.ShoppingCart.PubJL.CustomerInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 950px; padding: 10px 10px 10px 10px; color: black; border: solid 1px gray; background-color: white; margin-bottom: 10px;">
        <div class="title">
            <strong>
                <asp:Label runat="server" ID="lblCustomerInformation" Text="Information du client"></asp:Label></strong>
        </div>

        <table width="100%">
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtName" Libelle="Nom complet: " Enabled="False"
                    StyleTextBox="width:400px"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtLogin" Libelle="Nom d'utilisateur: "
                    StyleTextBox="width:400px;font-weight:bold;" Enabled="false"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtFirstName" Libelle="Prénom: " StyleTextBox="width:400px"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtLastName" Libelle="Nom: " StyleTextBox="width:400px"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtEmail" Libelle="Courriel: " StyleTextBox="width:400px"></atmtech:TextBoxAvance>
            </tr>
        </table>
        <div>
            <asp:Button runat="server" ID="btnSave" OnClick="SaveCustomer_click" Text="Enregistrer" />
            <asp:Button runat="server" ID="btnChangePassword" OnClick="ChangePassword_click"
                Text="Changer mon mot de passe" />
        </div>

        <asp:Panel runat="server" ID="pnlSuperUser" Visible="False">
            <div class="title">
                <strong>
                    <asp:Label runat="server" ID="lblSuperUserTitle" Text="Vos accès spéciaux"></asp:Label></strong>
            </div>
            <asp:Button runat="server" ID="btnSalesByMonthReport" OnClick="btnSalesByMonthReportClick" Text="Rapport des ventes par mois" CausesValidation="False" />
            <asp:Button runat="server" ID="btnSalesByOrderInformationReport" OnClick="btnSalesByOrderInformationReportClick" Text="Rapport des ventes par imputation" CausesValidation="False" />

            <asp:Panel runat="server" ID="pnlSalesByOrderInformationReport" Visible="False">
                <table>
                    <tr>
                        <atmtech:DateTextBoxAvance runat="server" ID="txtDateStartSalesByOrderInformationReport" Libelle="Date début:"
                            EstObligatoire="True" />
                    </tr>
                    <tr>
                        <atmtech:DateTextBoxAvance runat="server" ID="txtDateEndSalesByOrderInformationReport" Libelle="Date fin:" EstObligatoire="True" />
                    </tr>
                </table>
                <div style="background-color: lightgray; border: solid 1px gray; padding-top: 10px; padding-left: 5px; margin-bottom: 5px;">
                    <asp:Button runat="server" ID="btnGenerateSalesByOrderInformationReport" OnClick="brGeneratebtnSalesByOrderInformationReportClick" Text="Générer le rapport"
                        CausesValidation="True" CssClass="button" />
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlSalesByMonthReport" Visible="False">
                <table>
                    <tr>
                        <atmtech:DateTextBoxAvance runat="server" ID="txtDateStartReport" Libelle="Date début:"
                            EstObligatoire="True" />
                    </tr>
                    <tr>
                        <atmtech:DateTextBoxAvance runat="server" ID="txtDateEndReport" Libelle="Date fin:" EstObligatoire="True" />
                    </tr>
                </table>
                <div style="background-color: lightgray; border: solid 1px gray; padding-top: 10px; padding-left: 5px; margin-bottom: 5px;">
                    <asp:Button runat="server" ID="btnGenerateSalesByMonthReport" OnClick="btnGenerateSalesByMonthReportClick" Text="Générer le rapport"
                        CausesValidation="True" CssClass="button" />
                </div>
            </asp:Panel>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlChangePassword" Visible="False">
            <div class="title">
                <strong>
                    <asp:Label runat="server" ID="lblChangementDeMotDePasse" Text="Changement de mot de passe"></asp:Label></strong>
            </div>
            <table>
                <tr>
                    <atmtech:TextBoxAvance runat="server" ID="txtPassword" Libelle="Mot de passe: " StyleTextBox="width:400px"
                        TextMode="Password"></atmtech:TextBoxAvance>
                </tr>
                <tr>
                    <atmtech:TextBoxAvance runat="server" ID="txtConfirmPassword" Libelle="Confirmation: "
                        StyleTextBox="width:400px" TextMode="Password"></atmtech:TextBoxAvance>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlModifyAddress" Visible="True">
            <div class="title">
                <strong>
                    <asp:Label runat="server" ID="lblModificationAdresse" Text="Mdoification d'adresses"></asp:Label></strong>
            </div>
            <asp:Panel runat="server" Visible="True" ID="pnlChangeAddressBilling">
                <strong>
                    <asp:Label runat="server" ID="lblBillingLabel" Text="Adresse de facturation" /></strong>
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
                <div>
                    <asp:Button runat="server" ID="btnSaveAddressBilling" OnClick="SaveAddressBillingClick" Text="Enregistrer" />
                    <asp:Button runat="server" ID="btnCopyAddressBillingToShipping" OnClick="CopyAddressBillingToShippingClick" Text="Enregistrer" />
                </div>
            </asp:Panel>
            <asp:Panel runat="server" Visible="True" ID="pnlChangeAddressShipping">
                <strong>
                    <asp:Label runat="server" ID="lblShippingLabel" Text="Adresse d'envoi" /></strong>

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
                <div>
                    <asp:Button runat="server" ID="btnSaveAddressShipping" OnClick="SaveAddressShippingClick" Text="Enregistrer" />
                </div>

            </asp:Panel>
        </asp:Panel>



        <asp:Label runat="server" ID="lblCustomerInformationSaved" Text="Enregistrement confirmé"
            Visible="False"></asp:Label>


        <div style="padding-top: 15px;">
            <div class="title">
                <strong>
                    <asp:Label runat="server" ID="lblCustomerInformationOrderedList" Text="Historique des commandes passées:"></asp:Label></strong>
            </div>
            <asp:GridView runat="server" ID="grvOrdered" AutoGenerateColumns="false" CssClass="orderGrid"
                OnRowCommand="OnRowCommandOrdered" EmptyDataText="Aucune commande passée" ShowHeader="True">
                <HeaderStyle CssClass="orderGridHeader" HorizontalAlign="Left" />
                <FooterStyle CssClass="orderGridFooter" />
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblId" Text='<%#Eval("Id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date de commande">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblOrderedDate" Text='<%#Eval("DateModified")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sous-total">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSubTotal" Text='<%#Eval("SubTotal","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TVQ">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblRegionTax" Text='<%#Eval("RegionalTax","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TPS">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCountryTax" Text='<%#Eval("CountryTax","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Livraison">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblShippingTotal" Text='<%#Eval("ShippingTotal","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grand total">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblGrandTotal" Text='<%#Eval("GrandTotal","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="lnkLookupOrder" Text="+" CommandArgument='<%#Eval("Id")%>' CommandName="lookup" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div style="padding-top: 15px;">
            <div class="title">
                <strong>
                    <asp:Label runat="server" ID="lblCustomerInformationShippedList" Text="Historique des commandes envoyées:"></asp:Label>
                </strong>
            </div>
            <asp:GridView runat="server" ID="grvShipped" AutoGenerateColumns="false" CssClass="orderGrid"
                EmptyDataText="Aucune commande en envoi" ShowHeader="True" OnRowCommand="OnRowCommandOrdered">
                <HeaderStyle CssClass="orderGridHeader" />
                <FooterStyle CssClass="orderGridFooter" />
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblId" Text='<%#Eval("Id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date de commande">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblOrderedDate" Text='<%#Eval("DateModified")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date d'envoi">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblShippedDate" Text='<%#Eval("ShippingDate")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sous-total">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSubTotal" Text='<%#Eval("SubTotal","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TVQ">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblRegionTax" Text='<%#Eval("RegionalTax","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TPS">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCountryTax" Text='<%#Eval("CountryTax","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Livraison">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblShippingTotal" Text='<%#Eval("ShippingTotal","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grand total">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblGrandTotal" Text='<%#Eval("GrandTotal","{0:c}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Numéro de suivi">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="lblTrackingNumber" Text='<%#Eval("TrackingNumber")%>' CssClass="buttonTrackingNumber" CommandArgument='<%#Eval("Id")%>' CommandName="Tracking"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="lnkLookupOrder" Text="+" CommandArgument='<%#Eval("Id")%>' CommandName="lookup" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
