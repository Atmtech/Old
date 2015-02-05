<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="loginConnecter">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblEntrerInformationLogin" Text="Information de connection"></asp:Label></div>
        <div>
            <asp:Label runat="server" ID="lblCourriel" Text="Courriel" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txtCourriel" CssClass="textBox" Width="300px"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblMotDePasse" Text="Mot de passe" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtMotDePasse" runat="server" CssClass="textBox" Width="300px" TextMode="Password"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Button runat="server" ID="btnOublieMotDePasse" Text="J'ai oublié mon mot de passe ?" CssClass="boutonLien" />
        </div>

        <div style="padding-top: 20px;">
            <asp:Button runat="server" ID="btnConnecterLogin" Text="Se connecter" CssClass="boutonActionRond" Width="200px"></asp:Button>
        </div>
    </div>

    <div class="loginCreerLogin">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblCreerCompte" Text="Creer compte"></asp:Label></div>
        <div>
            <asp:Label runat="server" ID="lblPrenom" Text="Prénom" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtPrenom" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblNom" Text="Nom" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtNom" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </div>

        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblCourrielCreer" Text="Courriel" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtCourrielCreer" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </div>

        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblMotDePasseCreer" Text="Mot de passe" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtMotDePasseCreer" runat="server" CssClass="textBox" Width="300px" TextMode="Password"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblMotDePasseCreerConfirmation" Text="Confirmation" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtMotDePasseCreerConfirmation" runat="server" CssClass="textBox" Width="300px" TextMode="Password"></asp:TextBox>
        </div>

        <div style="padding-top: 20px;">
            <asp:Button runat="server" ID="btnCreerLogin" Text="Créer" CssClass="boutonActionRond" Width="200px"></asp:Button>
        </div>


    </div>

    <div style="clear: both;"></div>
</asp:Content>
