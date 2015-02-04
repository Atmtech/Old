<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="loginConnecter">
        <div style="padding-bottom: 20px;">Information</div>
        <div>
            <asp:Label runat="server" ID="lblCourriel" Text="Courriel" CssClass="labelLogin"></asp:Label></div>
        <div>
            <asp:TextBox runat="server" CssClass="textBox" Width="300px"></asp:TextBox></div>
        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblMotDePasse" Text="Mot de passe" CssClass="labelLogin"></asp:Label></div>
        <div>
            <asp:TextBox ID="txtMotDePasse" runat="server" CssClass="textBox" Width="300px" TextMode="Password"></asp:TextBox></div>
        <div style="padding-top: 20px;">
             <asp:Button runat="server" ID="btnForgetPassword" Text="J'ai oublié mon mot de passe ?" OnClick="ForgetPasswordClick" CssClass="boutonLien" />
        </div>
        
        <div style="padding-top: 20px;">
             <asp:Button runat="server" ID="btnSignIn" Text="Entrer" OnClick="SignInClick" CssClass="boutonActionRond" Width="200px"></asp:Button>
        </div>
    </div>
      <div style="clear: both;"></div>
    <%--  <asp:Panel runat="server" ID="pnlLogin" Visible="True" DefaultButton="btnSignIn">
        <div style="width: 950px; padding: 10px 10px 10px 10px; color: black; border: solid 1px gray; background-color: white; margin-bottom: 10px;">
            <div class="title">
                <strong>
                    <asp:Label runat="server" ID="lblSignIn" Text="S'authentifier"></asp:Label></h2>
                </strong>
            </div>
            <br />
            <div style="float: left; width: 250px;">
                <asp:Label runat="server" ID="lblUserNameLabel"></asp:Label>
            </div>
            <div style="float: left;">
                <i class="icon-user"></i>
                <asp:TextBox runat="server" ID="txtUser" />
            </div>
            <br />
            <br />
            <div style="float: left; width: 250px;">
                <asp:Label runat="server" ID="lblPasswordLabel"></asp:Label>
            </div>
            <div style="float: left;">
                <i class="icon-key"></i>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
            </div>
            <br />
            <br />
            <br />
            <hr />
            <asp:Button runat="server" ID="btnSignIn" Text="Entrer" OnClick="SignInClick" CssClass="image-button"></asp:Button>
            <asp:Button runat="server" ID="btnCreateCustomer" Text="Créer un compte" OnClick="CreateCustomerClick"
                Visible="False" />
            <asp:Button runat="server" ID="btnForgetPassword" Text="J'ai oublié mon mot de passe"
                OnClick="ForgetPasswordClick" />
        </div>

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
    </asp:Panel>--%>
</asp:Content>
