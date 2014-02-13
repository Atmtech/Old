<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits=" ATMTECH.ShoppingCart.SagaceMarketing.UserControls.Login" %>
<asp:Panel runat="server" ID="pnlError" CssClass="panelError" Visible="False">
    <asp:Literal runat="server" ID="lblError"></asp:Literal>
</asp:Panel>
<asp:Label runat="server" ID="lblTitleLogin" Text="Identification" CssClass="title" Visible="False"></asp:Label>
<asp:Panel runat="server" ID="pnlLogin" Visible="True" DefaultButton="btnSignIn">
    <table>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtUser" Libelle="Utilisateur" />
        </tr>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtPassword" Libelle="Mot de passe" TextMode="Password" />
        </tr>
    </table>
    <hr />
    <asp:Button runat="server" ID="btnSignIn" Text="Entrer" OnClick="SignInClick" CssClass="button" />
    <asp:Button runat="server" ID="btnCreateCustomer" Text="Créer un compte" OnClick="CreateCustomerClick"
        Visible="False" />
    <asp:Button runat="server" ID="btnForgetPassword" Text="J'ai oublié mon mot de passe"
        CssClass="button" OnClick="ForgetPasswordClick" />
</asp:Panel>
<asp:Panel runat="server" ID="pnlWelcome" Visible="False">
    Bienvenue,
    <asp:Label runat="server" ID="lblName"></asp:Label>
    <asp:HyperLink runat="server" ID="lnkCustomerInformation" NavigateUrl="~/CustomerInformation.aspx"
        CssClass="linkButton" Text="[ Modifier Mes informations personnelles ]" Visible="False"></asp:HyperLink>
    <asp:LinkButton runat="server" ID="lnkSignOut" OnClick="SignOutClick" Text="[ Fermer la session ]"
        Visible="False" CssClass="linkButton"></asp:LinkButton>
    <asp:HyperLink runat="server" ID="lnkAdministration" Text="[ Administration ]" NavigateUrl="~/Administration/Default.aspx"
        CssClass="linkButton" Visible="False"></asp:HyperLink>
</asp:Panel>
