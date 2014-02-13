<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="ATMTECH.ShoppingCart.WebSite.UserControls.Login" %>
<div class="login">
    <asp:Label runat="server" ID="titleLogin" Text="Identification" CssClass="title"
        Visible="False"></asp:Label>
    <asp:Panel runat="server" ID="pnlLogin" Visible="True" DefaultButton="btnSignIn">
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtUser" Libelle="Utilisateur" />
                <atmtech:TextBoxAvance runat="server" ID="txtPassword" Libelle="Mot de passe" TextMode="Password" />
                <td>
                    <asp:Button runat="server" ID="btnSignIn" Text="Entrer" OnClick="SignInClick" />
                </td>
                <td>
                    <atmtech:Bouton runat="server" ID="btnCreateCustomer" Text="Créer un compte" OnClick="CreateCustomerClick" />
                </td>
                <td>
                    <atmtech:Bouton runat="server" ID="btnForgetPassword" Text="J'ai oublié mon mot de passe"
                        OnClick="ForgetPasswordClick" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlWelcome" Visible="False">
        Bienvenue,
        <asp:Label runat="server" ID="lblName"></asp:Label>
        <asp:HyperLink runat="server" ID="lnkCustomerInformation" NavigateUrl="~/CustomerInformation.aspx"
            CssClass="linkButton" Text="[ Modifier Mes informations personnelles ]"></asp:HyperLink>
        <asp:LinkButton runat="server" ID="lnkSignOut" OnClick="SignOutClick" Text="[ Fermer la session ]"
            CssClass="linkButton"></asp:LinkButton>
        <asp:HyperLink runat="server" ID="lnkAdministration" Text="[ Administration ]" NavigateUrl="~/Administration/Default.aspx"
            CssClass="linkButton" Visible="False"></asp:HyperLink>
    </asp:Panel>
</div>
