<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CustomerInformation.aspx.cs" Inherits="ATMTECH.ShoppingCart.SagaceMarketing.CustomerInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="displayProduct">
        <div class="historicCustomerLabel">
            <asp:Label runat="server" ID="lblCustomerInformation" Text="Information du client"></asp:Label>
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
                <atmtech:TextBoxAvance runat="server" ID="txtFirstName" Libelle="Prénom: " StyleTextBox="width:400px">
                </atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtLastName" Libelle="Nom: " StyleTextBox="width:400px">
                </atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtEmail" Libelle="Courriel: " StyleTextBox="width:400px">
                </atmtech:TextBoxAvance>
            </tr>
        </table>
        
        <asp:Panel runat="server" ID="pnlChangePassword" Visible="False">
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
        <asp:Label runat="server" ID="lblCustomerInformationSaved" Text="Enregistrement confirmé"
            Visible="False"></asp:Label>

        <div class="menuWithButtonRight">
            <asp:Button runat="server" ID="btnSave" OnClick="SaveCustomer_click" Text="Enregistrer"
                CssClass="button" />
            <asp:Button runat="server" ID="btnChangePassword" OnClick="ChangePassword_click"
                CssClass="button" Text="Changer mon mot de passe" />
        </div>
        <div style="padding-top: 15px;">
            <div class="historicCustomerLabel">
                <asp:Label runat="server" ID="lblCustomerInformationOrderedList" Text="Historique des commandes passées:"></asp:Label>
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
                            <asp:Button runat="server" ID="lnkLookupOrder" Text="Voir la commande" CommandArgument='<%#Eval("Id")%>'
                                CommandName="lookup" CssClass="button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div style="padding-top: 15px;">
            <div class="historicCustomerLabel">
                <asp:Label runat="server" ID="lblCustomerInformationShippedList" Text="Historique des commandes envoyées:"></asp:Label>
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
                            <asp:Button runat="server" ID="lnkLookupOrder" Text="Voir la commande" CommandArgument='<%#Eval("Id")%>'
                                CommandName="lookup" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        
    </div>
</asp:Content>
