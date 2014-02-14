<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.UserControls.Login" %>
<div class="login">
    <div class="headerWizard">
        <asp:Label runat="server" ID="titleLogin" Text="Identification"></asp:Label>
    </div>
    <asp:Panel runat="server" ID="pnlLogin" Visible="True" DefaultButton="btnSignIn">
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtUser" Libelle="Utilisateur" />
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtPassword" Libelle="Mot de passe" TextMode="Password" />
            </tr>
        </table>
        <div class="toolbar">
            <asp:Button runat="server" ID="btnSignIn" Text="Entrer" OnClick="SignInClick" CssClass="button"/>
            <asp:Button  runat="server" ID="btnCreateCustomer" Text="Créer un compte" OnClick="CreateCustomerClick" CssClass="button"/>
            <asp:Button  runat="server" ID="btnForgetPassword" Text="J'ai oublié mon mot de passe" CssClass="button"
                OnClick="ForgetPasswordClick" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlWelcome" Visible="False">
        <asp:Label runat="server" ID="lblName"></asp:Label>
        <asp:HyperLink runat="server" ID="lnkPlayerInformation" NavigateUrl="~/PlayerInformation.aspx"
            CssClass="linkButton" Text="[ My personal informations ]"></asp:HyperLink>
        <asp:LinkButton runat="server" ID="lnkSignOut" OnClick="SignOutClick" Text="[ Sign out ]"
            CssClass="linkButton"></asp:LinkButton>
        <asp:HyperLink runat="server" ID="lnkAdministration" Text="[ Administration ]" NavigateUrl="~/Administration/Default.aspx"
            CssClass="linkButton" Visible="False"></asp:HyperLink>
    </asp:Panel>
</div>
