<%@ Page Title="" Language="C#" MasterPageFile="~/Achievement.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Achievement.WebSite.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=286270354802156";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>




    <div class="boiteBlancheArrondi300px">
        <h1>Bienvenue sur le réseau social qui vous défini vraiment
        </h1>
        Questionnez-vous sur ce que vous êtes, voyez comment vos amis sont et suivez votre progression de vie à travers une multitude d'accomplissement. Voici ce à quoi vous pouvez vous attendre dans ce site web.<br />
        <h1>Accomplissements</h1>
        Vous devrez sélectionner une multitude d'accomplissement qui vous définiront avec des qualités et des défauts.
            <h1>Déjà un membre !
            </h1>
        <asp:Button runat="server" ID="btnSignin" Text="Identifiez-vous" CssClass="bouton" OnClick="btnSignInClick" />
        <h2>Partager sur les réseaux</h2>
        <div id="fb-root"></div>

        <div class="fb-share-button" data-href="http://www.google.com" data-type="button_count"></div>
        <a href="https://twitter.com/share" class="twitter-share-button">Tweet</a>
        <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
    </div>
    <div class="boiteBlancheArrondi">
        <h1>Créer vous un compte
        </h1>
        Nous vous garantissons que vos données ne seront <b>jamais</b> divulgé à votre insu ! 
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nom obligatoire" ControlToValidate="txtNom" ValidationGroup="signup" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Prénom obligatoire" ControlToValidate="txtPrenom" ValidationGroup="signup" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Mot de passe obligatoire" ControlToValidate="txtMotDepasse" ValidationGroup="signup" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Courriel obligatoire" ControlToValidate="txtConfirmationCourriel" ValidationGroup="signup" Display="None"></asp:RequiredFieldValidator>


        <asp:ValidationSummary runat="server" ValidationGroup="signup" />

        <asp:TextBox runat="server" ID="txtNom" placeholder="Nom" CssClass="txtSignup" ValidationGroup="signup"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtPrenom" placeholder="Prénom" CssClass="txtSignup" ValidationGroup="signup"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtCourriel" placeholder="Courriel" CssClass="txtSignup" ValidationGroup="signup"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtConfirmationCourriel" placeholder="Confirmation du courriel" CssClass="txtSignup" ValidationGroup="signup"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtMotDepasse" placeholder="Mot de passe" CssClass="txtSignup" ValidationGroup="signup" TextMode="Password"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtConfirmationMotdePasse" placeholder="Confirmation du mot de passe" CssClass="txtSignup" ValidationGroup="signup" TextMode="Password"></asp:TextBox>

        <div style="text-align: center; padding-top: 15px;">
            <asp:Button runat="server" ID="btnCreerUtilisateur" CssClass="bouton" Text="Inscription" ValidationGroup="signup" CausesValidation="True" />
            <h6>En vous inscrivant vous acceptez la politique d'utilisation de ce site web.</h6>


        </div>
    </div>

</asp:Content>
