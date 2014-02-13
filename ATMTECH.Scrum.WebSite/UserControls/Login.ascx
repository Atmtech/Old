<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="ATMTECH.Scrum.WebSite.UserControls.Login" %>
<asp:Panel runat="server" ID="pnlLogin" Visible="True">
    <table>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtUser" Libelle="Utilisateur" />
        </tr>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtPassword" Libelle="Mot de passe" TextMode="Password" />
        </tr>
    </table>
    <atmtech:Bouton runat="server" ID="btnSignIn" Text="Entrer" OnClick="SignInClick" />
</asp:Panel>
<asp:Panel runat="server" ID="pnlWelcome" Visible="False">
    Bienvenue
</asp:Panel>
