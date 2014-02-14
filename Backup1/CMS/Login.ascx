<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="ATMTECH.BillardLoretteville.Website.CMS.Login" %>
<asp:Panel runat="server" ID="pnlToLog">
    <table>
        <tr>
            <atmtech:TextBoxAvance ID="txtUsername" runat="server" EstObligatoire="true" Libelle="Utilisateur:"
                ValidationGroup="validLogin" />
        </tr>
        <tr>
            <atmtech:TextBoxAvance ID="txtPassword" runat="server" EstObligatoire="true" Libelle="Mot de passe:"
                TextMode="Password" ValidationGroup="validLogin" />
        </tr>
    </table>
    
    <atmtech:Bouton runat="server" ID="btnLog" Text="Connexion" OnClick="OnbtnLog" ValidationGroup="validLogin" />
</asp:Panel>
<asp:Panel runat="server" ID="pnlLogged" Visible="false">
    <atmtech:TitreLabelAvance runat="server" ID="lblWelcomeShow" Text="Bienvenue"></atmtech:TitreLabelAvance>
    <atmtech:TitreLabelAvance runat="server" ID="lblWelcome"></atmtech:TitreLabelAvance>
    <atmtech:Bouton runat="server" ID="btnUnLog" Text="Déconnecter" OnClick="OnbtnUnLog" />
</asp:Panel>
<atmtech:FenetreDialogue ID="windowError" runat="server">
    <atmtech:TitreLabelAvance runat="server" ID="lblError" />
</atmtech:FenetreDialogue>
