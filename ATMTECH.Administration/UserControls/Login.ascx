<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="ATMTECH.Administration.UserControls.Login" %>
<div class="login">
    <asp:Label runat="server" ID="titleLogin" Text="Identification" CssClass="title"
        Visible="False"></asp:Label>
    <asp:Panel runat="server" ID="pnlLogin" Visible="True" DefaultButton="btnSignIn">
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtUser" Libelle="Utilisateur" />
                <atmtech:TextBoxAvance runat="server" ID="txtPassword" Libelle="Mot de passe" TextMode="Password" />
                <td>
                    <asp:Button runat="server" ID="btnSignIn" Text="Entrer" OnClick="SignInClick" CssClass="button" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlWelcome" Visible="False">
        Bienvenue,
        <asp:Label runat="server" ID="lblName"></asp:Label>
        <asp:Button runat="server" ID="lnkSignOut" OnClick="SignOutClick" Text="Fermer la session" CssClass="button"></asp:Button>
    </asp:Panel>
</div>
