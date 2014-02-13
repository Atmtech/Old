﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CreateCustomer.aspx.cs" Inherits="ATMTECH.ShoppingCart.WebSite.CreateCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="titleCreateCustomer" Text="Création d'un client" CssClass="title"></asp:Label>
    <asp:Panel runat="server" ID="pnlCreate">
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtFirstName" Libelle="Prénom: " ValidationGroup="CreateCustomer"
                    StyleTextBox="width:400px" EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtLastName" Libelle="Nom: " ValidationGroup="CreateCustomer"
                    StyleTextBox="width:400px" EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtEmail" Libelle="Courriel: " ValidationGroup="CreateCustomer"
                    StyleTextBox="width:400px" EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtLogin" Libelle="Nom d'utilisateur: "
                    StyleTextBox="width:400px" ValidationGroup="CreateCustomer" EstObligatoire="True">
                </atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtPassword" Libelle="Mot de passe: " ValidationGroup="CreateCustomer"
                    StyleTextBox="width:400px" TextMode="Password" EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtConfirmPassword" Libelle="Confirmation:"
                    StyleTextBox="width:400px" ValidationGroup="CreateCustomer" TextMode="Password"
                    EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="imgCaptcha" ImageUrl="Captcha.ashx" runat="server" />
                </td>
                <td>
                    <atmtech:Bouton runat="server" ID="btnReloadCaptcha" OnClick="ReloadCaptcha_click" Text="Recharger l'image"/>
                </td>
            </tr>
            <tr>
              <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtCaptcha" Libelle="Saisir les chiffres que vous voyez dans l'image: " ValidationGroup="CreateCustomer"
                    StyleTextBox="width:400px" EstObligatoire="True" EstNumeriqueSeul="True"></atmtech:AlphaNumTextBoxAvance>
            </tr>
        </table>
        <atmtech:Bouton runat="server" ID="btnCreate" OnClick="CreateCustomer_click" Text="Créer"
            ValidationGroup="CreateCustomer" />
        <atmtech:Bouton runat="server" ID="btnCancel" OnClick="CancelCreateCustomer_click"
            Text="Annuler" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlCreated" Visible="False">
        <asp:Label runat="server" ID="lblCreateCustomerSuccess" Text="Veuillez suivre les informations contenu dans le courriel pour valider la création de votre utilisateur."></asp:Label>
    </asp:Panel>
</asp:Content>
