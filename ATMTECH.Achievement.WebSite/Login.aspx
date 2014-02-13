<%@ Page Title="" Language="C#" MasterPageFile="~/Achievement.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ATMTECH.Achievement.WebSite.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="boiteBlancheArrondi" style="text-align: center;">
        <img src="images/Badge/lock-48.png" />
        <h1>Connexion à Whoozme
        </h1>

        <asp:TextBox runat="server" ID="txtUtilisateur" PlaceHolder="Adresse de courriel" CssClass="txtSignup"></asp:TextBox>

        <asp:TextBox runat="server" ID="txtMotDePasse" PlaceHolder="Mot de passe" CssClass="txtSignup" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox runat="server" ID="chkResterConnecte" Text="Je veux rester connecté (utilisation de cookie)" Checked="True" /><br />
        <br/>
        <asp:Button runat="server" ID="btnSignIn" Text="Connexion" CssClass="bouton" OnClick="btnSignInClick" />

        <asp:Button runat="server" ID="btnOublieMotDePasse" Text="J'ai oublié mon mot de passe" CssClass="bouton" OnClick="ForgetPasswordClick" />

    </div>
</asp:Content>
