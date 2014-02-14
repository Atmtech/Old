<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CreatePlayer.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.CreatePlayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        <asp:Label runat="server" ID="titleCreateCustomer" Text="Création d'un pêcheur"></asp:Label>
    </div>
    <asp:Panel runat="server" ID="pnlCreate">
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtFirstName" Libelle="Prénom: " ValidationGroup="CreatePlayer"
                    StyleTextBox="width:400px" EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtLastName" Libelle="Nom: " ValidationGroup="CreatePlayer"
                    StyleTextBox="width:400px" EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtEmail" Libelle="Courriel: " ValidationGroup="CreatePlayer"
                    StyleTextBox="width:400px" EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtLogin" Libelle="Nom d'utilisateur: "
                    StyleTextBox="width:400px" ValidationGroup="CreatePlayer" EstObligatoire="True">
                </atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtPassword" Libelle="Mot de passe: " ValidationGroup="CreatePlayer"
                    StyleTextBox="width:400px" TextMode="Password" EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtConfirmPassword" Libelle="Confirmation:"
                    StyleTextBox="width:400px" ValidationGroup="CreatePlayer" TextMode="Password"
                    EstObligatoire="True"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="imgCaptcha" ImageUrl="Captcha.ashx" runat="server" />
                </td>
                <td>
                    <asp:button runat="server" ID="btnReloadCaptcha" OnClick="ReloadCaptcha_click" CssClass="button"
                        Text="Recharger l'image" />
                </td>
            </tr>
            <tr>
                <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtCaptcha" Libelle="Saisir les chiffres que vous voyez dans l'image: "
                    ValidationGroup="CreatePlayer" StyleTextBox="width:400px" EstObligatoire="True"
                    EstNumeriqueSeul="True"></atmtech:AlphaNumTextBoxAvance>
            </tr>
        </table>
        <div class="toolbar">
            <asp:button runat="server" ID="btnCreate" OnClick="CreatePlayerClick" Text="Créer" CssClass="button"
                ValidationGroup="CreatePlayer" />
            <asp:button runat="server" ID="btnInit" OnClick="InitPlayerClick" Text="Effacer les champs" CssClass="button"
                ValidationGroup="CreatePlayer" CausesValidation="False" />
            <asp:button runat="server" ID="btnCancel" OnClick="CancelCreatePlayerClick" Text="Annuler" CssClass="button" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlCreated" Visible="False">
        <asp:Label runat="server" ID="lblCreateCustomerSuccess" Text="Veuillez suivre les informations contenu dans le courriel pour valider la création de votre utilisateur."></asp:Label>
    </asp:Panel>
</asp:Content>
