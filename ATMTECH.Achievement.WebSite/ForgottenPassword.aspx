<%@ Page Title="" Language="C#" MasterPageFile="~/Achievement.Master" AutoEventWireup="true" CodeBehind="ForgottenPassword.aspx.cs" Inherits="ATMTECH.Achievement.WebSite.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="boiteBlancheArrondi" style="text-align: center;">
        <img src="images/Badge/lock-48.png" />
        <h1>J'espère que vous vous souvenez de votre courriel ...
        </h1>

        <asp:TextBox runat="server" ID="txtCourriel" PlaceHolder="Adresse de courriel" CssClass="txtSignup"></asp:TextBox>

       
        <br/><br/><asp:Button runat="server" ID="btnEnvoyerMotDePasse" text="Envoyez moi mon mot de passe merci" CssClass="bouton" OnClick="btnEnvoyerMotDePasseClick"/>
       
    </div>
</asp:Content>
