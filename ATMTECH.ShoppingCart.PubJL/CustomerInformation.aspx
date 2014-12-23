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
                <td>
                    <asp:Label runat="server" ID="lblName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" Enabled="False" Width="400px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblLogin" Text="Nom d'utilisateur:"></asp:Label>

                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLogin"
                        Width="400px" ValidationGroup="CreateCustomer" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblFirstName" Text="Prénom"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFirstName" ValidationGroup="CreateCustomer"
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <<td>
                    <asp:Label runat="server" ID="lblLastName" Text="Nom"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLastName" ValidationGroup="CreateCustomer"
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblEmail" Text="Courriel:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" ValidationGroup="CreateCustomer"
                        Width="400px"></asp:TextBox>
                </td>
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
                        <td>
                            <asp:Label runat="server" ID="lblDateStartSalesByOrderInformationReport" Text="Date début:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDateStartSalesByOrderInformationReport" />
                        </td>


                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblDateEndSalesByOrderInformationReport" Text="Date fin:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDateEndSalesByOrderInformationReport" Libelle="Date fin:" />
                        </td>


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
                        <td>
                            <asp:Label runat="server" ID="lblDateStartReport" Text="Date début:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDateStartReport" Libelle="Date début:" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblDateEndReport" Text="Date fin:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDateEndReport" />
                        </td>


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
                    <td>
                        <asp:Label runat="server" ID="lblPassword" Text="Mot de passe:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" ValidationGroup="CreateCustomer"
                            Width="400px" TextMode="Password"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblConfirmPassword" Text="Confirmation:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtConfirmPassword"
                            Width="400px" ValidationGroup="CreateCustomer" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>



        <div class="title">
            <strong>
                <asp:Label runat="server" ID="lblModificationAdresse" Text="Mdoification d'adresses"></asp:Label></strong>
        </div>
        <asp:Panel runat="server" Visible="True" ID="pnlChangeAddressBilling">
            <strong>
                <asp:Label runat="server" ID="lblBillingLabel" Text="Adresse de facturation" /></strong>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblModifyBillingWay" Text="Rue:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtModifyBillingWay" ValidationGroup="ModifyBilling" Width="350px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblModifyBillingCountry" Text="Pays"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlModifyBillingCountry" ValidationGroup="ModifyBilling" Width="350px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblModifyBillingCity" Text="Ville"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtModifyBillingCity" ValidationGroup="ModifyBilling" Width="350px" />
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblModifyBillingPostalCode" Text="Code postal"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtModifyBillingPostalCode" ValidationGroup="ModifyBilling" Width="350px" />
                    </td>
                </tr>
            </table>
            <div>
                <asp:Button runat="server" ID="btnSaveAddressBilling" OnClick="SaveAddressBillingClick" Text="Enregistrer" ValidationGroup="ModifyBilling" />
                <asp:Button runat="server" ID="btnCopyAddressBillingToShipping" OnClick="CopyAddressBillingToShippingClick" Text="Enregistrer" ValidationGroup="ModifyBilling" />
            </div>
        </asp:Panel>
        <asp:Panel runat="server" Visible="True" ID="pnlChangeAddressShipping">
            <strong>
                <asp:Label runat="server" ID="lblShippingLabel" Text="Adresse d'envoi" /></strong>

            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblModifyShippingWay" Text="Rue"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtModifyShippingWay" ValidationGroup="ModifyShipping" Width="350px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblModifyShippingCountry" Text="Pays"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlModifyShippingCountry" ValidationGroup="ModifyShipping" Width="350px" />
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblModifyShippingCity" Text="Ville"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtModifyShippingCity" ValidationGroup="ModifyShipping" Width="350px" />
                    </td>


                </tr>
                <tr>

                    <td>
                        <asp:Label runat="server" ID="lblModifyShippingPostalCode" Text="Code postal"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtModifyShippingPostalCode" ValidationGroup="ModifyShipping" Width="350px" />
                    </td>


                </tr>
            </table>
            <div>
                <asp:Button runat="server" ID="btnSaveAddressShipping" OnClick="SaveAddressShippingClick" Text="Enregistrer" ValidationGroup="ModifyShipping" />
            </div>

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
            <asp:GridView runat="server" ID="grvShipped" AutoGenerateColumns="false"
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
