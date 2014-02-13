<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CustomerInformation.aspx.cs" Inherits="ATMTECH.ShoppingCart.WebSite.CustomerInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="titleCustomerInformation" Text="Information du client"
        CssClass="title"></asp:Label>
    <table>
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
    <asp:Label runat="server" ID="lblCustomerInformationOrderedList" Text="Historique des commandes passées:"></asp:Label>
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
            <asp:TemplateField HeaderText="Envoi postal">
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
                    <asp:LinkButton runat="server" ID="lnkLookupOrder" Text="Voir la commande" CommandArgument='<%#Eval("Id")%>'
                        CommandName="lookup" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label runat="server" ID="lblCustomerInformationShippedList" Text="Historique des commandes envoyées:"></asp:Label>
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
            <asp:TemplateField HeaderText="Envoi postal">
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
                    <asp:LinkButton runat="server" ID="lnkLookupOrder" Text="Voir la commande" CommandArgument='<%#Eval("Id")%>'
                        CommandName="lookup" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
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
    <atmtech:Bouton runat="server" ID="btnSave" OnClick="SaveCustomer_click" Text="Enregistrer" />
    <atmtech:Bouton runat="server" ID="btnChangePassword" OnClick="ChangePassword_click"
        Text="Changer mon mot de passe" />
</asp:Content>
